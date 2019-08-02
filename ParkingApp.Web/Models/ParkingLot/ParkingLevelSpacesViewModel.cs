namespace ParkingApp.Web.Models.ParkingLot
{
    public class ParkingLevelSpacesViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int SpaceNumber { get; set; }
        public bool IsTaken { get; set; }
        public bool IsFull { get; set; }
    }
}
