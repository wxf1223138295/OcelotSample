using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Api.CCore.Aggregate;

namespace Test.Api.C.Controllers
{
    public class TestCController : Controller
    {
        [HttpGet]
        public IEnumerable<OtherInfo> Index()
        {
            OtherInfo p1 = new OtherInfo
            {
               Job = "IT",
                Income = 1000,
                JobAddress = "上海"
            };

            OtherInfo p2 = new OtherInfo
            {
                Job = "IT运维",
                Income = 2000,
                JobAddress = "上海"
            };

            List<OtherInfo> list = new List<OtherInfo>();

            list.Add(p1);
            list.Add(p2);

            return list.AsEnumerable();
        }
    }
}