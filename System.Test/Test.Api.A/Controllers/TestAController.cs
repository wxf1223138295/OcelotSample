using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Api.ACore.Aggregate;

namespace Test.Api.A.Controllers
{
    public class TestAController : Controller
    {
        [HttpGet]
        public IEnumerable<Person> Index()
        {
            Person p1= new Person
            {
                Name = "ShanwWong",
                Address = "南通市",
                Age=27,
                CreateDateTime = DateTime.Now,
                Email = "1223138295@qq.com"
            };

            Person p2 = new Person
            {
                Name = "ShanwWong2",
                Address = "南通市",
                Age = 27,
                CreateDateTime = DateTime.Now,
                Email = "1223138295@qq.com"
            };

            List<Person> list=new List<Person>();

            list.Add(p1);
            list.Add(p2);
           
            return list.AsEnumerable();
        }
    }
}