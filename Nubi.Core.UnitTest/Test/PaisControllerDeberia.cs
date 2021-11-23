namespace Nubi.Core.UnitTest.Test
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Nubi.Core.Api.Rest.Controllers;
    using Nubi.Core.Application.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [TestClass]
    public class PaisControllerDeberia
    {
        private readonly PaisService _paisService;
        private readonly PaisesController _paisesController;

        public PaisControllerDeberia()
        {
            _paisesController = new PaisesController(_paisService);
        }

        [TestMethod]
        public async Task DevolverNoAuthorizeSiBR()
        {
            //Arranger
            var entrada = "BR";
            var expected = StatusCodes.Status401Unauthorized;

            var resultController = await _paisesController.GetPais(entrada);

            var result = resultController as StatusCodeResult;

            Assert.AreEqual(expected, result.StatusCode);

        }

        [TestMethod]
        public async Task DevolverNoAuthorizeSiCO()
        {
            //Arranger
            var entrada = "CO";
            var expected = StatusCodes.Status401Unauthorized;

            var resultController = await _paisesController.GetPais(entrada);

            var result = resultController as StatusCodeResult;

            Assert.AreEqual(expected, result.StatusCode);

        }
    }
}
