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

  [ODataRoutePrefix("odata/CRM/AccountRelationTypes")]
  [Route("mvc/odata/CRM/AccountRelationTypes")]
  public partial class AccountRelationTypesController : ODataController
  {
    private Data.CrmContext context;

    public AccountRelationTypesController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/AccountRelationTypes
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.AccountRelationType> GetAccountRelationTypes()
    {
      var items = this.context.AccountRelationTypes.AsQueryable<Models.Crm.AccountRelationType>();
      this.OnAccountRelationTypesRead(ref items);

      return items;
    }

    partial void OnAccountRelationTypesRead(ref IQueryable<Models.Crm.AccountRelationType> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<AccountRelationType> GetAccountRelationType(Guid key)
    {
        var items = this.context.AccountRelationTypes.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnAccountRelationTypeDeleted(Models.Crm.AccountRelationType item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteAccountRelationType(Guid key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.AccountRelationTypes
                .Where(i => i.Id == key)
                .Include(i => i.Accounts)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAccountRelationTypeDeleted(item);
            this.context.AccountRelationTypes.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAccountRelationTypeUpdated(Models.Crm.AccountRelationType item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAccountRelationType(Guid key, [FromBody]Models.Crm.AccountRelationType newItem)
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

            this.OnAccountRelationTypeUpdated(newItem);
            this.context.AccountRelationTypes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AccountRelationTypes.Where(i => i.Id == key);
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
    public IActionResult PatchAccountRelationType(Guid key, [FromBody]Delta<Models.Crm.AccountRelationType> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.AccountRelationTypes.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAccountRelationTypeUpdated(item);
            this.context.AccountRelationTypes.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AccountRelationTypes.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAccountRelationTypeCreated(Models.Crm.AccountRelationType item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.AccountRelationType item)
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

            this.OnAccountRelationTypeCreated(item);
            this.context.AccountRelationTypes.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Crm/AccountRelationTypes/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
