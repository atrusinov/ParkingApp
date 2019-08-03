using System.Collections.Generic;

namespace ParkingApp.Services.Contracts
{
    public interface IParkingService
    {
        ICarAction ParkRandomCar(int level);

        ICarAction RemoveRandomCar(int level);      

        ICollection<int> FillOrEmpty(int command);    

        IParkingLot GetParkingLot();
    }
}
