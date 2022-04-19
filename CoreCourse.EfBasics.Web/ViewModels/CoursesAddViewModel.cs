using CoreCourse.EfBasics.Web.Models;
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
        
        //One to Many relation course => Teacher
        public IEnumerable<SelectListItem> Teachers { get; set; }
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        //students checkboxes
        public List<CheckboxModel> Students { get; set; }
    }
}
