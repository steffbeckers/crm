using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Addresses", Schema = "dbo")]
  public partial class Address
  {
    [Key]
    public Guid Id
    {
      get;
      set;
    }


    [InverseProperty("Address")]
    public ICollection<Account> Accounts { get; set; }
    public string Street
    {
      get;
      set;
    }
    public string Number
    {
      get;
      set;
    }
    public string City
    {
      get;
      set;
    }
    public string State
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
    public decimal? Latitude
    {
      get;
      set;
    }
    public decimal? Longitude
    {
      get;
      set;
    }
    public Guid? CountryId
    {
      get;
      set;
    }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }
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
