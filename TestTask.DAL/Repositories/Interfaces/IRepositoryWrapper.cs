using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
       IIncidentRepository Incident { get; }
       IAccountRepository Account { get; }
       IContactRepository Contact { get; }
       Task SaveAsync();
    }
}
