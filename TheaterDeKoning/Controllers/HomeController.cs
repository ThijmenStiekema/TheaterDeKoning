using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TheaterDeKoning.Models;

namespace TheaterDeKoning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        [Route("Contact")]
        public IActionResult Contact(Person person)
        {
            ViewData["firstName"] = person.FirstName;
            ViewData["lastName"] = person.Lastname;
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Privacy")]
            public IActionResult Privacy()
        {
            return View();
        }

        [Route("FAQ")]
        public IActionResult FAQ()
        {
            return View();
        }

        [Route("Vacatures")]
        public IActionResult Vacatures()
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
