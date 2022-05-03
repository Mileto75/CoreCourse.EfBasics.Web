using CoreCourse.EfBasics.Web.Data;
using CoreCourse.EfBasics.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public ShoppingCartController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {
            //create viewmodel
            var shoppingCartViewModel = new ShoppingCartViewModel();
            //init list
            shoppingCartViewModel.Courses = new List<BaseViewModel>();
            //show the items in the cart
            //get the list from the session
            if(HttpContext.Session.Keys.Contains("courses"))
            {
                //deserialize list and put in viewModel
                shoppingCartViewModel.Courses =
                    JsonConvert
                    .DeserializeObject<List<BaseViewModel>>(HttpContext.Session.GetString("courses"));
            }

            //send to view
            return View(shoppingCartViewModel);
        }
        public async Task<IActionResult> Add(int id)
        {
            List<BaseViewModel> courses = new List<BaseViewModel>();
            //get the course
            var course = await _schoolDbContext.Courses
                .FirstOrDefaultAsync(c => c.Id == id);
            //check if null
            if(course == null)
            {
                return NotFound();
            }
            //get the session data(list of viewModels)
            //check if session exists
            if(HttpContext.Session.Keys.Contains("courses"))
            {
                //get the courses session
                courses = JsonConvert
                    .DeserializeObject<List<BaseViewModel>>
                    (HttpContext.Session.GetString("courses"));
            }
            //add course to list
            courses.Add(new BaseViewModel { Id = course.Id, Name = course.Name });
            //serialize list add list to session
            HttpContext.Session.SetString("courses", JsonConvert.SerializeObject(courses));
            //redirect to index
            return RedirectToAction("Index");
        }
    }
}
