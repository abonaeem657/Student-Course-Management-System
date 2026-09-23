using Microsoft.AspNetCore.Mvc;
using Student_Course_Management_System.Models;
using Student_Course_Management_System.Data;

namespace Student_Course_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }
        public IActionResult Detail(int id)
        {
            Student? student = _context.Students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Student? student = _context.Students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            Student? oldstu= _context.Students.FirstOrDefault(c=>c.Id==student.Id);
            if (oldstu == null) { return NotFound(); }
            oldstu.Name = student.Name;
            oldstu.Major = student.Major;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Student? student = _context.Students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            Student? student = _context.Students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
