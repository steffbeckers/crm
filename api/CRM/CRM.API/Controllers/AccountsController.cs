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
        public async Task<List<AccountVM>> Get()
        {
            return mapper.Map<List<Account>, List<AccountVM>>(await unitOfWork.AccountRepository.GetAsync() as List<Account>);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AccountVM> GetById(Guid id)
        {
            return mapper.Map<Account, AccountVM>(await unitOfWork.AccountRepository.GetByIdAsync(id));
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
            account.CreatedById = Guid.Parse(currentUser.Id);
            account.ModifiedById = Guid.Parse(currentUser.Id);
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
    }
}