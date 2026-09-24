using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Course_Management_System.Data;
using Student_Course_Management_System.Models;
namespace Student_Course_Management_System.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var enrollments = _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .ToList();
            return View(enrollments);
        }
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Students = _context.Students.ToList();
                ViewBag.Courses = _context.Courses.ToList();

                return View(enrollment);
            }
            bool exists = _context.Enrollments.
                Any(e =>e.StudentId == enrollment.StudentId &&e.CourseId == enrollment.CourseId);

            if (exists)
            {
                ViewBag.Students = _context.Students.ToList();
                ViewBag.Courses = _context.Courses.ToList();

                ModelState.AddModelError("", "This student is already enrolled in this course.");

                return View(enrollment);
            }

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Enrollment? enrollment = _context.Enrollments
        .Include(e => e.Student)
        .Include(e => e.Course)
        .FirstOrDefault(e => e.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Enrollment? enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Enrollment? enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(enrollment);
        }
        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            Enrollment? oldE = _context.Enrollments
                .FirstOrDefault(e => e.Id == enrollment.Id);

            if (oldE == null)
            {
                return NotFound();
            }

            bool exists = _context.Enrollments.Any(e =>
                e.StudentId == enrollment.StudentId &&
                e.CourseId == enrollment.CourseId &&
                e.Id != enrollment.Id);

            if (exists)
            {
                ViewBag.Students = _context.Students.ToList();
                ViewBag.Courses = _context.Courses.ToList();

                ModelState.AddModelError("", "This student is already enrolled in this course.");

                return View(enrollment);
            }

            oldE.StudentId = enrollment.StudentId;
            oldE.CourseId = enrollment.CourseId;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
