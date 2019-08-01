using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkingApp.DAL;
using ParkingApp.Data;
using ParkingApp.Services.Contracts;
using ParkingApp.Services.DTOs;
using System;
using System.Linq;

namespace ParkingApp.Services
{
    public class ParkingLotService : BaseService, IParkingService
    {
        public ParkingLotService(ParkingLotDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public string DepartCar(int level)
        {
            throw new System.NotImplementedException();
        }

        public string ParkCar(int level)
        {
            var parkingLevel = DbContext.ParkingLevels.FirstOrDefault(r => r.Level == level);
            var spot = FindFreeSpot(parkingLevel.Level);

            DbContext.ParkingSpaces.Where(e => e.SpaceNumber == spot.FreeSpot && e.ParkingLevelId == spot.Level).FirstOrDefault().IsTaken = true;
            DbContext.SaveChanges();

            return "OK";
        }

        private FreeSpotDTO FindFreeSpot(int parkingLevelId)
        {
            var getAllFreeSpots = DbContext.ParkingSpaces.Where(e => e.IsTaken == false && e.ParkingLevelId == parkingLevelId).FirstOrDefault();

            return new FreeSpotDTO() { FreeSpot = getAllFreeSpots.SpaceNumber, Level = getAllFreeSpots.ParkingLevelId };
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
