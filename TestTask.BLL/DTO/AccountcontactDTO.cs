using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class AccountcontactDTO
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\.0-9]+@[a-z]+\.[a-z]{2,3}$",
            ErrorMessage = "Sorry, only letters (a-z), numbers (0-9), and periods (.) are allowed for email")]
        public string ContactEmail { get; set; }
    }
}
