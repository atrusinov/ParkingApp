using System.Collections.Generic;

namespace ParkingApp.Services.DTOs
{
    public class ParkingLevelDTO
    {
        public ParkingLevelDTO()
        {
            this.ParkingSlots = new List<ParkingSpaceDTO>();
        }

        public int Level { get; set; }

        public bool IsFull { get; set; }

        public ICollection<ParkingSpaceDTO> ParkingSlots { get; set; }
    }
}
