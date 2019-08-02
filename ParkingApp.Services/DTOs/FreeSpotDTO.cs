using ParkingApp.Services.Contracts;

namespace ParkingApp.Services.DTOs
{
    public class FreeSpotDTO : ICarAction
    {
        public int Id { get; set; }
        public int SpaceNumber { get; set; }
        public int ParkingLevelId { get; set; }
        public bool isFull { get; set; }
        public string Message { get; set; }
    }
}
