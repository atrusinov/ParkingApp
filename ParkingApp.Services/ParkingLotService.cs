using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingApp.DAL;
using ParkingApp.Data;
using ParkingApp.Services.Contracts;
using ParkingApp.Services.DTOs;
using System.Linq;

namespace ParkingApp.Services
{
    public class ParkingLotService : BaseService, IParkingService
    {
        public ParkingLotService(ParkingLotDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public string DepartCar()
        {
            throw new System.NotImplementedException();
        }

        public string ParkCar()
        {
            throw new System.NotImplementedException();
        }

        public void SaveParkingState()
        {
            throw new System.NotImplementedException();
        }

        public ParkingLotDTO GetParkingLot()
        {
            var getLot = DbContext.ParkingLots.FirstOrDefault();

            var result = Mapper.Map<ParkingLotDTO>(getLot);

            return result;
        }
    }
}
