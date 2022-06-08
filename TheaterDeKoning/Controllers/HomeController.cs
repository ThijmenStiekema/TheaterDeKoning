using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TheaterDeKoning.Models;
using MySql.Data;
using TheaterDeKoning.Database;
using TheaterDeKoning.DataBase;

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
            if (ModelState.IsValid) { 
                
                DatabaseConnector.SavePerson(person);
                
                return Redirect("/succes");
            }

            return View(person);
        }

        public IActionResult Index()
        {
            var voorstellingen = GetAllVoorstellingen();
            return View(voorstellingen);
        }

        [Route("Calender")]
        public IActionResult Calender(string week)
        {
            
            var voorstellingen = GetAllVoorstellingen();

            return View(voorstellingen);
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

        [Route("voorstelling/{naam_id}")]
        public IActionResult voorstelling(int naam_id)
        {
            List<Voorstelling> voorstellingen = GetAllVoorstellingen();
            List<Voorstelling> optredens = new List<Voorstelling>();
            foreach (var voorstelling in voorstellingen)
            {
                if (voorstelling.naam_id == naam_id)
                {optredens.Add(voorstelling);}
            }
            return View(optredens);
        }

        public List<Voorstelling> GetAllVoorstellingen()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * , WEEK(datum) from voorstelling INNER JOIN naam_voorstelling ON voorstelling.naam_id = naam_voorstelling.id ORDER BY `voorstelling`.`id` ASC");

            // lijst maken om alle producten in te stoppen
            List<Voorstelling> voorstellingen = new List<Voorstelling>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Voorstelling p = new Voorstelling();
                p.id = Convert.ToInt32(row["id"]);
                p.naam_id = Convert.ToInt32(row["naam_id"]);
                p.naam = row["naam"].ToString();
                p.datum = row["datum"].ToString().Split()[0];
                p.Tijdvak= row["Tijdvak"].ToString();
                p.Zaal = Convert.ToInt32(row["Zaal"]);
                p.beschrijving = row["beschrijving"].ToString();
                p.Poster = row["Poster"].ToString();

                // en dat product voegen we toe aan de lijst met producten
                voorstellingen.Add(p);
            }

            return voorstellingen;
        }

        public Voorstelling GetVoorstelling(int naam_id)
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows($"select * from voorstelling INNER JOIN naam_voorstelling ON voorstelling.naam_id = naam_voorstelling.id WHERE naam_id = {naam_id}");

            // lijst maken om alle producten in te stoppen
            List<Voorstelling> voorstellingen = new List<Voorstelling>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Voorstelling p = new Voorstelling();
                p.id = Convert.ToInt32(row["id"]);
                p.naam_id = Convert.ToInt32(row["naam_id"]);
                p.naam = row["naam"].ToString();
                p.datum = row["datum"].ToString().Split()[0];
                p.Tijdvak = row["Tijdvak"].ToString();
                p.Zaal = Convert.ToInt32(row["Zaal"]);
                p.beschrijving = row["beschrijving"].ToString();
                p.Poster = row["Poster"].ToString();

                // en dat product voegen we toe aan de lijst met producten
                voorstellingen.Add(p);
            }

            return voorstellingen[0];
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
