using CRM.API.DAL;
using CRM.API.Framework;
using CRM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRM.API.DAL.Repositories
{
    public class AccountRepository : Repository<Account>
    {
        private new readonly CRMContext context;

        public AccountRepository(CRMContext context) : base(context)
        {
            this.context = context;
        }

        // Additional functionality and overrides

        public async Task<bool> ExistsByName(string name)
        {
            Account account = await this.context.Accounts.Where(a => a.Name == name).FirstOrDefaultAsync();
            return account != null;
        }

        //public override async Task DeleteSoftAsync(Account entityToDelete)
        //{
        //    entityToDelete.DeletedOn = DateTime.Now;
        //    entityToDelete.ModifiedOn = DateTime.Now;
        //    // entityToDelete.ModifiedById = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        //    context.Accounts.Attach(entityToDelete);
        //    context.Entry(entityToDelete).State = EntityState.Modified;

        //    await context.SaveChangesAsync();
        //}
    }
}
