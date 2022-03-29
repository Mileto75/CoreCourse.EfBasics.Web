using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Core.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        public ContactInfo ContactInfo { get; set; }//navigation property
        public ICollection<Course> Courses { get; set; }//teacher has many courses
        public Department Department { get; set; }//teacher has onn department
        public int? DepartmentId { get; set; }//unshadowed property
    }
}
