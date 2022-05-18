using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces.Contacts;
using TestTask.DAL.Enteties;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.BLL.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ContactService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<Contact> AddNewContactAsync(Contact newContact)
        {
            await _repoWrapper.Contact.CreateAsync(newContact);
            await _repoWrapper.SaveAsync();
            return newContact;
        }

        public async Task<bool> CheckIfContactExistsAsync(Contact contact)
        {
            var found = await _repoWrapper.Contact.GetFirstOrDefaultAsync(x => x.Email.Equals(contact.Email));    
            return (found != null);
        }

        public async Task LinkContactToAccountAsync(Contact contact, string accountName)
        {
            if(!(await CheckIfContactExistsAsync(contact)))
            {
               await AddNewContactAsync(contact);
            }

            contact.AccountId = (await _repoWrapper.Account.GetFirstAsync(x => x.Name.Equals(accountName))).Id;

            _repoWrapper.Contact.Update(contact);
            await _repoWrapper.SaveAsync();
        }

       
    }
}
