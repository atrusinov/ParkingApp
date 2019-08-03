using AutoMapper;
using ParkingApp.Data;
using ParkingApp.Services.Contracts;
using ParkingApp.Services.DTOs;
using ParkingApp.Services.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApp.Services
{
    public class ParkingLotService : BaseService, IParkingService
    {
        private const string SUCCESS_PARK_MESSAGE = "A car has just parked on parking spot {0} on floor {1}.";
        private const string FAULTY_PARK_MESSAGE = "The current floor is full!";
        private const string REMOVE_CAR_FROM_PARK_SUCCESS = "A car has departed from parking spot {0} on floor {1}";
        private const string REMOVE_CAR_FROM_PARK_FAULT = "All spots are free for parking!";

        public ParkingLotService(ParkingLotDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public ICarAction RemoveRandomCar(int levelId)
        {
            var freedSpot = DbContext.ParkingSpaces.Where(e => e.ParkingLevelId == levelId && e.IsTaken == true).FirstOrDefault();

            if (freedSpot == null)
            {
                return new FreeSpotDTO()
                {
                    isFull = false,
                    Message = REMOVE_CAR_FROM_PARK_FAULT
                };
            }

            freedSpot.IsTaken = false;

            DbContext.SaveChanges();

            var result = Mapper.Map<FreeSpotDTO>(freedSpot);
            result.Message = string.Format(REMOVE_CAR_FROM_PARK_SUCCESS, freedSpot.SpaceNumber, freedSpot.ParkingLevelId);

            return result;
        }

        public ICarAction ParkRandomCar(int level)
        {
            var parkingLevel = DbContext.ParkingLevels.FirstOrDefault(r => r.Level == level);
            var spot = FindFreeSpot(parkingLevel.Level);

            if (!spot.isFull)
            {
                DbContext.ParkingSpaces.Where(e => e.SpaceNumber == spot.SpaceNumber && e.ParkingLevelId == spot.ParkingLevelId).FirstOrDefault().IsTaken = true;
                DbContext.SaveChanges();
            }

            return spot;
        }     

        private FreeSpotDTO FindFreeSpot(int parkingLevelId)
        {
            var getFreeSpot = DbContext.ParkingSpaces.Where(e => e.IsTaken == false && e.ParkingLevelId == parkingLevelId).FirstOrDefault();
            if (getFreeSpot == null)
            {
                return new FreeSpotDTO()
                {
                    isFull = true,
                    Message = FAULTY_PARK_MESSAGE
                };
            }

            return new FreeSpotDTO()
            {
                Id = getFreeSpot.Id,
                SpaceNumber = getFreeSpot.SpaceNumber,
                ParkingLevelId = getFreeSpot.ParkingLevelId,
                Message = string.Format(SUCCESS_PARK_MESSAGE, getFreeSpot.SpaceNumber, getFreeSpot.ParkingLevelId)
            };
        }

        public ICollection<int> FillOrEmpty(int command)
        {
            using (DbContext)
            {
                var fillOrEmpty = (ParkingCommands)command == ParkingCommands.Empty ? false : true;

                var allEmptySpaces = DbContext.ParkingSpaces
                    .Where(e => e.IsTaken == !fillOrEmpty)
                    .ToList();

                allEmptySpaces.ForEach(id => id.IsTaken = fillOrEmpty);

                DbContext.SaveChanges();

                return allEmptySpaces.Select(e => e.Id).ToArray();
            }          

        }
        public IParkingLot GetParkingLot()
        {
            using (DbContext)
            {
                var getLot = DbContext.ParkingLots.FirstOrDefault();

                var result = Mapper.Map<ParkingLotDTO>(getLot);

                return result;
            }          
        }     
    }
}
