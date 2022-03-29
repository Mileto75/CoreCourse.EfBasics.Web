using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }//primary key by convention
       
        public string Name { get; set; }
        public Teacher Teacher { get; set; }//course has only one teacher
        public int? TeacherId { get; set; }//unshadow teacher id in database
        public ICollection<Student> Students { get; set; }// one course has many students
    }
}
