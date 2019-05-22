using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using CRM.API.ViewModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CRM.API.Controllers.OData
{
    [Authorize]
    [ODataRoutePrefix("Account")]
    public class AccountController : ODataController
    {
        private readonly UnitOfWork unitOfWork;

        public AccountController()
        {
            unitOfWork = new UnitOfWork();
        }

        [ODataRoute]
        [EnableQuery(PageSize = 20, AllowedFunctions = AllowedFunctions.All)]
        public IQueryable Get()
        {
            return unitOfWork.context.Accounts.AsQueryable();
        }

        [ODataRoute("{id}")]
        [EnableQuery(AllowedFunctions = AllowedFunctions.All)]
        public SingleResult<Account> Get([FromODataUri] Guid id)
        {
            return SingleResult.Create(unitOfWork.context.Accounts.Where(c => c.Id == id));
        }
    }
}