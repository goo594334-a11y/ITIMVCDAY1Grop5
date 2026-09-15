using ITIMVCDAY1Grop5.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCDAY1Grop5.Data.Context
{
    public class ITIDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<crsReselt> CrsReselts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Database=MVC_G5 ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

    }
}
