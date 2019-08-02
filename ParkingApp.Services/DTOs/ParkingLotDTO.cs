using ParkingApp.Services.Contracts;
using System.Collections.Generic;

namespace ParkingApp.Services.DTOs
{
    public class ParkingLotDTO : IParkingLot
    {
        public ParkingLotDTO()
        {
            this.ParkingLevels = new List<ParkingLevelDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ParkingLevelDTO> ParkingLevels { get; set; }
        
    }
}
