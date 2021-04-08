using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using BOL.Models;
using System.Reflection;
using Dapper;
using System.ComponentModel;

namespace DAL.Models
{
    public abstract class GenericDataAccess<T> : IGenericDataAccess<T>
    {
        #region CONNECTION
        private readonly string _tableName;
        protected GenericDataAccess(string tableName)
        {
            _tableName = tableName;
        }
        private SqlConnection SqlConnection()
        {
            return new SqlConnection(Helper.Constr("StudentIntec"));
        }
        private IDbConnection CreateConnection()
        {
            var connection = SqlConnection();
            connection.Open();
            return connection;
        }
        #endregion
        #region CRUD
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var con = CreateConnection())
            {
                string sql = $"SELECT * FROM {_tableName}";
                return await con.QueryAsync<T>(sql);
            }
        }

        public async Task DeleteRowAsync(Guid id)
        {
            using (var con = CreateConnection())
            {
                string sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
                await con.QueryAsync<T>(sql, new { Id = id });
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            using (var con = CreateConnection())
            {
                string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
                return await con.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
            }
        }

        public async Task SaveRangeAsync(IEnumerable<T> list)
        {
            string sql = GenerateInsertSQL();
            using (var con = CreateConnection())
            {
                await con.ExecuteAsync(sql, list);
            }
        }

        public async Task UpdateAsync(T obj)
        {
            string sql = GenerateUpdateSQL();
            using (var con = CreateConnection())
            {
                await con.ExecuteAsync(sql, obj);
            }
        }

        public async Task InsertAsync(T obj)
        {
            string sql = GenerateInsertSQL();
            using (var con = CreateConnection())
            {
                await con.ExecuteAsync(sql, obj);
            }
        }
        #endregion
        #region HELPERS
        private IEnumerable<PropertyInfo> Properties => typeof(T).GetProperties();
        private static List<string> GenerateListProperties(IEnumerable<PropertyInfo> Properties)
        {
            return (
                    from prop in Properties
                    //get attributes from property
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    //check if there are any attributes OR the first attribute is not ignore
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    //put them in a list
                    select prop.Name
                    ).ToList();
        }
        private string GenerateInsertSQL()
        {
            StringBuilder InsertSQL = new StringBuilder($"INSERT INTO {_tableName} (");
            List<string> props = GenerateListProperties(Properties);
            props.ForEach(p =>
            {
                if (!p.Equals("ID")) //ID GETS HANLED BY SQL SERVER
                    InsertSQL.Append($"[{p}],");
            });
            InsertSQL.Remove(InsertSQL.Length - 1, 1).Append(") VALUES ("); // last comma
            props.ForEach(p =>
            {
                if (!p.Equals("ID")) //ID GETS HANLED BY SQL SERVER
                    InsertSQL.Append($"@{p},");
            });
            InsertSQL.Remove(InsertSQL.Length - 1, 1).Append(")"); // last comma
            return InsertSQL.ToString();
        }
        private string GenerateUpdateSQL()
        {
            StringBuilder UpdateSQL = new StringBuilder($"UPDATE {_tableName} SET ");
            List<string> props = GenerateListProperties(Properties);
            props.ForEach(p =>
            {
                if (!p.Equals("ID")) //Don't change id
                    UpdateSQL.Append($"{p}=@{p},");
            });
            UpdateSQL.Remove(UpdateSQL.Length - 1, 1).Append(" WHERE Id=@Id"); // last comma
            return UpdateSQL.ToString();
        }
        #endregion
    }
}
