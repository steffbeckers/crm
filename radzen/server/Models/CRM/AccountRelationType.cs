using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("AccountRelationTypes", Schema = "dbo")]
  public partial class AccountRelationType
  {
    [Key]
    public Guid Id
    {
      get;
      set;
    }


    [InverseProperty("AccountRelationType")]
    public ICollection<Account> Accounts { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string DisplayName
    {
      get;
      set;
    }
  }
}
