using ITIMVCDAY1Grop5.Models.Entity;

namespace ITIMVCDAY1Grop5.ViewModel
{
    public class InstructorAddViewModel
    {
        public int Id { get; set; }
        public string InsName { get; set; }
        public string InsAddress { get; set; }
        public decimal InsSalary { get; set; }
        public string InsImageUrl { get; set; }
        public int InsDepartmentId { get; set; }
        public int InsCourseId { get; set; }

        public List<Course>  Courses { get; set; }
        public List<Department> Departments { get; set; }

    }
}
