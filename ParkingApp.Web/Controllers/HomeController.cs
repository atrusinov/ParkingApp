using System.Diagnostics;
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
            return View();
        }

        [HttpGet]
        public IActionResult GetParkingLot()
        {
            var pakringLotDTO = _parkingService.GetParkingLot();

            return Json(pakringLotDTO);
        }

        [HttpPost]
        public IActionResult ParkRandomCar(int level)
        {
            var parkedCarInfo = _parkingService.ParkRandomCar(level);
            var viewResult = _mapper.Map<ParkingLevelSpacesViewModel>(parkedCarInfo);

            return Json(viewResult);
        }

        [HttpPost]
        public IActionResult RemoveRandomCar(int level)
        {
            var parkedCarInfo = _parkingService.RemoveRandomCar(level);
            var viewResult = _mapper.Map<ParkingLevelSpacesViewModel>(parkedCarInfo);

            return Json(viewResult);
        }       

        [HttpPost]
        public IActionResult FillOrEmptyParking(int fillOrEmpty)
        {
            var spacesForManipulation = _parkingService.FillOrEmpty(fillOrEmpty);

            return Json(spacesForManipulation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
