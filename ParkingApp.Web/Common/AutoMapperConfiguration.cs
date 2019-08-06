using AutoMapper;
using ParkingApp.DAL;
using ParkingApp.Services.DTOs;
using ParkingApp.Web.Models.ParkingLot;

namespace ParkingApp.Web.Common
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            this.CreateMap<ParkingLot, ParkingLotDTO>().ReverseMap();
            this.CreateMap<ParkingLevel, ParkingLevelDTO>().ReverseMap();
            this.CreateMap<ParkingSpace, ParkingSpaceDTO>().ReverseMap();
            this.CreateMap<ParkingLotDTO,ParkingLotViewModel>().ReverseMap();
            this.CreateMap<ParkingLevelDTO, ParkingLevelViewModel>().ReverseMap();
            this.CreateMap<ParkingSpaceDTO, ParkingLevelSpacesViewModel>().ReverseMap();
            this.CreateMap<FreeSpotDTO, ParkingLevelSpacesViewModel>().ReverseMap();
            this.CreateMap<FreeSpotDTO, ParkingSpace>().ReverseMap();
        }
    }
}
