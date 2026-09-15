using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCDAY1Grop5.Models.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        public int Hours { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<crsReselt> CrsReselts { get; set; }

    }
}
