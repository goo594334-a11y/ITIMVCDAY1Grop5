using ITIMVCDAY1Grop5.Data.Context;
using ITIMVCDAY1Grop5.Models.Entity;
using ITIMVCDAY1Grop5.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCDAY1Grop5.Controllers
{
    public class InstructorController : Controller
    {
        ITIDbContext Context = new ITIDbContext();
        public IActionResult Index()
        {
            string NameUser = "Yousef Ali Zakary Abo Khallaf ";

            var instructors = Context.Instructors.Include(i => i.Department).Include(i => i.Course).ToList();

            InsDataAllNameDepartmentNameCourse AllData = new InsDataAllNameDepartmentNameCourse()
            {
                Instructors = instructors,
                NameUser = NameUser
            };

            return View(AllData);
        }

        public IActionResult Details(int id)
        {
            var Dept= Context.Departments.FirstOrDefault(d => d.Id == id);
            var Course = Context.Courses.FirstOrDefault(c => c.Id == id);
            var instructor = Context.Instructors.FirstOrDefault(i => i.Id == id);
            InsDataCoursNameDepartmentNameVewModel Insdata = new InsDataCoursNameDepartmentNameVewModel()
            {
                InsId = instructor.Id,
                InsName = instructor.Name,
                InsSalary = instructor.Salary,
                Address = instructor.Address,
                CourseName = Course?.Name ?? "No Course",
                DepartmentName = Dept?.Name ?? "No Department"
            };
          
            return View(Insdata);
        }


        public IActionResult Add()
        {
            var Departments = Context.Departments.ToList();
            var Courses = Context.Courses.ToList();
            InstructorAddViewModel Model = new InstructorAddViewModel()
            {
                Departments = Departments,
                Courses = Courses
            };
            return View("Add", Model);
        }

        [HttpPost]
        public IActionResult Add(InstructorAddViewModel model)
        {
            var instructor = new Instructor()
            {
                Name = model.InsName,
                Address = model.InsAddress,
                Salary = model.InsSalary,
                ImageUrl = model.InsImageUrl,
                DepartmentId = model.InsDepartmentId,
                CourseId = model.InsCourseId
            };
            Context.Instructors.Add(instructor);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var instructor = Context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            var model = new InstructorAddViewModel()
            {
                Id = instructor.Id,
                InsName = instructor.Name,
                InsAddress = instructor.Address,
                InsSalary = instructor.Salary,
                InsImageUrl = instructor.ImageUrl,
                InsDepartmentId = instructor.DepartmentId ?? 0,
                InsCourseId = instructor.CourseId ?? 0,

                Departments = Context.Departments.ToList(),
                Courses = Context.Courses.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit( InstructorAddViewModel model)
        {
        
            var instructor = Context.Instructors.FirstOrDefault(i => i.Id ==model.Id);

            if (instructor == null)
            {
                return NotFound();
            }

            instructor.Name = model.InsName;
            instructor.Address = model.InsAddress;
            instructor.Salary = model.InsSalary;
            instructor.ImageUrl = model.InsImageUrl;
            instructor.DepartmentId = model.InsDepartmentId;
            instructor.CourseId = model.InsCourseId;

            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
