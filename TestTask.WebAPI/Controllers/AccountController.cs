using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces.Accounts;
using TestTask.BLL.Interfaces.Contacts;
using TestTask.DAL;
using TestTask.DAL.Enteties;

namespace TestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;

        public AccountController(IAccountService accountService, IContactService contactService)
        {
            _accountService = accountService;
            _contactService = contactService;
        }

        // POST api/<AccountController>
        [HttpPost("AddAccount")]
        public async Task<ActionResult<Account>> AddContact([FromBody] AccountcontactDTO accountcontactDTO)
        {
            Account newAccount = new Account() { Name = accountcontactDTO.AccountName};

            if (accountcontactDTO == null)
            {
                return BadRequest();
            }

            try
            {    
                newAccount = await _accountService.AddNewAccountAsync(newAccount);
                await _contactService.LinkContactToAccountAsync(new Contact() { Email = accountcontactDTO.ContactEmail, FirstName = accountcontactDTO.FirstName, LastName = accountcontactDTO.LastName },
                accountcontactDTO.AccountName);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
