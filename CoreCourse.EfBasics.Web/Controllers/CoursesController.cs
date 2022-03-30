using CoreCourse.EfBasics.Web.Data;
using CoreCourse.EfBasics.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CoursesController(SchoolDbContext schoolDbContext)
        {
            //constructor injection
            _schoolDbContext = schoolDbContext;
        }
        public async Task<IActionResult> Index()
        {
            //get the data
            var courses = await _schoolDbContext
                .Courses.ToListAsync();
            //create a viewmodel
            var coursesIndexViewModel = new CoursesIndexViewModel();
            coursesIndexViewModel.Courses = courses.Select(c
                => c.Name);
            //fill the model
            //pass to the view
            return View(coursesIndexViewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            //get the course
            var course = await _schoolDbContext
                .Courses.FirstOrDefaultAsync
                (c => c.Id == id);
            //fill the model
            var coursesDetailViewModel
                = new CoursesDetailViewModel
                {
                    Name = course.Name,
                    Teacher = $"{course.Teacher.Firstname}" +
                    $" {course.Teacher.Lastname}",
                    Students = course.Students.Select
                    (s => $"{s.Firstname} {s.Lastname}")
                };
            //send to the view
            return View(coursesDetailViewModel);
        }
    }
}
