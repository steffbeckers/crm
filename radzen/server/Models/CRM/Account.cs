using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Accounts", Schema = "dbo")]
  public partial class Account
  {
    [Key]
    public Guid Id
    {
      get;
      set;
    }


    [InverseProperty("Account1")]
    public ICollection<Account> Accounts1 { get; set; }

    [InverseProperty("Account2")]
    public ICollection<Account> Accounts2 { get; set; }

    [InverseProperty("Account")]
    public ICollection<Contact> Contacts { get; set; }
    public string Name
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
    public string Fax
    {
      get;
      set;
    }
    public string Website
    {
      get;
      set;
    }
    public string VATNumber
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public Guid? AddressId
    {
      get;
      set;
    }

    [ForeignKey("AddressId")]
    public Address Address { get; set; }
    public Guid? ParentAccountId
    {
      get;
      set;
    }

    [ForeignKey("ParentAccountId")]
    public Account Account2 { get; set; }
    public Guid? BillingAccountId
    {
      get;
      set;
    }

    [ForeignKey("BillingAccountId")]
    public Account Account1 { get; set; }
    public Guid? RelationTypeId
    {
      get;
      set;
    }

    [ForeignKey("RelationTypeId")]
    public AccountRelationType AccountRelationType { get; set; }
    public Guid? PrimaryContactId
    {
      get;
      set;
    }

    [ForeignKey("PrimaryContactId")]
    public Contact Contact { get; set; }
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
    public string CreatedById
    {
      get;
      set;
    }

    [ForeignKey("CreatedById")]
    public User User { get; set; }
    public string ModifiedById
    {
      get;
      set;
    }

    [ForeignKey("ModifiedById")]
    public User User1 { get; set; }
  }
}
