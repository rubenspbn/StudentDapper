using BOL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> SortStudents(IEnumerable<Student> students);
        Task<IEnumerable<Student>> FilterStudents(IEnumerable<Student> students);
    }
}
