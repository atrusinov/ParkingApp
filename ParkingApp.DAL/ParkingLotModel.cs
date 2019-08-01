using System.Collections.Generic;

namespace ParkingApp.DAL
{
    public class ParkingLotModel
    {
        public ParkingLotModel()
        {
            this.ParkingLevels = new HashSet<ParkingLevelModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ParkingLevelModel> ParkingLevels { get; set; }
    }
}
