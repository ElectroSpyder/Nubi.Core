using Microsoft.EntityFrameworkCore;
using Nubi.Core.Application.DTO;
using Nubi.Core.Application.Services;
using Nubi.Core.Domain.Models;
using Nubi.Core.Infrastructure.Data.Context;
using Nubi.Core.Infrastructure.Data.Repository;
using NUnit.Framework;
using Xunit;

namespace Nubi.Core.UnitTest
{
    public class UsuarioServiceDeberia
    {
        [Fact]
        public async void AgregarNuevoItem()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<UsuarioDbContext>()
                        .UseInMemoryDatabase(databaseName: "DBInMemory").Options;

            using var context = new UsuarioDbContext(options);
            var service = new UnitOfWork(context);
            var fakeUser = new User
            {
                Id = 1,
                Nombre = "Usuario Test",
                Apellido = "Apellido Test",
                Email = "testc@gmail.com",
                Password = User.ComputeSha256Hash("Passw0rd123$"),
                CreatedAt = System.DateTime.Now,
                IsDeleted = false
            };

            //Act
            await service.UserRepository.Insert(fakeUser);
            await service.SaveChangesAsync();
            var miResult = await service.UserRepository.GetById(1);
            //Assert
            Assert.Equals(1, miResult.Id);
        }

        [Fact]
        public async void DevolverListadoDeUsuarios()
        {
            var options = new DbContextOptionsBuilder<UsuarioDbContext>()
                      .UseInMemoryDatabase(databaseName: "DBInMemory").Options;

            using var context = new UsuarioDbContext(options);
            
            var service = new UnitOfWork(context);
            var miService = new UserService(service);

            var fakeUser = new User
            {
                Id = 1,
                Nombre = "Usuario Test",
                Apellido = "Apellido Test",
                Email = "testc@gmail.com",
                Password = User.ComputeSha256Hash("Passw0rd123$"),
                CreatedAt = System.DateTime.Now,
                IsDeleted = false
            };
            var fakeUserDTO = new UserDTO
            {
                Nombre = "Usuario Test",
                Apellido = "Apellido Test",
                Email = "testc@gmail.com",
                Password = User.ComputeSha256Hash("Passw0rd123$")
            };

            var result = await miService.AddUser(fakeUserDTO);

            
            Assert.IsTrue(result.StatudCode);
        }
    }
}
