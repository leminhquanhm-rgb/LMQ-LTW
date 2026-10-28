
using LmqLesson11Lab4_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LmqLesson11Lab4_DBFirst.Controllers
{
    public class LearnersController : Controller
    {
        private readonly LmqSchoolContext _context;

        public LearnersController(LmqSchoolContext context)
        {
            _context = context;
        }

        // GET: Learners
        public async Task<IActionResult> Index()
        {
            var learners = await _context.Learners
                .Include(l => l.Major)
                .ToListAsync();

            return View(learners);
        }

        // GET: Learners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(m => m.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            ViewData["MajorId"] = new SelectList(
                _context.Majors,
                "MajorId",
                "MajorName");

            return View();
        }

        // POST: Learners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("LearnerId,LastName,FirstMidName,EnrollmentDate,MajorId")]
            Learner learner)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Learners.Add(learner);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",
                        ex.InnerException?.Message ?? ex.Message);
                }
            }

            ViewData["MajorId"] = new SelectList(
                _context.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId);

            return View(learner);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners.FindAsync(id);

            if (learner == null)
            {
                return NotFound();
            }

            ViewData["MajorId"] = new SelectList(
                _context.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId);

            return View(learner);
        }

        // POST: Learners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("LearnerId,LastName,FirstMidName,EnrollmentDate,MajorId")]
            Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }

                    throw;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",
                        ex.InnerException?.Message ?? ex.Message);
                }
            }

            ViewData["MajorId"] = new SelectList(
                _context.Majors,
                "MajorId",
                "MajorName",
                learner.MajorId);

            return View(learner);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .Include(l => l.Major)
                .FirstOrDefaultAsync(m => m.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learners.FindAsync(id);

            if (learner != null)
            {
                try
                {
                    _context.Learners.Remove(learner);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("",
                        "Không thể xóa sinh viên này vì sinh viên có dữ liệu đăng ký học liên quan.");

                    return View("Error");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // Kiểm tra sinh viên có tồn tại hay không
        private bool LearnerExists(int id)
        {
            return _context.Learners.Any(e => e.LearnerId == id);
        }
    }
}
