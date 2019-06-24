using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Models.Crm
{
  [Table("Countries", Schema = "dbo")]
  public partial class Country
  {
    [Key]
    public Guid Id
    {
      get;
      set;
    }


    [InverseProperty("Country")]
    public ICollection<Address> Addresses { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string NativeName
    {
      get;
      set;
    }
    public string Alpha2Code
    {
      get;
      set;
    }
    public string Alpha3Code
    {
      get;
      set;
    }
    public string Capital
    {
      get;
      set;
    }
    public string Region
    {
      get;
      set;
    }
    public string Subregion
    {
      get;
      set;
    }
    public string NumericCode
    {
      get;
      set;
    }
    public string Flag
    {
      get;
      set;
    }
  }
}
