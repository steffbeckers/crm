using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Framework
{
    public class CrmException : Exception
    {
        public string Title { get; set; }
        public int Status { get; set; }

        public CrmException()
        {}

        public CrmException(string title)
        {
            Title = title;
        }

        public CrmException(string title, int status)
        {
            Title = title;
            Status = status;
        }
    }
}
