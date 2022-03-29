using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Core.Entities
{
    public class Student
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        public ICollection<Course> Courses { get; set; }//one student has many courses
    }
}
