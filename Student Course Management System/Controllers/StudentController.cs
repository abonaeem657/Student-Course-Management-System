using Microsoft.AspNetCore.Mvc;
using Student_Course_Management_System.Models;

namespace Student_Course_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>
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
    }
}
