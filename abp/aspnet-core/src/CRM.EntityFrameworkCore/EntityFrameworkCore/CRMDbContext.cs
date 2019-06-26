using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CRM.Authorization.Roles;
using CRM.Authorization.Users;
using CRM.MultiTenancy;

namespace CRM.EntityFrameworkCore
{
    public class CRMDbContext : AbpZeroDbContext<Tenant, Role, User, CRMDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {
        }
    }
}
