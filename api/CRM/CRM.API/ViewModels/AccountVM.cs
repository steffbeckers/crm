using CRM.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels
{
    public class AccountVM
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required.")]
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

        public AddressVM Address { get; set; }
        public AccountVM ParentAccount { get; set; }
        public AccountVM BillingAccount { get; set; }
        public RelationTypeVM RelationType { get; set; }
        public ContactVM PrimaryContact { get; set; }
        public ICollection<ContactVM> Contacts { get; set; }
    }
}
