using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public static DateTime Started { get; } = DateTime.UtcNow;
        public static string Version { get; } = typeof(ApiController).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        [HttpGet]
        public IActionResult Info()
        {
            dynamic info = new ExpandoObject();
            info.Started = Started;
            info.Version = Version;

            return Ok(info);
        }
    }
}