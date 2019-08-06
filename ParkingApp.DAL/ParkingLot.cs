using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParkingApp.DAL
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            this.ParkingLevels = new HashSet<ParkingLevel>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<ParkingLevel> ParkingLevels { get; set; }
    }
}
