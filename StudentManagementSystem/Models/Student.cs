using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentCourse { get; set; }
    }
}
