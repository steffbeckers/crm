using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace Crm.Controllers.Crm
{
  using Models;
  using Data;
  using Models.Crm;

  [ODataRoutePrefix("odata/CRM/Accounts")]
  [Route("mvc/odata/CRM/Accounts")]
  public partial class AccountsController : ODataController
  {
    private Data.CrmContext context;

    public AccountsController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/Accounts
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.Account> GetAccounts()
    {
      var items = this.context.Accounts.AsQueryable<Models.Crm.Account>();
      this.OnAccountsRead(ref items);

      return items;
    }

    partial void OnAccountsRead(ref IQueryable<Models.Crm.Account> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<Account> GetAccount(Guid key)
    {
        var items = this.context.Accounts.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnAccountDeleted(Models.Crm.Account item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteAccount(Guid key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Accounts
                .Where(i => i.Id == key)
                .Include(i => i.Accounts1)
                .Include(i => i.Accounts2)
                .Include(i => i.Contacts)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAccountDeleted(item);
            this.context.Accounts.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAccountUpdated(Models.Crm.Account item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAccount(Guid key, [FromBody]Models.Crm.Account newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.Id != key))
            {
                return BadRequest();
            }

            this.OnAccountUpdated(newItem);
            this.context.Accounts.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Accounts.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Address,Account2,Account1,AccountRelationType,Contact,User,User1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAccount(Guid key, [FromBody]Delta<Models.Crm.Account> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Accounts.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAccountUpdated(item);
            this.context.Accounts.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Accounts.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Address,Account2,Account1,AccountRelationType,Contact,User,User1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAccountCreated(Models.Crm.Account item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.Account item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAccountCreated(item);
            this.context.Accounts.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.Accounts.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Address,Account2,Account1,AccountRelationType,Contact,User,User1");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
