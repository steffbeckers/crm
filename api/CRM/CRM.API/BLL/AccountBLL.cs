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
        private readonly User currentUser;

        public AccountBLL(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AccountBLL(UnitOfWork unitOfWork, User currentUser)
        {
            this.unitOfWork = unitOfWork;
            this.currentUser = currentUser;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            #region Before
            // Check if account name already exists
            if (await this.unitOfWork.AccountRepository.ExistsByName(account.Name))
            {
                throw new CrmException("Name already exists.", 400);
            }

            // Set timestamps
            account.CreatedOn = DateTime.UtcNow;
            account.ModifiedOn = DateTime.UtcNow;

            // Set user
            account.CreatedById = Guid.Parse(currentUser.Id).ToString();
            account.ModifiedById = Guid.Parse(currentUser.Id).ToString();

            // Also on new address
            // TODO: Check if there is a better way to do this.
            if (account.Address != null)
            {
                account.Address.CreatedById = Guid.Parse(currentUser.Id);
                account.Address.ModifiedById = Guid.Parse(currentUser.Id);
            }

            // Also on new contacts
            // TODO: Check if there is a better way to do this.
            if (account.Contacts.Count > 0)
            {
                foreach (Contact contact in account.Contacts)
                {
                    // Set timestamps
                    contact.CreatedOn = DateTime.UtcNow;
                    contact.ModifiedOn = DateTime.UtcNow;

                    // Set user
                    contact.CreatedById = Guid.Parse(currentUser.Id);
                    contact.ModifiedById = Guid.Parse(currentUser.Id);
                }
            }
            #endregion

            Account newAccount = await this.unitOfWork.AccountRepository.InsertAsync(account);

            #region After
            // Set primary contact to first in list
            newAccount.PrimaryContactId = newAccount.Contacts.First().Id;
            newAccount = this.unitOfWork.AccountRepository.Update(newAccount);
            #endregion

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
            #region Before
            // Set user
            account.ModifiedById = Guid.Parse(currentUser.Id).ToString();
            // Set timestamp
            account.ModifiedOn = DateTime.UtcNow;
            #endregion

            return await this.unitOfWork.AccountRepository.UpdateAsync(account);
        }

        public async Task DeleteAccountById(Guid id)
        {
            await this.unitOfWork.AccountRepository.DeleteAsync(id);
        }
    }
}
