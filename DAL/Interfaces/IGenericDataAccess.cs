using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericDataAccess<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteRowAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T obj);
        Task InsertAsync(T obj);
    }
}
