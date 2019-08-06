using System.Collections.Generic;

namespace ParkingApp.DAL
{
    public class ParkingLevel
    {
        public ParkingLevel()
        {
            this.ParkingSlots = new List<ParkingSpace>();
        }

        public int Id { get; set; }

        public virtual ParkingLot ParkingLot { get; set; }
        public int ParkingId { get; set; }
        
        public int Level { get; set; }

        public bool IsFull { get; set; }

        public virtual ICollection<ParkingSpace> ParkingSlots { get; set; }

    }
}
