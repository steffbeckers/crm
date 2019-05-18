using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.ViewModels
{
    public class CrmExceptionVM
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
