using System.Collections.Generic;

namespace CoreCourse.EfBasics.Web.ViewModels
{
    public class CoursesIndexViewModel
    {
        public IEnumerable<BaseViewModel> Courses { get; set; }
    }
}
