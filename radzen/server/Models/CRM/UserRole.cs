using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("UserRoles", Schema = "dbo")]
  public partial class UserRole
  {
    [Key]
    public string UserId
    {
      get;
      set;
    }

    [ForeignKey("UserId")]
    public User User { get; set; }
    public string RoleId
    {
      get;
      set;
    }

    [ForeignKey("RoleId")]
    public Role Role { get; set; }
  }
}
