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

  [ODataRoutePrefix("odata/CRM/Users")]
  [Route("mvc/odata/CRM/Users")]
  public partial class UsersController : ODataController
  {
    private Data.CrmContext context;

    public UsersController(Data.CrmContext context)
    {
      this.context = context;
    }
    // GET /odata/Crm/Users
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.Crm.User> GetUsers()
    {
      var items = this.context.Users.AsQueryable<Models.Crm.User>();
      this.OnUsersRead(ref items);

      return items;
    }

    partial void OnUsersRead(ref IQueryable<Models.Crm.User> items);

    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<User> GetUser(string key)
    {
        var items = this.context.Users.Where(i=>i.Id == key);
        return SingleResult.Create(items);
    }
    partial void OnUserDeleted(Models.Crm.User item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteUser(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var item = this.context.Users
                .Where(i => i.Id == key)
                .Include(i => i.Accounts)
                .Include(i => i.Accounts1)
                .Include(i => i.UserRoles)
                .FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            this.OnUserDeleted(item);
            this.context.Users.Remove(item);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnUserUpdated(Models.Crm.User item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutUser(string key, [FromBody]Models.Crm.User newItem)
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

            this.OnUserUpdated(newItem);
            this.context.Users.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Users.Where(i => i.Id == key);
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
    public IActionResult PatchUser(string key, [FromBody]Delta<Models.Crm.User> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.context.Users.Where(i => i.Id == key).FirstOrDefault();

            if (item == null)
            {
                return BadRequest();
            }

            patch.Patch(item);

            this.OnUserUpdated(item);
            this.context.Users.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Users.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnUserCreated(Models.Crm.User item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.Crm.User item)
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

            this.OnUserCreated(item);
            this.context.Users.Add(item);
            this.context.SaveChanges();

            return Created($"odata/Crm/Users/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
