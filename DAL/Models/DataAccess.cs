using BOL.Models;
using DAL.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace DAL.Models
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private IDbConnection con;
        private string _className = typeof(T).Name;
        public void Create(T item)
        {
            using (con = new SqlConnection(Helper.Constr(_className)))
            {
                con.Execute("Create", item, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (con = new SqlConnection(Helper.Constr(_className)))
            {
                con.Execute("Delete", id, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(T item)
        {
            using (con = new SqlConnection(Helper.Constr(_className)))
            {
                con.Execute("Update", item, commandType: CommandType.StoredProcedure);
            }
        }

        public T Read(int id)
        {
            using (con = new SqlConnection(Helper.Constr(_className)))
            {
                return con.QuerySingle<T>("Read", id, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (con = new SqlConnection(Helper.Constr(_className)))
            {
                return con.Query<T>("GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
