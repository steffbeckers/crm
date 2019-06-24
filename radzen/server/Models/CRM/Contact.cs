using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Contacts", Schema = "dbo")]
  public partial class Contact
  {
    [Key]
    public Guid Id
    {
      get;
      set;
    }


    [InverseProperty("Contact")]
    public ICollection<Account> Accounts { get; set; }
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
    public string JobTitle
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string Telephone
    {
      get;
      set;
    }
    public string MobilePhone
    {
      get;
      set;
    }
    public int? Gender
    {
      get;
      set;
    }
    public Guid? AccountId
    {
      get;
      set;
    }

    [ForeignKey("AccountId")]
    public Account Account { get; set; }
    public DateTime CreatedOn
    {
      get;
      set;
    }
    public DateTime ModifiedOn
    {
      get;
      set;
    }
    public DateTime? DeletedOn
    {
      get;
      set;
    }
    public Guid CreatedById
    {
      get;
      set;
    }
    public Guid ModifiedById
    {
      get;
      set;
    }
  }
}
