using Form.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace Form.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Subscription()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Subscription(FormViewModel form)
        {
            if (!ModelState.IsValid || !form.IsValidAge())
            {
                if (!form.IsValidAge())
                {
                    ModelState.AddModelError(nameof(form.BirthDate), "You must be at least 18 years old.");
                }
                return View("Subscription", form);
            }

            return Json(form);

        }
        public IActionResult Rules()
        {
            return View();
        }

    }
}


