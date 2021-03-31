using BLL.Interfaces;
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
    public class StudentRepository : /*IStudentRepository,*/ IGenericDataAccess<Student>
    {
        private StudentDataAccess SDA = new StudentDataAccess();
        public async Task DeleteRowAsync(Guid id)
        {
            await SDA.DeleteRowAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return (await SDA.GetAllAsync()).OrderBy(x => x.Lastname);
        }

        public async Task<Student> GetAsync(Guid id)
        {
            return await SDA.GetAsync(id);
        }

        public async Task InsertAsync(Student obj)
        {
            await SDA.InsertAsync(obj);
        }

        public async Task SaveRangeAsync(IEnumerable<Student> list)
        {
            await SDA.SaveRangeAsync(list);
        }

        public async Task UpdateAsync(Student obj)
        {
            await SDA.UpdateAsync(obj);
        }

    }
}
