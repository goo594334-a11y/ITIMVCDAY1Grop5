namespace ITIMVCDAY1Grop5.Models.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Mangager { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Trainee> trainees { get; set; }

    }
}
