using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CRM.API.CodeGenerator;
using Microsoft.AspNetCore.Identity;

namespace CRM.API.Models
{
    [CodeGenEntityPluralized("Users")]
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }
    }
}
