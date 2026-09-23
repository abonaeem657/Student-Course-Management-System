using Microsoft.AspNetCore.Mvc;
using Student_Course_Management_System.Models;

namespace Student_Course_Management_System.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student();
            student.Id = 1;
            student.Name = "Ali";
            student.Major = "CS";
            return View(student);
        }
        public IActionResult Detail(int id)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "mohamed", Major = "CS" });
            students.Add(new Student { Id = 2, Name = "naeem", Major = "AI" });
            students.Add(new Student { Id = 3, Name = "ahmed", Major = "SI" });
            Student student = students.FirstOrDefault(c => c.Id == id);
            return View(student);
        }
    }
}
