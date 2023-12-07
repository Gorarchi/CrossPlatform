using Microsoft.AspNetCore.Mvc;
using ArcevLabs;
using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Controllers
{
    public class LabsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Lab1()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab1(string input_file, string output_file) => ArcevLabs.Lab1.Execute(input_file, output_file);

        
        [Authorize]
        public IActionResult Lab2()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab2(string input_file, string output_file) => ArcevLabs.Lab2.Execute(input_file, output_file);


        [Authorize]
        public IActionResult Lab3()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public string Lab3(string input_file, string output_file) => ArcevLabs.Lab3.Execute(input_file, output_file);
    }
}
