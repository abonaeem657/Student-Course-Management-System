using Microsoft.AspNetCore.Mvc;
using Student_Course_Management_System.Models;

namespace Student_Course_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "mohamed", Major = "CS" },
    new Student { Id = 2, Name = "naeem", Major = "AI" },
    new Student { Id = 3, Name = "ahmed", Major = "SI" }
};
        public IActionResult Index()
        {
            return View(students);
        }
        public IActionResult Detail(int id)
        {
            Student? student = students.FirstOrDefault(c => c.Id == id);
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
            students.Add(student);
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            Student? oldstu=students.FirstOrDefault(c=>c.Id==student.Id);
            if (oldstu == null) { return NotFound(); }
            oldstu.Name = student.Name;
            oldstu.Major = student.Major;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Student? student = students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        [HttpPost]
        public IActionResult Deletee(int id)
        {
            Student? student = students.FirstOrDefault(c => c.Id == id);
            if (student == null) { return NotFound(); }
            students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
