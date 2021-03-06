﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.Fundamentals.Client.Web.Models;

namespace NetCore.Fundamentals.Client.Web.Controllers
{
    [Route("Inicio/[action]")]
    public class HomeController : Controller
    {//Cambios
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        //[Route("Test/Action")]
        public string Test([FromBody]TestRequest testRequest)
        {
            return "Hola Mundo - " + testRequest.Param.ToString();
        }

        public IActionResult Index()
        {
            Person person = new Person("Oscar", 15);
            return View(person);
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
