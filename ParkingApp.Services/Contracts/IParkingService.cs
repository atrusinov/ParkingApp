using ParkingApp.Services.DTOs;

namespace ParkingApp.Services.Contracts
{
   public interface IParkingService
    {
        string ParkCar(int level);

        string DepartCar(int level);

        ParkingLotDTO GetParkingLot();
    }
}
