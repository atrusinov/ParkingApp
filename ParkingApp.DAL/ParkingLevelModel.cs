using System.Collections.Generic;

namespace ParkingApp.DAL
{
    public class ParkingLevelModel
    {
        public ParkingLevelModel()
        {
            this.ParkingSlots = new List<ParkingSpaceModel>();
        }

        public int Id { get; set; }

        public ParkingLotModel ParkingLot { get; set; }
        public int ParkingId { get; set; }

        public int Level { get; set; }

        public bool IsFull { get; set; }

        public ICollection<ParkingSpaceModel> ParkingSlots { get; set; }

    }
}
