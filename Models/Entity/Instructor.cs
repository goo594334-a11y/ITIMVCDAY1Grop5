using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCDAY1Grop5.Models.Entity
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public Department  Department { get; set; }
        public Course Course { get; set; }


    }
}
