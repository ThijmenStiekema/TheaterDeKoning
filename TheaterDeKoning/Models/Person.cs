using System.ComponentModel.DataAnnotations;

namespace TheaterDeKoning.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Fill in your first name please")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fill in your last name please")]
        public string Lastname { get; set; }
        [EmailAddress(ErrorMessage = "Fill in your email adress please")]
        [Required(ErrorMessage = "Fill in your email adress please")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Fill in your phone number please")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Fill in your name adress please")]
        public string Adress { get; set; }
        
        [Required(ErrorMessage = "Fill in your description please")]
        public string Description { get; set; }
        
    }
}