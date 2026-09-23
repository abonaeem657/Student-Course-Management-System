using Microsoft.AspNetCore.Mvc;
using Student_Course_Management_System.Models;
using Student_Course_Management_System.Data;

namespace Student_Course_Management_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   List<Course> courses = _context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            Course? course= _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) { return NotFound(); }
            return View(course);
        }
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creat(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
