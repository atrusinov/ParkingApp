using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ParkingApp.DAL;

namespace ParkingApp.Data
{
    public class ParkingLotDbContext : DbContext
    {

        public ParkingLotDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                             => optionsBuilder
        .UseLazyLoadingProxies();


        public DbSet<ParkingLevelModel> ParkingLevels { get; set; }
        public DbSet<ParkingSpaceModel> ParkingSpaces { get; set; }
        public DbSet<ParkingLotModel> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ParkingLevelModel>()
                .HasMany(p => p.ParkingSlots)
                .WithOne(lot => lot.ParkingLevel)
                .HasForeignKey(p => p.ParkingLevelId);

            builder.Entity<ParkingLotModel>()
               .HasMany(p => p.ParkingLevels)
               .WithOne(lot => lot.ParkingLot)
               .HasForeignKey(p => p.ParkingId);

            base.OnModelCreating(builder);
        }

    }
}
