using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Enteties;

namespace TestTask.BLL.Interfaces.Incidents
{
    public interface IIncidentService
    {
        Task<Incident> AddNewIncidentAsync(Incident newIncident);
    }
}
