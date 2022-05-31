using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterDeKoning.DataBase
{
    public class Voorstelling
    {
        public int id { get; set; }
        public string naam { get; set; }
        public string datum { get; set; }
        public string Tijdvak { get; set; }
        public int Zaal { get; set; }
        public string beschrijving { get; set; }
        public string Poster { get; set; }
    }
}
