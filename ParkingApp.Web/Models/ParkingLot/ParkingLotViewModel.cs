using System.Collections.Generic;

namespace ParkingApp.Web.Models.ParkingLot
{
    public class ParkingLotViewModel
    {
        public ParkingLotViewModel()
        {
            this.ParkingLevels = new List<ParkingLevelViewModel>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ParkingLevelViewModel> ParkingLevels { get; set; }
    }
}
