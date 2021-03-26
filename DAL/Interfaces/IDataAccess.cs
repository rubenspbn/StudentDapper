using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDataAccess<T>
    {
        IEnumerable<T> GetAll();
        T Read(int id);
        void Delete(int id);
        void Create(T item);
        void Update(T item);
    }
}
