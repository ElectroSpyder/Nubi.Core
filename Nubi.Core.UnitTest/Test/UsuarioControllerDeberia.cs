using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nubi.Core.Api.Rest.Controllers;
using Nubi.Core.Application.DTO;
using Nubi.Core.Application.Services;
using Nubi.Core.Domain.Interfaces;
using Nubi.Core.Domain.Models;
using Nubi.Core.Infrastructure.Data.Context;
using Nubi.Core.Infrastructure.Data.Repository;
using Nubi.Core.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nubi.Core.UnitTest.Test
{
    [TestClass]
    public class UsuarioControllerDeberia : BaseTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UsuarioDbContext _usuarioDbContext;
        private readonly UserService _userService;
        private readonly UserController _userController;
       
        public UsuarioControllerDeberia()
        {
            _usuarioDbContext = MakeContext("dbTest");           
            _unitOfWork = new UnitOfWork(_usuarioDbContext);
            _userService = new UserService(_unitOfWork);
            _userController = new UserController(_userService);
        }

        [TestCleanup]
        public async Task DatabaseCleanup()
        {
            await _usuarioDbContext.Database.EnsureDeletedAsync();
            await _usuarioDbContext.SaveChangesAsync();
        }

        [TestMethod]
        public async Task TestDeberiaDevolverUsuarios()
        {
            // Arranger
            await DatabaseCleanup();
            _usuarioDbContext.Users.AddRange(GetUser());
            _ = _usuarioDbContext.SaveChangesAsync();


            // Act
            var expected = true;

            var response = await _userController.GetAllUsuarioAsync();

            var result = response as ObjectResult;
            
            var userResponse = result.Value as Response;

            //Assert

            Assert.IsNotNull(userResponse.Result);
            Assert.AreEqual(expected, userResponse.StatudCode);   
        }
    }
}
