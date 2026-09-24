using Lmq_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace Lmq_Lab1.Controllers
{
    public class LmqStudentController : Controller
    {
        private List<LmqStudent> lmqListStudents = new List<LmqStudent>();
        public LmqStudentController() {
            // Tạo danh sách sinh viên 
            lmqListStudents = new List<LmqStudent>() 
            {
                new LmqStudent() { Id = 101, Name = "Minh Quân", Branch = LmqBranch.IT,
                    Gender = LmqGender.Male, IsRegular=true,
                    Address = "A1-2018", Email = "Quan@g.com" },

                new LmqStudent() { Id = 102, Name = "Minh Tú", Branch = LmqBranch.BE,
                    Gender = LmqGender.Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com"},
                   
                
                new LmqStudent() { Id = 103, Name = "Hoàng Phong", Branch = LmqBranch.CE,
                    Gender = LmqGender.Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com" },

                new LmqStudent() { Id = 104, Name = "Xuân Mai", Branch = LmqBranch.EE,
                    Gender = LmqGender.Female, IsRegular = false,             
                    Address = "A1-2021", Email = "mai@g.com" }
            };
        }

        public IActionResult lmqIndex()
        {
            //Trả về View Index.cshtml cùng Model là danh sách sv listStudents
            return View(lmqListStudents);
        }

        // Create

        [HttpGet]
        public IActionResult lmqCreate() 
        {
            
            //lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(LmqGender)).Cast<LmqGender>().ToList(); 
            //lấy dạnh sách các giá trị Branch để hiển thị select-option trên form
            //Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult lmqCreate(LmqStudent s)
        {
            s.Id = lmqListStudents.Max(st => st.Id) + 1;

            lmqListStudents.Add(s);

            return View("lmqIndex", lmqListStudents);
        }




    }
}
