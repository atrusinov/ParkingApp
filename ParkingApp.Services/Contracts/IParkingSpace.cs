namespace ParkingApp.Services.Contracts
{
    public interface IParkingSpace
    {
        int Id { get; set; }
        int SpaceNumber { get; set; }
        bool IsTaken { get; set; }
    }
}
