namespace Nubi.Core.Infrastructure.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Nubi.Core.Domain.Models;

    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);           
            SeedUsers(builder);          

        }

        public DbSet<User> Users { get; set; }

        public static void SeedUsers(ModelBuilder builder)
        {
            for (int i = 1; i < 21; i++)
            {
                builder.Entity<User>().HasData(
                new User
                {
                    Id = i,
                    Nombre = "FirstName" + i,
                    Apellido = "LastName" + i,
                    Email = "email." + i + "@example.com",
                    Password = User.ComputeSha256Hash("Password$" + i)

                }
                );

            }
        }
    }
}
