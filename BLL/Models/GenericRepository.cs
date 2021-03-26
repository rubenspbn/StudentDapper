using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class GenericRepository<T> : IDataAccess<T> where T : class
    {
        private readonly IDataAccess<T> _data;
        public GenericRepository(IDataAccess<T> data)
        {
            _data = data;
        }
        public void Create(T item)
        {
            _data.Create(item);
        }

        public void Delete(int id)
        {
            _data.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _data.GetAll();
        }

        public T Read(int id)
        {
            return _data.Read(id);
        }

        public void Update(T item)
        {
            _data.Update(item);
        }
    }
}
