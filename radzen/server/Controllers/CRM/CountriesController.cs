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

  [ODataRoutePrefix("odata/CRM/Countries")]
  [Route("mvc/odata/CRM/Countries")]
  public partial class CountriesController : ODataController
  {
    private Data.CrmContext context;

    public CountriesController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/Countries
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.Country> GetCountries()
    {
      var items = this.context.Countries.AsQueryable<Models.Crm.Country>();
      this.OnCountriesRead(ref items);

      return items;
    }

    partial void OnCountriesRead(ref IQueryable<Models.Crm.Country> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<Country> GetCountry(Guid key)
    {
        var items = this.context.Countries.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnCountryDeleted(Models.Crm.Country item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteCountry(Guid key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Countries
                .Where(i => i.Id == key)
                .Include(i => i.Addresses)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnCountryDeleted(item);
            this.context.Countries.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnCountryUpdated(Models.Crm.Country item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutCountry(Guid key, [FromBody]Models.Crm.Country newItem)
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

            this.OnCountryUpdated(newItem);
            this.context.Countries.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Countries.Where(i => i.Id == key);
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
    public IActionResult PatchCountry(Guid key, [FromBody]Delta<Models.Crm.Country> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Countries.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnCountryUpdated(item);
            this.context.Countries.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Countries.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnCountryCreated(Models.Crm.Country item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.Country item)
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

            this.OnCountryCreated(item);
            this.context.Countries.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Crm/Countries/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
