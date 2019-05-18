using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string JobTitle { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string MobilePhone { get; set; }

        public Gender? Gender { get; set; }

        // Related entities
        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        // Generic
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public DateTime? DeletedOn { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifiedById { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
