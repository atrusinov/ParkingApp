namespace ParkingApp.DAL
{
    public class ParkingSpaceModel
    {
        public int Id { get; set; }
        public int SpaceNumber { get; set; }
        public bool IsTaken { get; set; }

       
        public virtual ParkingLevelModel ParkingLevel { get; set; }
        public int ParkingLevelId { get; set; }

    }
}
