using Lmq_lesson6_Model.Views.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Lmq_lesson6_Model.Controllers
{
    public class MemberController : Controller
    {
        // Mock data

        private static readonly List<Member> _LmqMembers = new List<Member>()
        {
            new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "MinhQuan",
                    Fullname = "Lê Minh Quân",
                    Password = "lmq123456",
                    Email = "lmq@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member2",
                    Fullname = "Thành viên 2",
                    Password = "123456",
                    Email = "lmq2@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member3",
                    Fullname = "Thành viên 3",
                    Password = "123456",
                    Email = "lmq3@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member4",
                    Fullname = "Thành viên 4",
                    Password = "123456",
                    Email = "lmq4@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member5",
                    Fullname = "Thành viên 5",
                    Password = "123456",
                    Email = "lmq5@gmail.com"
                }
        };

        // Get: List
        public IActionResult LmqIndex()
        {
            return View(_LmqMembers);
        }

        /// <summary>
        /// Create
        /// </summary>
        
        public IActionResult LmqCreate()
        {
            return View();
        }

        // Create submit form
        [HttpPost]
        public IActionResult LmqCreate(Member lmqMember)
        {
            lmqMember.MemberId = Guid.NewGuid().ToString();
            _LmqMembers.Add(lmqMember);
            return RedirectToAction("LmqIndex");
        }

        // Edit
        public IActionResult LmqEdit( string id)
        {
            var lmqMember = _LmqMembers.FirstOrDefault(x => x.MemberId.Equals(id));

            return View(lmqMember);
        }

        // Create submit form
        [HttpPost]
        public IActionResult LmqEdit(string id, Member lmqMember)
        {
            for(int i = 0; i < _LmqMembers.Count; i++)
            {
                if(_LmqMembers[i].MemberId == id)
                {
                    _LmqMembers[i].MemberId = lmqMember.MemberId;
                    _LmqMembers[i].Username = lmqMember.Username;
                    _LmqMembers[i].Fullname = lmqMember.Fullname;
                    _LmqMembers[i].Password = lmqMember.Password;
                    _LmqMembers[i].Email = lmqMember.Email;

                    break;
                }
               
            }


            return RedirectToAction("LmqIndex");
        }



        public IActionResult GetMembers()
        {
            List<Member> members = new List<Member>()
            {
                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member1",
                    Fullname = "Thành viên 1",
                    Password = "123456",
                    Email = "lmq1@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member2",
                    Fullname = "Thành viên 2",
                    Password = "123456",
                    Email = "lmq2@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member3",
                    Fullname = "Thành viên 3",
                    Password = "123456",
                    Email = "lmq3@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member4",
                    Fullname = "Thành viên 4",
                    Password = "123456",
                    Email = "lmq4@gmail.com"
                },

                new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = "member5",
                    Fullname = "Thành viên 5",
                    Password = "123456",
                    Email = "lmq5@gmail.com"
                }
            };

            ViewBag.members = members;

            return View();
        }

/// ------------------------------------------------------
        public IActionResult LmqGetDetail()
        {
            var lmqMember = new Member()
            {
                MemberId = Guid.NewGuid().ToString() ,
                Username = "leminhquan",
                Fullname = "Lê Minh Quân",
                Password = "lmq123456",
                Email = "leminhquan@gmail.com"
            };

            return View(lmqMember);

        }





    }
}