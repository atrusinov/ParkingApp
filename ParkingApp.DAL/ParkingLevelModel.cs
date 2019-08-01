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

        public virtual ParkingLotModel ParkingLot { get; set; }
        public int ParkingId { get; set; }
        
        public int Level { get; set; }

        public bool IsFull { get; set; }

        public virtual ICollection<ParkingSpaceModel> ParkingSlots { get; set; }

    }
}
