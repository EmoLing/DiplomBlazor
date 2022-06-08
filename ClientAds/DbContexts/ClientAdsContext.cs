using Microsoft.EntityFrameworkCore;
using Model.ClientAds;

namespace ClientAds.DbContexts
{
    public class ClientAdsContext : DbContext
    {
        public ClientAdsContext(DbContextOptions<ClientAdsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ad> ClientAds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(a =>
            {
                a.HasKey(a => a.Guid);
                a.Property(p => p.Guid);
                a.Property(p => p.TypeAd);
                a.Property(p => p.UserGuid);
                a.Property(p => p.StatusAd);
                a.Property(p => p.DateCreate);
            });
        }
    }
}
