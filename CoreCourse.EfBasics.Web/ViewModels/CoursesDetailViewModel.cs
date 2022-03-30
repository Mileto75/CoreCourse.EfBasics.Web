using System.Collections.Generic;

namespace CoreCourse.EfBasics.Web.ViewModels
{
    public class CoursesDetailViewModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Students { get; set; }
        public string Teacher { get; set; }
    }
}
