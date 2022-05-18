using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.DAL.Enteties;

namespace TestTask.BLL.Interfaces.Contacts
{
    public interface IContactService
    {
        Task<Contact> AddNewContactAsync(Contact newContact);
        Task<bool> CheckIfContactExistsAsync(Contact contact);
        Task LinkContactToAccountAsync(Contact contact, string accountName);
    }
}
