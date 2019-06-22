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

  [ODataRoutePrefix("odata/CRM/Roles")]
  [Route("mvc/odata/CRM/Roles")]
  public partial class RolesController : ODataController
  {
    private Data.CrmContext context;

    public RolesController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/Roles
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.Role> GetRoles()
    {
      var items = this.context.Roles.AsQueryable<Models.Crm.Role>();
      this.OnRolesRead(ref items);

      return items;
    }

    partial void OnRolesRead(ref IQueryable<Models.Crm.Role> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<Role> GetRole(string key)
    {
        var items = this.context.Roles.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnRoleDeleted(Models.Crm.Role item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteRole(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Roles
                .Where(i => i.Id == key)
                .Include(i => i.UserRoles)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnRoleDeleted(item);
            this.context.Roles.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRoleUpdated(Models.Crm.Role item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutRole(string key, [FromBody]Models.Crm.Role newItem)
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

            this.OnRoleUpdated(newItem);
            this.context.Roles.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Roles.Where(i => i.Id == key);
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
    public IActionResult PatchRole(string key, [FromBody]Delta<Models.Crm.Role> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Roles.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnRoleUpdated(item);
            this.context.Roles.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Roles.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRoleCreated(Models.Crm.Role item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.Role item)
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

            this.OnRoleCreated(item);
            this.context.Roles.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Crm/Roles/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
