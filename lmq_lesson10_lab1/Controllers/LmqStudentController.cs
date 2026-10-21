
using lmq_lesson10_lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lmq_lesson10_lab1.Controllers
{
    public class LmqStudentController : Controller
    {
        private static List<LmqStudent> listStudents = new List<LmqStudent>()
        {
            new LmqStudent()
            {
                Id = 101,
                Name = "Lê Minh Quân",
                Branch = LmqBranch.IT,
                Gender = LmqGender.Male,
                IsRegular = true,
                Address = "CNTT2-K65",
                Email = "quan@g.com"
            },
            new LmqStudent()
            {
                Id = 102,
                Name = "Minh Tú",
                Branch = LmqBranch.BE,
                Gender = LmqGender.Female,
                IsRegular = true,
                Address = "A1-2019",
                Email = "tu@g.com"
            },
            new LmqStudent()
            {
                Id = 103,
                Name = "Hoàng Phong",
                Branch = LmqBranch.CE,
                Gender = LmqGender.Male,
                IsRegular = false,
                Address = "A1-2020",
                Email = "phong@g.com"
            },
            new LmqStudent()
            {
                Id = 104,
                Name = "Xuân Mai",
                Branch = LmqBranch.EE,
                Gender = LmqGender.Female,
                IsRegular = false,
                Address = "A1-2021",
                Email = "mai@g.com"
            }
        };

        public IActionResult LmqIndex()
        {
            return View(listStudents);
        }


        [HttpGet]
        public IActionResult LmqCreate()
        {
            ViewBag.AllGenders = Enum.GetValues<LmqGender>();
            return View();
        }

        [HttpPost]
        public IActionResult LmqCreate(LmqStudent s)
        {
            s.Id = listStudents.Max(x => x.Id) + 1;

            listStudents.Add(s);

            return RedirectToAction("LmqIndex");
        }

        public IActionResult List()
        {
            return View("LmqIndex", listStudents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.AllGenders = Enum.GetValues<LmqGender>();
            return View("LmqCreate");
        }

        [HttpPost]
        public IActionResult Add(LmqStudent s)
        {
            s.Id = listStudents.Max(x => x.Id) + 1;
            listStudents.Add(s);

            return RedirectToAction("List");
        }


    }
}
