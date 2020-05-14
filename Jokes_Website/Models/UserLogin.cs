/*====================================================================================
 Jest to model, który służy do logowania użytkownika. Posiada pole: email oraz hasło.|
 Posiada również funkcję "remember me", czyli opcja zapamiętywania użytkownika.      |
 Logowanie bazuje na danych podanych w rejestracji.                                  |
 ====================================================================================*/

using System.ComponentModel.DataAnnotations;

namespace Jokes_Website.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Pamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
