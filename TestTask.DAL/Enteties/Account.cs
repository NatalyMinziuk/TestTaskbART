using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Enteties
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public ICollection<Contact> Contacts { get; set; }
        [DataType(DataType.Text)]
        public string? IncidentName { get; set; }
        public Incident? Incident { get; set; }
    }
}
