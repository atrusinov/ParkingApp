using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ParkingApp.DAL;
using ParkingApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace ParkingApp.Web.Common
{
    public static class ApplicationBuilder
    {
        private const int TOTAL_PARKING_LEVELS = 4;
        private const int TOTAL_PARKING_SPOTS = 150;
        private const string PARKING_NAME = "Progress";

        public static void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var context = scope.ServiceProvider.GetRequiredService<ParkingLotDbContext>();

                if (!context.ParkingLots.Any())
                {
                    var result = CreateParkingLot(TOTAL_PARKING_LEVELS, TOTAL_PARKING_SPOTS, PARKING_NAME);
                    context.Add(result);
                    context.SaveChanges();
                }

            }
        }

        private static ParkingLotModel CreateParkingLot(int totalLevels, int spaces, string parkingName)
        {
            var parkingLot = new ParkingLotModel();
            parkingLot.Name = parkingName;

            for (int level = 1; level <= totalLevels; level++)
            {
                var parkingLevel = new ParkingLevelModel();
                parkingLevel.Level = level;
                parkingLevel.ParkingSlots = CreateParkingSlots(spaces);

                parkingLot.ParkingLevels.Add(parkingLevel);
            }

            return parkingLot;
        }

        private static ICollection<ParkingSpaceModel> CreateParkingSlots(int totalSpaces)
        {
            var result = new List<ParkingSpaceModel>();

            for (int currentSpace = 1; currentSpace <= totalSpaces; currentSpace++)
            {
                var parkingSpace = new ParkingSpaceModel() { SpaceNumber = currentSpace };
                result.Add(parkingSpace);
            }

            return result;
        }
    }
}
