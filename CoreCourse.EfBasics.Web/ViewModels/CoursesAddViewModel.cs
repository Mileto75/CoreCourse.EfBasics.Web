using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCourse.EfBasics.Web.ViewModels
{
    public class CoursesAddViewModel
    {
        [Required(ErrorMessage = "Please provide a title!")]
        [Display(Name = "Course title")]
        public string Title { get; set; }
        [Display(Name = "Teacher")]
        //One to Many relation course => Teacher
        public IEnumerable<SelectListItem> Teachers { get; set; }
        public int TeacherId { get; set; }
    }
}
