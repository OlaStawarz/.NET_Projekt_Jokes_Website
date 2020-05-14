/*====================================================================================
Klasa User - użytkownik. Jest to klasa, która przede wszystkim korzysta z Identity.  |
Co istotne - klasa User rozszerza klasę IdentityUser o opcje FirstName oraz          |
LastName.                                                                            |
 ====================================================================================*/


using Microsoft.AspNetCore.Identity;

namespace Jokes_Website.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
