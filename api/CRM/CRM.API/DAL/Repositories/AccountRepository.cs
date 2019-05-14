using CRM.API.DAL;
using CRM.API.Framework;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
