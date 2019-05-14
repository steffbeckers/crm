using CRM.API.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.DAL
{
    public class UnitOfWork
    {
        public CRMContext context { get; set; }

        public UnitOfWork()
        {
            context = new CRMContext();
        }

        private AccountRepository accountRepository;
        public AccountRepository AccountRepository
        {
            get { return accountRepository ?? (accountRepository = new AccountRepository(this.context)); }
        }
    }
}
