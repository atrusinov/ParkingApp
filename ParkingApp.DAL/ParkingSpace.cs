namespace ParkingApp.DAL
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public int SpaceNumber { get; set; }
        public bool IsTaken { get; set; }

       
        public virtual ParkingLevel ParkingLevel { get; set; }
        public int ParkingLevelId { get; set; }

    }
}
