using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.BLL;
using CRM.API.DAL;
using CRM.API.Models;
using CRM.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public AccountsController(
            ILogger<AccountsController> logger,
            IMapper mapper,
            UserManager<User> userManager
        )
        {
            this.logger = logger;
            this.unitOfWork = new UnitOfWork();
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccountVM>>> Get()
        {
            AccountBLL bll = new AccountBLL(this.unitOfWork);

            return Ok(mapper.Map<List<Account>, List<AccountVM>>(await bll.GetAccounts()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AccountVM>> GetById(Guid id)
        {
            AccountBLL bll = new AccountBLL(this.unitOfWork);

            return Ok(mapper.Map<Account, AccountVM>(await bll.GetAccountById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<AccountVM>> Create(AccountVM accountVM)
        {
            // Validation
            if (accountVM == null)
            {
                return BadRequest();
            }

            Account account = this.mapper.Map<AccountVM, Account>(accountVM);

            // Set user details
            User currentUser = await userManager.GetUserAsync(User);
            account.CreatedById = Guid.Parse(currentUser.Id);
            account.ModifiedById = Guid.Parse(currentUser.Id);
            // Also on new contacts
            // TODO: Check if there is a better way to do this
            if (account.Contacts.Count > 0)
            {
                foreach (Contact contact in account.Contacts)
                {
                    account.CreatedById = Guid.Parse(currentUser.Id);
                    account.ModifiedById = Guid.Parse(currentUser.Id);
                }
            }

            AccountBLL bll = new AccountBLL(this.unitOfWork);

            accountVM = this.mapper.Map<Account, AccountVM>(await bll.CreateAccount(account));

            return CreatedAtAction("GetById", new { id = accountVM.Id }, accountVM);
        }

        [HttpPut]
        public async Task<ActionResult<AccountVM>> Update(AccountVM accountVM)
        {
            // Validation
            if (accountVM == null)
            {
                return BadRequest();
            }

            Account account = this.mapper.Map<AccountVM, Account>(accountVM);

            // Set user details
            User currentUser = await userManager.GetUserAsync(User);
            account.ModifiedById = Guid.Parse(currentUser.Id);
            account.ModifiedOn = DateTime.Now;

            AccountBLL bll = new AccountBLL(this.unitOfWork);

            return Ok(this.mapper.Map<Account, AccountVM>(await bll.UpdateAccount(account)));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            // Validation
            if (id == null)
            {
                return BadRequest();
            }

            AccountBLL bll = new AccountBLL(this.unitOfWork);

            await bll.DeleteAccountById(id);

            return Ok();
        }
    }
}