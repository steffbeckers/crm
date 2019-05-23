using CRM.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels
{
    public class AccountPatchVM
    {
        [MaxLength(100, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string Telephone { get; set; }

        [MaxLength(50, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string Fax { get; set; }

        [MaxLength(200, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string Website { get; set; }

        [MaxLength(50, ErrorMessage = "{0} has a maximum length of {1} characters.")]
        public string VATNumber { get; set; }

        public string Description { get; set; }

        public Guid? ParentAccountId { get; set; }
        public Guid? BillingAccountId { get; set; }
        public Guid? RelationTypeId { get; set; }
        public Guid? PrimaryContactId { get; set; }

        // INFO: This creates multiple addresses
        //public AddressVM Address { get; set; }
    }
}
