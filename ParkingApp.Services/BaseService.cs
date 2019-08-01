using AutoMapper;
using ParkingApp.Data;

namespace ParkingApp.Services
{
    public abstract class BaseService
    {
        protected BaseService(ParkingLotDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected ParkingLotDbContext DbContext { get; private set; }
        protected IMapper Mapper { get; private set; }
    }
}
