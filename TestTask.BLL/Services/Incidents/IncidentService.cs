using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces.Incidents;
using TestTask.DAL.Enteties;
using TestTask.DAL.Repositories.Interfaces;

namespace TestTask.BLL.Services.Incidents
{
    public class IncidentService : IIncidentService
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IncidentService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<Incident> AddNewIncidentAsync(Incident newIncident)
        {
            await _repoWrapper.Incident.CreateAsync(newIncident);
            await _repoWrapper.SaveAsync();
            return newIncident;
        }
    }
}
