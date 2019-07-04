using CRM.API.CodeGenerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Models
{
    [Table("Countries")]
    [CodeGenEntityPluralized("Countries")]
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string NativeName { get; set; }

        [MaxLength(2)]
        public string Alpha2Code { get; set; }

        [MaxLength(3)]
        public string Alpha3Code { get; set; }

        //private string callingCodes;

        //[NotMapped]
        //public JObject CallingCodes {
        //    get {
        //        return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(callingCodes) ? "[]" : callingCodes);
        //    }
        //    set {
        //        callingCodes = value.ToString();
        //    }
        //}

        public string Capital { get; set; }

        public string Region { get; set; }

        public string Subregion { get; set; }

        public string NumericCode { get; set; }

        public string Flag { get; set; }
    }
}
