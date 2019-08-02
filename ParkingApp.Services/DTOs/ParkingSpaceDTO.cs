using ParkingApp.Services.Contracts;

namespace ParkingApp.Services.DTOs
{
    public class ParkingSpaceDTO : IParkingSpace
    {
        public int Id { get; set; }
        public int SpaceNumber { get; set; }
        public bool IsTaken { get; set; }
    }
}
