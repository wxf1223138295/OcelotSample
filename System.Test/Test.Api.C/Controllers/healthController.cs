using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Test.Api.C.Controllers
{
    [Route("api/[controller]")]
    public class healthController : Controller
    {
        public healthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        [HttpGet]
        public IActionResult Get() => Ok("ok");

        [HttpPost("/notice")]
        public IActionResult Notice()
        {
            var bytes = new byte[10240];
            var i = Request.Body.Read(bytes, 0, bytes.Length);
            var content = System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');

            EmailSettings settings = new EmailSettings()
            {
                SmtpServer = Configuration["Email:SmtpServer"],
                SmtpPort = Convert.ToInt32(Configuration["Email:SmtpPort"]),
                AuthAccount = Configuration["Email:AuthAccount"],
                AuthPassword = Configuration["Email:AuthPassword"],
                ToWho = Configuration["Email:ToWho"],
                ToAccount = Configuration["Email:ToAccount"],
                FromWho = Configuration["Email:FromWho"],
                FromAccount = Configuration["Email:FromAccount"],
                Subject = Configuration["Email:Subject"]
            };

            EmailHelper.SendHealthEmail(settings, content);

            return Ok();
        }
    }   
}