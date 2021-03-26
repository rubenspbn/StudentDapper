using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class Test
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        public decimal? Score { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool AsksTooMuch { get; set; }
    }
}
