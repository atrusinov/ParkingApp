using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Services.Contracts
{
    public interface IParkingLevel
    {
        int Id { get; set; }
        int Level { get; set; }
        bool IsFull { get; set; }       
    }
}
