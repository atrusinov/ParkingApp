using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Services.Contracts
{
    public interface ICarAction
    {
         int SpaceNumber { get; set; }
         int ParkingLevelId { get; set; }
    }
}
