using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Services.Contracts;
using ParkingApp.Web.Models;
using ParkingApp.Web.Models.ParkingLot;

namespace ParkingApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkingService _parkingService;
        private readonly IMapper _mapper;

        public HomeController(IParkingService parkingService, IMapper mapper)
        {
            this._parkingService = parkingService;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            var pakringLotDTO = _parkingService.GetParkingLot();

            var parkingViewModel = _mapper.Map<ParkingLotViewModel>(pakringLotDTO);

            return View(parkingViewModel);
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
