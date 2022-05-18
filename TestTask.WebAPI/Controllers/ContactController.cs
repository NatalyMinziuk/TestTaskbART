using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.Interfaces.Contacts;
using TestTask.DAL;
using TestTask.DAL.Enteties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // POST api/<ContactController>
        [HttpPost("AddContact")]
        public async Task<ActionResult<Contact>> AddContact([FromBody] Contact newContact)
        {

            if (newContact == null)
            {
                return BadRequest();
            }

            try
            {     
                    await _contactService.AddNewContactAsync(newContact);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(newContact);
        }
    }
}
