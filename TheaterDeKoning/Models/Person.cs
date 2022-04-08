using System.ComponentModel.DataAnnotations;

namespace TheaterDeKoning.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Vul alstublieft uw voornaam in")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vul alstublieft uw achternaam in")]
        public string Lastname { get; set; }
        [EmailAddress(ErrorMessage = "Vul alstublieft uw emailadres in")]

        [Required(ErrorMessage = "Fill in your email adress please")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul alstublieft uw telefoonnummer in")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vul alstublieft uw adres in")]
        public string Adress { get; set; }
        
        [Required(ErrorMessage = "Vul eventueel iets extra's in")]
        public string Description { get; set; }
        
    }
}