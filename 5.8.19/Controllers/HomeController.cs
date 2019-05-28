using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5._8._19.Models;
using Data;

namespace _5._8._19.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var api = new NewsApi();
            return View(api.GetNews());
        }

    }
}
