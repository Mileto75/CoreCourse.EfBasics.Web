using CoreCourse.EfBasics.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.EfBasics.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //create cookieOptions
            var cookieOptions = new CookieOptions 
            {
                Expires = DateTime.UtcNow.AddMinutes(2)
            };
            Response.Cookies.Append("myCookie", "Welcome to the internet", cookieOptions);
            //catch the session vars
            ViewBag.authenticated = HttpContext.Session.GetInt32("authenticated");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Privacy()
        {
            //get the cookie from the request
            //check if cookie exists
            
            if(Request.Cookies.ContainsKey("myCookie"))
            {
                ViewBag.MyCookie = Request.Cookies["myCookie"];
            }
            //delete the cookie
            Response.Cookies.Delete("myCookie");

            return View();
        }

        public IActionResult Login()
        {
            //set a session var LoggedIn and UserName
            HttpContext.Session.SetInt32("authenticated", 1);
            HttpContext.Session.SetString("username", "Kaiju");
            return RedirectToAction("Index");
        }
        
        public IActionResult Logout()
        {
            //kill the session
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
