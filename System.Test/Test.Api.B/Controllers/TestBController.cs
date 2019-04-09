using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Api.BCore.Aggregate;

namespace Test.Api.B.Controllers
{
    public class TestBController : Controller
    {
        [HttpGet]
        public IEnumerable<Student> Index()
        {
            Student p1 = new Student
            {
                Name = "ShanwWong",
                Grade = "二年级",
                TotalScore = 135,
                Sex = "男"
            };

            Student p2 = new Student
            {
                Name = "ShanwWong2",
                Grade = "二年级",
                TotalScore = 135,
                Sex = "女"
            };

            List<Student> list = new List<Student>();

            list.Add(p1);
            list.Add(p2);

            return list.AsEnumerable();
        }
    }
}