using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

namespace Ads.DbContexts
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions<AdContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AdCoordinates> AdCoordinates { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ColorOfAnimal> ColorsOfAnimals { get; set; }
        public DbSet<KindOfAnimal> KindsOfAnimals { get; set; }

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

            modelBuilder.Entity<AdCoordinates>().HasKey(a => a.AdGuid);
            modelBuilder.Entity<Image>().HasKey(a => a.Guid);

            modelBuilder.Entity<Animal>().HasKey(a => a.Guid);
            modelBuilder.Entity<Animal>().HasKey(a => a.AdGuid);
            modelBuilder.Entity<ColorOfAnimal>().HasKey(a => a.Guid);
            modelBuilder.Entity<KindOfAnimal>().HasKey(a => a.Guid);

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Coordinates)
                .WithOne(ac => ac.Ad)
                .HasForeignKey<AdCoordinates>(ac => ac.AdGuid);

            modelBuilder.Entity<Image>()
                .HasOne(a => a.Ad)
                .WithMany(im => im.Photo);

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Animal)
                .WithOne(an => an.Ad)
                .HasForeignKey<Animal>(an => an.AdGuid);

            modelBuilder.Entity<Animal>()
                .HasOne<KindOfAnimal>()
                .WithMany()
                .HasForeignKey(a => a.KindOfAnimalGuid);

            modelBuilder.Entity<Animal>()
                .HasOne<ColorOfAnimal>()
                .WithMany()
                .HasForeignKey(a => a.ColorOfAnimalGuid);

            modelBuilder.Entity<AdCoordinates>().Property(a => a.Latitude).HasPrecision(36, 18);
            modelBuilder.Entity<AdCoordinates>().Property(a => a.Longitude).HasPrecision(36, 18);
        }
    }
}
