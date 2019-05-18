using CRM.API.DAL;
using CRM.API.Framework;
using CRM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.BLL
{
    public class AccountBLL
    {
        private readonly UnitOfWork unitOfWork;

        public AccountBLL(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            // Check if account name already exists
            if (await this.unitOfWork.AccountRepository.ExistsByName(account.Name))
            {
                throw new CrmException("Name already exists.", 400);
            }

            // Create
            Account newAccount = await this.unitOfWork.AccountRepository.InsertAsync(account);

            // Set primary contact to first in list
            newAccount.PrimaryContactId = newAccount.Contacts.First().Id;
            newAccount = this.unitOfWork.AccountRepository.Update(newAccount);

            return newAccount;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await this.unitOfWork.AccountRepository.GetAsync() as List<Account>;
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            return await this.unitOfWork.AccountRepository.GetByIdAsync(id);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await this.unitOfWork.AccountRepository.UpdateAsync(account);
        }

        public async Task DeleteAccountById(Guid id)
        {
            await this.unitOfWork.AccountRepository.DeleteAsync(id);
        }
    }
}
