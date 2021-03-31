using BOL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentDataAccess : GenericDataAccess<Student>
    {
        public StudentDataAccess() : base("Student"){}
    }
}
