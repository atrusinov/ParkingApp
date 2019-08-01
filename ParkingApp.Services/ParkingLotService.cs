using AutoMapper;
using ParkingApp.DAL;
using ParkingApp.Data;
using ParkingApp.Services.Contracts;

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

        protected override ParkingLotModel GetParkingLot()
        {
            throw new System.NotImplementedException();
        }
    }
}
