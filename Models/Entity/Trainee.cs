using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCDAY1Grop5.Models.Entity
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<crsReselt> crsReselts { get; set; }

    }
}
