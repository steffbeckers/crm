using CRM.API.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRM.API.DAL
{
    public interface IUnitOfWork
    {
        CRMContext context { get; }
        AccountRepository AccountRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork
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
