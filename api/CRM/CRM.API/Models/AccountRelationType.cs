using CRM.API.CodeGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    [Table("AccountRelationTypes")]
    [CodeGenEntityPluralized("AccountRelationTypes")]
    public class AccountRelationType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [CodeGenLookupFieldToDisplay(true)]
        public string DisplayName { get; set; }
    }
}
