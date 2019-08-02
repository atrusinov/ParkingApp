using ParkingApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Services.Contracts
{
    public interface IParkingLot
    {
        int Id { get; set; }
        string Name { get; set; }       
    }
}
