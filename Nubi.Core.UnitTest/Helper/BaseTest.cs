namespace Nubi.Core.UnitTest.Helper
{
    using Microsoft.EntityFrameworkCore;
    using Nubi.Core.Domain.Models;
    using Nubi.Core.Infrastructure.Data.Context;
    using System.Collections.Generic;

    public class BaseTest
    {

        protected UsuarioDbContext MakeContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<UsuarioDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;
            var dbcontext = new UsuarioDbContext(opciones);
            return dbcontext;
        }

        public IEnumerable<User> GetUser()
        {
            var listUser = new List<User>();
            for (int i = 1; i < 21; i++)
            {
                listUser.Add
                (
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

            return listUser;
        }
    }
}
