using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmit.Models;
using Microsoft.AspNetCore.Http;

namespace FormSubmit.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(User newUser)
        {
            if(ModelState.IsValid)
            {
                HttpContext.Session.SetString("Name", newUser.Name);
                HttpContext.Session.SetInt32("Age", (int)newUser.Age);
                
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Logout");
            }
            int? age = HttpContext.Session.GetInt32("Age");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Age = HttpContext.Session.GetInt32("Age");
            return View();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
