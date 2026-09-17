using System.ComponentModel.DataAnnotations;
using ITIMVCDAY1Grop5.Validation;

namespace ITIMVCDAY1Grop5.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Total Degree is required")]
        [MinDegreeLessThanDegree("MinDegree", ErrorMessage = "Total Degree must be greater than Minimum Degree.")]
        public decimal Degree { get; set; }

        [Required(ErrorMessage = "Minimum Degree is required")]
        [MinDegreeLessThanDegree("Degree", ErrorMessage = "Minimum Degree must be less than Total Degree.")]
        public decimal MinDegree { get; set; }

        [Required(ErrorMessage = "Hours are required")]
        public int Hours { get; set; }

        public int? DepartmentId { get; set; }
    }
}
