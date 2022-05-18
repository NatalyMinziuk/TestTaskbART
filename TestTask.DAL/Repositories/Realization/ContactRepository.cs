using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Enteties;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.DAL.Repositories.Realization
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(TestTaskDBContext dBContext)
           : base(dBContext)
        {
        }
    }
}
