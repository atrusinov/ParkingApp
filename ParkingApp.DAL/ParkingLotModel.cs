using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.DAL
{
    public class ParkingLotModel
    {
        public ParkingLotModel()
        {
            this.ParkingLevels = new HashSet<ParkingLevelModel>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<ParkingLevelModel> ParkingLevels { get; set; }
    }
}
