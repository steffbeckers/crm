using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRM.API.Controllers
{
    [Authorize]
    [Route("odata/accounts")]
    [ApiController]
    public class ODataAccountsController : ODataController
    {
        private readonly ILogger logger;
        private readonly UnitOfWork unitOfWork;

        public ODataAccountsController(
            ILogger<ODataAccountsController> logger
        )
        {
            this.logger = logger;
            unitOfWork = new UnitOfWork();
        }

        [EnableQuery]
        [Route("")]
        public IQueryable Get()
        {
            return unitOfWork.context.Accounts.AsQueryable();
        }

        [EnableQuery]
        [Route("{id}")]
        public Account ById([FromODataUri] Guid id)
        {
            return unitOfWork.context.Accounts.SingleOrDefault(a => a.Id == id);
        }
    }
}