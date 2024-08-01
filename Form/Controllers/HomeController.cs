using Form.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;
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
            var json = JsonConvert.SerializeObject(form,Newtonsoft.Json.Formatting.Indented);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Storge" ,"Info.txt");
            System.IO.File.WriteAllText(path, json);
           

            return RedirectToAction("Subscription");
        }
        public IActionResult Rules()
        {
            return View();
        }

    }
}


