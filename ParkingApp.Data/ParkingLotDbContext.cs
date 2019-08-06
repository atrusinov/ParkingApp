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


        public DbSet<ParkingLevel> ParkingLevels { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ParkingLevel>()
                .HasMany(p => p.ParkingSlots)
                .WithOne(lot => lot.ParkingLevel)
                .HasForeignKey(p => p.ParkingLevelId);

            builder.Entity<ParkingLot>()
               .HasMany(p => p.ParkingLevels)
               .WithOne(lot => lot.ParkingLot)
               .HasForeignKey(p => p.ParkingId);

            builder.Entity<ParkingLevel>()
                .HasIndex(l => l.Level)
                .IsUnique();

            base.OnModelCreating(builder);
        }

    }
}
