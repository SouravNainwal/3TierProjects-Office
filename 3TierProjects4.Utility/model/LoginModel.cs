using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProjects3.DAL.model
{
    public class LoginModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Valid Email Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }
    }
}
