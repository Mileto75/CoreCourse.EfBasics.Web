using Microsoft.AspNetCore.Mvc;

namespace CoreCourse.EfBasics.Web.Models
{
    public class CheckboxModel
    {
        public bool IsSelected { get; set; }
        [HiddenInput]
        public int Value { get; set; }
        [HiddenInput]
        public string Text { get; set; }
    }
}
