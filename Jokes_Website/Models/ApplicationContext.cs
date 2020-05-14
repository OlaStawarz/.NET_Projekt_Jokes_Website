/*====================================================================================
 Klasa ApplicationContext - służąca do obsługi bazy danych. Klasa ta dziedziczy po   |
 IdentityDbContext, dlatego że musi ona być połączona z tożsamością. Dodatkowo       |
 widać, że została tutaj użyta konfiguracja roli - użytkownik oraz administator.     |
 ====================================================================================*/

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jokes_Website.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        
    }
}
