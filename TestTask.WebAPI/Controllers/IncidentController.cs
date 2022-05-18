using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces.Accounts;
using TestTask.BLL.Interfaces.Contacts;
using TestTask.BLL.Interfaces.Incidents;
using TestTask.DAL.Enteties;

namespace TestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public IncidentController(IIncidentService incidentService, IAccountService accountService, IContactService contactService)
        {
            _incidentService = incidentService;
            _accountService = accountService;
            _contactService = contactService;
        }

        // POST api/<IncidentController>
        [HttpPost("AddIncident")]
        public async Task<ActionResult<ContactAccountIncidentDTO>> AddContact([FromBody] ContactAccountIncidentDTO contactAccountIncidentDTO)
        {
            if (contactAccountIncidentDTO == null)
            {
                return BadRequest();
            }

            if (!(await _accountService.CheckIfAccountNameExistsAsync(contactAccountIncidentDTO.AccountName)))
            {
                return NotFound();
            }

            try
            {
                await _contactService.LinkContactToAccountAsync(new Contact(){ Email = contactAccountIncidentDTO.ContactEmail, FirstName = contactAccountIncidentDTO.FirstName, LastName = contactAccountIncidentDTO.LastName },
                contactAccountIncidentDTO.AccountName);
                Incident incident =  await _incidentService.AddNewIncidentAsync(new Incident() { Description = contactAccountIncidentDTO.IncidentDescription});
                await _accountService.LinkAccountToIncidentAsync(contactAccountIncidentDTO.AccountName, incident.Name);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(contactAccountIncidentDTO);
        }
    }
}
