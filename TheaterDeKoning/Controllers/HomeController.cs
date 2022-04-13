using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TheaterDeKoning.Models;
using MySql.Data;
using TheaterDeKoning.Database;

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

        [Route("Calender")]
        public IActionResult Calender()

        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from product");

            // lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                names.Add(row["naam"].ToString());
            }

            // de lijst met namen in de html stoppen
            return View(names);
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

        [Route("theater-huren")]
        public IActionResult theaterhuren()
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
