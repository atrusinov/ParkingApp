using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
                context.Database.Migrate(); // comment this line out if this is not the first time you are launching the app.
                if (!context.ParkingLots.Any())
                {
                    var result = CreateParkingLot(TOTAL_PARKING_LEVELS, TOTAL_PARKING_SPOTS, PARKING_NAME);
                    context.Add(result);
                    context.SaveChanges();
                }

            }
        }

        private static ParkingLot CreateParkingLot(int totalLevels, int spaces, string parkingName)
        {
            var parkingLot = new ParkingLot();
            parkingLot.Name = parkingName;

            for (int level = 1; level <= totalLevels; level++)
            {
                var parkingLevel = new ParkingLevel();
                parkingLevel.Level = level;
                parkingLevel.ParkingSlots = CreateParkingSlots(spaces);

                parkingLot.ParkingLevels.Add(parkingLevel);
            }

            return parkingLot;
        }

        private static ICollection<ParkingSpace> CreateParkingSlots(int totalSpaces)
        {
            var result = new List<ParkingSpace>();

            for (int currentSpace = 1; currentSpace <= totalSpaces; currentSpace++)
            {
                var parkingSpace = new ParkingSpace() { SpaceNumber = currentSpace };
                result.Add(parkingSpace);
            }

            return result;
        }
    }
}
