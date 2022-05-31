using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProjects3.DAL.model
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\(?([6-9]{1})\)?([0-9]{9})$",
                  ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNo { get; set; }
        [Required]
        [ForeignKey("DepartmentID")]
        public string Address { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string StudentId { get; set; }
    }
}
