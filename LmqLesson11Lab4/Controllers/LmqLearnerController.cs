using LmqLesson11Lab4.Data;
using LmqLesson11Lab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LmqLesson11Lab4.Controllers
{
    public class LmqLearnerController : Controller
    {
        private readonly LmqSchoolContext db;

        public LmqLearnerController(LmqSchoolContext context)
        {
            db = context;
        }

        // READ: Hiển thị danh sách Learner
        public IActionResult Index()
        {
            var learners = db.Learners
                .Include(l => l.Major)
                .ToList();

            return View(learners);
        }

        // CREATE - GET: Hiển thị form thêm sinh viên
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(
                db.Majors,
                "MajorID",
                "MajorName"
            );

            return View();
        }

        // CREATE - POST: Lưu sinh viên mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("FirstMidName,LastName,MajorID,EnrollmentDate")]
            LmqLearner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Nạp lại danh sách chuyên ngành nếu dữ liệu không hợp lệ
            ViewBag.MajorID = new SelectList(
                db.Majors,
                "MajorID",
                "MajorName",
                learner.MajorID
            );

            return View(learner);
        }

        // EDIT - GET: Lấy thông tin sinh viên cần sửa
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);

            if (learner == null)
            {
                return NotFound();
            }

            ViewBag.MajorID = new SelectList(
                db.Majors,
                "MajorID",
                "MajorName",
                learner.MajorID
            );

            return View(learner);
        }

        // EDIT - POST: Cập nhật thông tin sinh viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")]
        LmqLearner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorID = new SelectList(
                db.Majors,
                "MajorID",
                "MajorName",
                learner.MajorID
            );

            return View(learner);
        }

        // Kiểm tra sinh viên có tồn tại không
        private bool LearnerExists(int id)
        {
            return db.Learners.Any(e => e.LearnerID == id);
        }

        // DETAILS
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var learner = db.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefault(l => l.LearnerID == id);

            if (learner == null)
                return NotFound();

            return View(learner);
        }



        // DELETE - GET: Hiển thị thông tin sinh viên trước khi xóa
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                .FirstOrDefault(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            // Kiểm tra sinh viên đã đăng ký môn học chưa
            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        // DELETE - POST: Xác nhận xóa sinh viên
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var learner = db.Learners.Find(id);

            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}