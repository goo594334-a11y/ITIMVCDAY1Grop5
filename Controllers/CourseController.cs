using ITIMVCDAY1Grop5.Data.Context;
using ITIMVCDAY1Grop5.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCDAY1Grop5.Controllers
{
    public class CourseController : Controller
    {
        ITIDbContext Context = new ITIDbContext();

        // 1. /Course/Index
        public IActionResult Index()
        {
            var courses = Context.Courses.Include(c => c.Department).ToList();
            return View(courses);
        }

        // Details
        public IActionResult Details(int id)
        {
            var course = Context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // 2. Add (GET)
        public IActionResult Add()
        {
            var departments = Context.Departments.ToList();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }

        // 2. Add (POST)
        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (course.DepartmentId == 0)
            {
                course.DepartmentId = null;
            }

            Context.Courses.Add(course);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
