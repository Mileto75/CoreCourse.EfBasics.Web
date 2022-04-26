using CoreCourse.EfBasics.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Services.Interfaces
{
    public interface IFormHelperService
    {
        Task<IEnumerable<SelectListItem>> GetTeachersList();
        Task<List<CheckboxModel>> GetStudentsCheckboxes();
    }
}
