using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        [Description("ignore")]
        public string Name { get => $"{Firstname} {Lastname}"; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool Enrolled { get; set; }
    }
}
