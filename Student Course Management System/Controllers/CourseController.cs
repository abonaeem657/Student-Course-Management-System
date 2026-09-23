using Microsoft.AspNetCore.Mvc;

namespace Student_Course_Management_System.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
