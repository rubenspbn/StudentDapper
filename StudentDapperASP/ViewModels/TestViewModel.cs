using BOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentDapperASP.ViewModels
{
    public class TestViewModel
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        public string Name { get; set; }
        [ScaffoldColumn(false)]
        public Guid StudentID { get; set; }
        [Display(Name="Student name")]
        public string StudentName { get; set; }
        public decimal? Score { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool AsksTooMuch { get; set; }
    }
}