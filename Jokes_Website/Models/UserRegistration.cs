/*===================================================================================
 Jest to model, który służy do rejestracji użytkownika. Przede wszystkim mamy tutaj |
 pierwsze imię oraz nazwisko użyytkownika. Wymagany jest email, podobnie jak hasło, |
 które musi być powtórzone, by sprawdzić poprawność z pierwowzorem.                 |
 ===================================================================================*/

using System.ComponentModel.DataAnnotations;

namespace Jokes_Website.Models
{
    public class UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Powtórzone hasło nie jest zgodne z poprzednim")]
        public string ConfirmPassword { get; set; }
    }
}
