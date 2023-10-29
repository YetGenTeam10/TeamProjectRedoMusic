﻿using Microsoft.AspNetCore.Mvc;
using RedoMusicMVC.Models;
using System.Diagnostics;

namespace RedoMusicMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(bool? isLoggedIn)
        {
            if(isLoggedIn != null)
            {
                ModelState.AddModelError("", "Successfully Logged In");
            }
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