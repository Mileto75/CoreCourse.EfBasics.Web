using CoreCourse.EfBasics.Web.Data;
using CoreCourse.EfBasics.Web.Models;
using CoreCourse.EfBasics.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Services
{
    public class FormHelperService : IFormHelperService
    {
        //declare dbContext
        private readonly SchoolDbContext _schoolDbContext;

        public FormHelperService(SchoolDbContext dbContext)
        {
            //inject dbContext
            _schoolDbContext = dbContext;
        }

        public async Task<List<CheckboxModel>> GetStudentsCheckboxes()
        {
            //get the students
            var students = await _schoolDbContext.Students.ToListAsync();
            return students.Select(s => new CheckboxModel
            {
                Value = s.Id,
                Text = $"{s.Firstname} {s.Lastname}"
            }).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetTeachersList()
        {
            //get the teachers
            var teachers = await _schoolDbContext.Teachers.ToListAsync();
            //return selectListItem list
            return teachers.Select(t => new SelectListItem {
             Value = t.Id.ToString(),Text = $"{t.Firstname} {t.Lastname}"});
        }
    }
}
