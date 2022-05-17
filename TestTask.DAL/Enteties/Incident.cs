using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Enteties
{
    public class Incident
    {
        [Key]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public ICollection<Account> Accounts { get; set; }
    }
}
