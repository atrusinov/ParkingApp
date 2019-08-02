using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Web.Models.ParkingLot
{
    public class ParkingLevelViewModel
    {
        public ParkingLevelViewModel()
        {
            this.ParkingSlots = new List<ParkingLevelSpacesViewModel>();
        }

        public int Id { get; set; }
        public int Level { get; set; }

        public bool IsFull { get; set; }

        public ICollection<ParkingLevelSpacesViewModel> ParkingSlots { get; set; }
    }
}
