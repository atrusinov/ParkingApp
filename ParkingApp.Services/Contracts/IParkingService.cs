namespace ParkingApp.Services.Contracts
{
    interface IParkingService
    {
        string ParkCar();

        string DepartCar();

        void SaveParkingState();
    }
}
