using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.Repositories.Realization
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly TestTaskDBContext _dbContext;

        private IIncidentRepository _incident;
        private IAccountRepository _account;
        private IContactRepository _contact;

        public RepositoryWrapper(TestTaskDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IIncidentRepository Incident
        {
            get
            {
                if (_incident == null)
                {
                    _incident = new IncidentRepository(_dbContext);
                }
                return _incident;
            }
        }

      

        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                   _contact = new ContactRepository(_dbContext);
                }
                return _contact;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_dbContext);
                }
                return _account;
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
