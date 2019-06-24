using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Users", Schema = "dbo")]
  public partial class User
  {
    [Key]
    public string Id
    {
      get;
      set;
    }


    [InverseProperty("User")]
    public ICollection<Account> Accounts { get; set; }

    [InverseProperty("User1")]
    public ICollection<Account> Accounts1 { get; set; }

    [InverseProperty("User")]
    public ICollection<UserRole> UserRoles { get; set; }
    public string UserName
    {
      get;
      set;
    }
    public string NormalizedUserName
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string NormalizedEmail
    {
      get;
      set;
    }
    public bool EmailConfirmed
    {
      get;
      set;
    }
    public string PasswordHash
    {
      get;
      set;
    }
    public string SecurityStamp
    {
      get;
      set;
    }
    public string ConcurrencyStamp
    {
      get;
      set;
    }
    public string PhoneNumber
    {
      get;
      set;
    }
    public bool PhoneNumberConfirmed
    {
      get;
      set;
    }
    public bool TwoFactorEnabled
    {
      get;
      set;
    }
    public DateTimeOffset? LockoutEnd
    {
      get;
      set;
    }
    public bool LockoutEnabled
    {
      get;
      set;
    }
    public int AccessFailedCount
    {
      get;
      set;
    }
    public string FirstName
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }
  }
}
