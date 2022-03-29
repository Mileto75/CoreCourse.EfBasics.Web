using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Core.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        
        public string Email { get; set; }
        public int? TeacherId { get; set; }//unshadow property
        public Teacher Teacher { get; set; }//navigation property
    }
}
