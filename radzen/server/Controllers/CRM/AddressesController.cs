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

  [ODataRoutePrefix("odata/CRM/Addresses")]
  [Route("mvc/odata/CRM/Addresses")]
  public partial class AddressesController : ODataController
  {
    private Data.CrmContext context;

    public AddressesController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/Addresses
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.Address> GetAddresses()
    {
      var items = this.context.Addresses.AsQueryable<Models.Crm.Address>();
      this.OnAddressesRead(ref items);

      return items;
    }

    partial void OnAddressesRead(ref IQueryable<Models.Crm.Address> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<Address> GetAddress(Guid key)
    {
        var items = this.context.Addresses.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnAddressDeleted(Models.Crm.Address item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteAddress(Guid key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Addresses
                .Where(i => i.Id == key)
                .Include(i => i.Accounts)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAddressDeleted(item);
            this.context.Addresses.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAddressUpdated(Models.Crm.Address item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAddress(Guid key, [FromBody]Models.Crm.Address newItem)
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

            this.OnAddressUpdated(newItem);
            this.context.Addresses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Addresses.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Country");
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
    public IActionResult PatchAddress(Guid key, [FromBody]Delta<Models.Crm.Address> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Addresses.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnAddressUpdated(item);
            this.context.Addresses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Addresses.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Country");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAddressCreated(Models.Crm.Address item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.Address item)
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

            this.OnAddressCreated(item);
            this.context.Addresses.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.Addresses.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Country");

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
