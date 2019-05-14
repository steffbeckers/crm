using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels
{
    public class CountryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
