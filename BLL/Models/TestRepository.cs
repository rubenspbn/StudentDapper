using BOL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TestRepository : IGenericDataAccess<Test>
    {
        private TestDataAccess TDA = new TestDataAccess();
        public async Task DeleteRowAsync(Guid id)
        {
            await TDA.DeleteRowAsync(id);
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return (await TDA.GetAllAsync()).OrderBy(x => x.Date);
        }

        public async Task<Test> GetAsync(Guid id)
        {
            return await TDA.GetAsync(id);
        }

        public async Task InsertAsync(Test obj)
        {
            await TDA.InsertAsync(obj);
        }

        public async Task SaveRangeAsync(IEnumerable<Test> list)
        {
            await TDA.SaveRangeAsync(list);
        }

        public async Task UpdateAsync(Test obj)
        {
            await TDA.UpdateAsync(obj);
        }
    }
}
