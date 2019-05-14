using CRM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels
{
    public class AccountVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
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
