using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCDAY1Grop5.Models.Entity
{
    public class crsReselt
    {
        public int Id { get; set; }
        public decimal  Degree { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        [ForeignKey("Trainee")]
        public int? TraineeId { get; set; }

        public Course Course { get; set; }
        public Trainee Trainee { get; set; }



    }
}
