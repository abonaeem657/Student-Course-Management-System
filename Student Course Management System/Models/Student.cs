using System.ComponentModel.DataAnnotations;

namespace Student_Course_Management_System.Models
{
    public class Student
    {

        public int Id{ get; set; }
            [Required]
        public string Name { get; set; } = "";
            [Required]
        public string Major { get; set; } = "";
    }
}
