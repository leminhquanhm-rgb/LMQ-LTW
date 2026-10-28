using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LmqLesson11Lab.Models;
using System.Collections.Generic;
using System.Linq;
using System;
namespace LmqLesson11Lab.Controllers
{
    public class LmqStudentController : Controller
    {
        static List<LmqStudent> listStudents = new List<LmqStudent>();
        public IActionResult Index()
        {
            
            return View(listStudents);
        }

        // GET: Student/Create
        [HttpGet]
        public IActionResult LmqCreate()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public IActionResult LmqCreate(LmqStudent s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Count > 0 ? listStudents.Last().Id + 1 : 1;
                listStudents.Add(s);
               
                return View("Index", listStudents);
            }

            
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View(s);
        }
    }
}
