﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nubi.Core.Application.Interfaces;
using Nubi.Core.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nubi.Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencie _currencie;

        public HomeController(ICurrencie currencie)
        {
            _currencie = currencie;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _currencie.GetDataFromNubimetric();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
