using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Services.Contracts;
using ParkingApp.Web.Models;

namespace ParkingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkingService _parkingService;

        public HomeController(IParkingService parkingService)
        {
            this._parkingService = parkingService;
        }

        public IActionResult Index()
        {
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
