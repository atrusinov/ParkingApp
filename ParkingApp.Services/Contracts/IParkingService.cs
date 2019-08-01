using ParkingApp.Services.DTOs;

namespace ParkingApp.Services.Contracts
{
   public interface IParkingService
    {
        string ParkCar();

        string DepartCar();

        ParkingLotDTO GetParkingLot();
    }
}
