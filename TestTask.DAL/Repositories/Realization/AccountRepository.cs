using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Enteties;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.Repositories.Realization
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(TestTaskDBContext dBContext)
           : base(dBContext)
        {
        }
    }
}
