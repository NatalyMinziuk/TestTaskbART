using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Enteties;

namespace TestTask.BLL.Interfaces.Accounts
{
    public interface IAccountService
    {
        Task<Account> AddNewAccountAsync(Account newAccount);
        Task<bool> CheckIfAccountNameExistsAsync(string accountName);
        Task LinkAccountToIncidentAsync(string accountName, string incidentId);
    }
}
