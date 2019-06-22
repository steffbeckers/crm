using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Roles", Schema = "dbo")]
  public partial class Role
  {
    [Key]
    public string Id
    {
      get;
      set;
    }


    [InverseProperty("Role")]
    public ICollection<UserRole> UserRoles { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string NormalizedName
    {
      get;
      set;
    }
    public string ConcurrencyStamp
    {
      get;
      set;
    }
  }
}
