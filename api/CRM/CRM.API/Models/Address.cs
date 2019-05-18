using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        [MaxLength(80)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string PostalCode { get; set; }

        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(9, 6)")]
        public decimal? Longitude { get; set; }

        public Guid? CountryId { get; set; }
        public Country Country { get; set; }

        // Generic
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public DateTime? DeletedOn { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifiedById { get; set; }
    }
}
