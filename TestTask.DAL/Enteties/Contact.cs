using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Enteties
{
    public class Contact
    {
        [Key]
        [RegularExpression(@"^[a-zA-Z\.0-9]+@[a-z]+\.[a-z]{2,3}$",
            ErrorMessage = "Sorry, only letters (a-z), numbers (0-9), and periods (.) are allowed for email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
