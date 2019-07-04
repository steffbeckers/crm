using CRM.API.CodeGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.API.Models
{
    [Table("Accounts")]
    [CodeGenEntityPluralized("Accounts")]
    public class Account
    {
        [Key]
        [CodeGenFieldHidden(true)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [CodeGenInputType(CodeGenInputTypeValues.Text)]
        [CodeGenFieldDisplayName("Account Name")]
        [CodeGenFieldSort(10)]
        public string Name { get; set; }

        [MaxLength(100)]
        [CodeGenInputType(CodeGenInputTypeValues.Email)]
        [CodeGenFieldDisplayName("Email Address")]
        [CodeGenFieldSort(20)]
        public string Email { get; set; }

        [MaxLength(50)]
        [CodeGenInputType(CodeGenInputTypeValues.Telephone)]
        [CodeGenFieldDisplayName("Telephone")]
        public string Telephone { get; set; }

        [MaxLength(50)]
        [CodeGenInputType(CodeGenInputTypeValues.Telephone)]
        [CodeGenFieldDisplayName("FAX")]
        public string Fax { get; set; }

        [MaxLength(200)]
        [CodeGenInputType(CodeGenInputTypeValues.Text)]
        [CodeGenFieldDisplayName("Website URL")]
        public string Website { get; set; }

        [MaxLength(50)]
        [CodeGenInputType(CodeGenInputTypeValues.Text)]
        [CodeGenFieldDisplayName("VAT Number")]
        public string VATNumber { get; set; }

        [CodeGenInputType(CodeGenInputTypeValues.TextArea)]
        [CodeGenFieldDisplayName("Description")]
        public string Description { get; set; }

        // Related entities

        [CodeGenFieldHidden(true)]
        public Guid? AddressId { get; set; }
        [CodeGenInputType(CodeGenInputTypeValues.Lookup)]
        [CodeGenLookupId("addressId")]
        public Address Address { get; set; }

        [CodeGenFieldHidden(true)]
        public Guid? ParentAccountId { get; set; }
        [CodeGenInputType(CodeGenInputTypeValues.Lookup)]
        [CodeGenLookupId("parentAccountId")]
        public Account ParentAccount { get; set; }

        [CodeGenFieldHidden(true)]
        public Guid? BillingAccountId { get; set; }
        [CodeGenInputType(CodeGenInputTypeValues.Lookup)]
        [CodeGenLookupId("billingAccountId")]
        public Account BillingAccount { get; set; }

        [CodeGenFieldHidden(true)]
        public Guid? RelationTypeId { get; set; }
        [CodeGenInputType(CodeGenInputTypeValues.Lookup)]
        [CodeGenLookupId("relationTypeId")]
        public AccountRelationType RelationType { get; set; }

        [CodeGenFieldHidden(true)]
        public Guid? PrimaryContactId { get; set; }
        [CodeGenInputType(CodeGenInputTypeValues.Lookup)]
        [CodeGenLookupId("primaryContactId")]
        public Contact PrimaryContact { get; set; }

        [CodeGenRelationSort(10)]
        public ICollection<Contact> Contacts { get; set; }

        // Generic
        [CodeGenFieldHidden(true)]
        public DateTime CreatedOn { get; set; }

        [CodeGenFieldHidden(true)]
        public DateTime ModifiedOn { get; set; }

        [CodeGenFieldHidden(true)]
        public DateTime? DeletedOn { get; set; }

        [CodeGenFieldHidden(true)]
        public string CreatedById { get; set; }

        [CodeGenLookupId("createdById")]
        [CodeGenFieldDisplayName("Created by")]
        public User CreatedBy { get; set; }

        [CodeGenFieldHidden(true)]
        public string ModifiedById { get; set; }

        [CodeGenLookupId("modifiedById")]
        [CodeGenFieldDisplayName("Last modified by")]
        public User ModifiedBy { get; set; }
    }
}
