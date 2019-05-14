using CRM.API.DAL;
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
            return await this.unitOfWork.AccountRepository.InsertAsync(account);
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await this.unitOfWork.AccountRepository.GetAsync() as List<Account>;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            return await this.unitOfWork.AccountRepository.UpdateAsync(account);
        }
    }
}
