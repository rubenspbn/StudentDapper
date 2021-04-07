using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TestDataAccess : GenericDataAccess<Test>
    {
        public TestDataAccess() : base("Test")
        {
        }
    }
}
