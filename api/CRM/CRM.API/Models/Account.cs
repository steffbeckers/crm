using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }

        [MaxLength(50)]
        public string VATNumber { get; set; }

        public string Description { get; set; }

        // Related entities
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }

        public Guid? ParentAccountId { get; set; }
        public Account ParentAccount { get; set; }

        public Guid? BillingAccountId { get; set; }
        public Account BillingAccount { get; set; }

        public Guid? RelationTypeId { get; set; }
        public AccountRelationType RelationType { get; set; }

        public Guid? PrimaryContactId { get; set; }
        public Contact PrimaryContact { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        // Generic
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifiedById { get; set; }
    }
}
