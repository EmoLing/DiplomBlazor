using Microsoft.EntityFrameworkCore;
using Model.Coordinates;

namespace Coordinates.DbContexts
{
    public class CoordinatesContext : DbContext
    {
        public CoordinatesContext(DbContextOptions<CoordinatesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AdCoordinates> AdCoordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdCoordinates>(a =>
            {
                a.HasKey(a => a.Guid);
                a.HasKey(a => a.AdGuid);
                a.Property(p => p.Guid);
                a.Property(p => p.AdGuid);
                a.Property(p => p.Latitude).HasPrecision(36, 18);
                a.Property(p => p.Longitude).HasPrecision(36, 18);
            });
        }

    }
}