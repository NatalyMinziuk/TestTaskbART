using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces.Accounts;
using TestTask.DAL.Enteties;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.BLL.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public AccountService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<Account> AddNewAccountAsync(Account newAccount)
        {
            await _repoWrapper.Account.CreateAsync(newAccount);
            await _repoWrapper.SaveAsync();
            return newAccount;
        }

        public async Task<bool> CheckIfAccountNameExistsAsync(string accountName)
        {
            var found = await _repoWrapper.Account.GetFirstOrDefaultAsync(x => x.Name.Equals(accountName));
            return (found != null);
        }

        public async Task LinkAccountToIncidentAsync(string accountName, string incidentId)
        {
            var oldAccount = await _repoWrapper.Account.GetFirstAsync(x => x.Name.Equals(accountName));
            oldAccount.IncidentName = incidentId;

            _repoWrapper.Account.Update(oldAccount);
            await _repoWrapper.SaveAsync();
        }
    }
}
