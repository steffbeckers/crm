using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.BLL;
using CRM.API.DAL;
using CRM.API.Framework;
using CRM.API.Models;
using CRM.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<ActionResult<AccountVM>> Create([FromBody] AccountVM accountVM)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapping
            Account account = this.mapper.Map<AccountVM, Account>(accountVM);

            // BLL
            User currentUser = await userManager.GetUserAsync(User);
            AccountBLL bll = new AccountBLL(this.unitOfWork, currentUser);

            // Create
            Account newAccount;
            try
            {
                newAccount = await bll.CreateAccount(account);
            }
            catch (CrmException ex)
            {
                return BadRequest(this.mapper.Map<CrmException, CrmExceptionVM>(ex));
            }

            // Mapping
            return CreatedAtAction("GetById", new { id = newAccount.Id }, this.mapper.Map<Account, AccountVM>(newAccount));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<AccountVM>> Update(Guid id, [FromBody] AccountVM accountVM)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != accountVM.Id)
            {
                return BadRequest();
            }
            if (!this.unitOfWork.context.Accounts.Any(a => a.Id == id))
            {
                return NotFound();
            }

            // Mapping
            Account account = this.mapper.Map<AccountVM, Account>(accountVM);

            // BLL
            User currentUser = await userManager.GetUserAsync(User);
            AccountBLL bll = new AccountBLL(this.unitOfWork, currentUser);

            // Update
            Account updatedAccount = await bll.UpdateAccount(account);

            // Mapping
            return Ok(this.mapper.Map<Account, AccountVM>(updatedAccount));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<AccountVM>> Patch(Guid id, [FromBody] JsonPatchDocument<AccountPatchVM> patchDocument)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // BLL
            User currentUser = await userManager.GetUserAsync(User);
            AccountBLL bll = new AccountBLL(this.unitOfWork, currentUser);

            // Retrieve account
            Account account = await bll.GetAccountById(id);

            // Validation
            if (account == null)
            {
                return NotFound();
            }

            // Mapping
            AccountPatchVM accountPatchVM = this.mapper.Map<AccountPatchVM>(account);

            // Patch
            patchDocument.ApplyTo(accountPatchVM, ModelState);

            // Validation after patch
            if (!TryValidateModel(account))
            {
                return BadRequest(ModelState);
            }

            // Mapping
            this.mapper.Map(accountPatchVM, account);

            // Trigger update
            await bll.UpdateAccount(account);

            return Ok(this.mapper.Map<Account, AccountVM>(account));
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