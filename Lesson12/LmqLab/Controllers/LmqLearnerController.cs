
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmqLab.Data;
using LmqLab.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LmqLab.Controllers
{
    public class LmqLearnerController : Controller
    {
        private readonly LmqSchoolContext db;

        public LmqLearnerController(LmqSchoolContext context)
        {
            db = context;
        }


        // Khai báo biến toàn cục 
        private int pageSize = 3;

        public IActionResult Index(int? mid)
        {
            var learners = db.Learners
                .Include(l => l.Major)
                .AsQueryable();

            // Nếu có mã ngành thì lọc theo ngành
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorId == mid);
            }

            // Tính tổng số trang
            int pageNum = (int)Math.Ceiling(
                learners.Count() / (float)pageSize
            );

            ViewBag.pageNum = pageNum;
            ViewBag.mid = mid;

            // Lấy 3 Learner đầu tiên
            var result = learners
                .Take(pageSize)
                .ToList();

            return View(result);
        }



        public IActionResult LmqLearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            // Lấy danh sách Learner
            var learners = db.Learners.AsQueryable();

            // Lấy số trang, mặc định là trang 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);

            // Lọc theo ngành học
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorId == mid);
                ViewBag.mid = mid;
            }

            // Tìm kiếm theo tên
            if (keyword != null)
            {
                learners = learners.Where(l =>
                    l.FirstMidName.ToLower().Contains(keyword.ToLower()));

                ViewBag.keyword = keyword;
            }

            // Tính tổng số trang
            int pageNum = (int)Math.Ceiling(
                learners.Count() / (float)pageSize
            );

            ViewBag.pageNum = pageNum;

            // Lấy dữ liệu của trang hiện tại
            var result = learners
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Include(l => l.Major)
                .ToList();

            return PartialView("LmqLearnerTable", result);
        }



        public IActionResult LmqFilterLearners(int? mid)
        {
            var learners = db.Learners
                .Include(l => l.Major)
                .ToList();

            if (mid != null)
            {
                learners = learners
                    .Where(l => l.MajorId == mid)
                    .ToList();
            }

            return PartialView("LmqLearnerTable", learners);
        }


        public IActionResult Create()
        {
            ViewBag.MajorId = new SelectList(
                db.Majors,
                "MajorId",
                "MajorName"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.MajorId = new SelectList(
                db.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId
            );

            return View(learner);
        }

        // GET: Hiển thị form sửa
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

            ViewBag.MajorId = new SelectList(
                db.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId
            );

            return View("LmqEdit", learner);
        }

        // POST: Lưu thông tin sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            ModelState.Remove("Major");

            if (ModelState.IsValid)
            {
                var oldLearner = db.Learners.Find(id);

                if (oldLearner == null)
                {
                    return NotFound();
                }

                oldLearner.FirstMidName = learner.FirstMidName;
                oldLearner.LastName = learner.LastName;
                oldLearner.EnrollmentDate = learner.EnrollmentDate;
                oldLearner.MajorId = learner.MajorId;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.MajorId = new SelectList(
                db.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId
            );

            return View("LmqEdit", learner);
        }

        // GET: Hiển thị xác nhận xóa
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                .Include(l => l.Major)
                .FirstOrDefault(l => l.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View("LmqDelete", learner);
        }

        // POST: Thực hiện xóa
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

            return RedirectToAction("Index");
        }
    }
}
