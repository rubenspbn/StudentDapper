using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class DayEvaluation
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Present AM")]
        public Present PresentAM { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Present PM")]
        public Present PresentPM { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Is the student active")]
        [Range(typeof(bool),"No","Yes")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Text)]
        public string Honesty { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int SubjectInterest { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool Cooperating { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool ExtraClass { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool AsksTooMuch { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }
    }
}
