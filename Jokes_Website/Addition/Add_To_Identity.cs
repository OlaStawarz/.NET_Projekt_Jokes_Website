/*====================================================================================
Klasa CustomClaimsFactory. Jest to klasa, która przede wszystkim ma za zadanie       |
by dodać do klasy IdentityUser niestandardowe opcje, czyli takie jak FirstName       |
oraz LastName. Podstawowe opcje nie zawierają ich, także przez tą klase musimy je    |
obsłużyć.                                                                            |
 ====================================================================================*/

using Jokes_Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jokes_Website.Addition
{
    public class Add_To_Identity : UserClaimsPrincipalFactory<User>
    {
        public Add_To_Identity(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("firstname", user.FirstName));
            identity.AddClaim(new Claim("lastname", user.LastName));

            return identity;
        }
    }
}
