using CoreCourse.EfBasics.Core.Entities;
using CoreCourse.EfBasics.Web.Data;
using CoreCourse.EfBasics.Web.Models;
using CoreCourse.EfBasics.Web.Services.Interfaces;
using CoreCourse.EfBasics.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly IFormHelperService _formHelperService;

        public CoursesController(SchoolDbContext schoolDbContext,
            IFormHelperService formHelperService)
        {
            //constructor injection
            _schoolDbContext = schoolDbContext;
            _formHelperService = formHelperService;
        }
        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            //get the course
            var course = await _schoolDbContext
                .Courses
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .FirstOrDefaultAsync
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
        [HttpGet]
        public async Task<IActionResult> AddTest()
        {
            
            //follows oop principles
            //add a new course
            Course newCourse = new Course();
            newCourse.Name = "Basic It skills";
            newCourse.TeacherId = 2;
            //get the students
            var students = await _schoolDbContext.Students.ToListAsync();
            newCourse.Students = students;
            //add dbcontext
            await _schoolDbContext.Courses.AddAsync(newCourse);
            //save to the database
            try {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                //log the exception
                Console.WriteLine(ex.Message);
                return View("Error");
            }

            
            return Content("Added");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //viewmodel
            //create the teacher dropdown
            CoursesAddViewModel coursesAddViewModel = new();
            coursesAddViewModel.Teachers = await _formHelperService.GetTeachersList();
            //create the students checkboxes
            coursesAddViewModel.Students = await _formHelperService.GetStudentsCheckboxes();
            return View(coursesAddViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CoursesAddViewModel coursesAddViewModel)
        {
            //validate the data
            if(!ModelState.IsValid)//validation error
            {
                //repopulate the teachers list
                coursesAddViewModel.Teachers = await _formHelperService
                    .GetTeachersList();
                return View(coursesAddViewModel);
            }
            //store in database
            //create a new entity
            var newCourse = new Course();
            newCourse.Name = coursesAddViewModel.Title;
            //add teacherId
            newCourse.TeacherId = coursesAddViewModel?.TeacherId;
            //add students
            //get the selected students and generate a list of int
            var selectedStudents = coursesAddViewModel.Students
                .Where(s => s.IsSelected == true).Select(s => s.Value);
            //get the students from the database
            //filter the students based on selected students using contains
            newCourse.Students = await _schoolDbContext
                .Students
                .Where(st => selectedStudents.Contains(st.Id)).ToListAsync();
            
            //add to the database context
            await _schoolDbContext.Courses.AddAsync(newCourse);
            //save to the database
            try 
            {
                await _schoolDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) 
            { 
                //in production log the error
                Console.WriteLine(ex.Message);
                //fill modelstate with custom error
                ModelState.AddModelError("", "Something went wrong...");
                return View(coursesAddViewModel);
            }
            
            //redirect to index
            return RedirectToAction("index");
        }
    }
}
