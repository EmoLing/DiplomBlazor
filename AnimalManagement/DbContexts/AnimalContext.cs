using Helper.Guids.Animals;
using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

namespace AnimalManagement.DbContexts
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
            Database.EnsureCreated();

            bool isEmptyKindsOfAnimalsBase = !KindsOfAnimals.Any();
            bool isEmptyColorsOfAnimalssBase = !ColorsOfAnimals.Any();

            if (!isEmptyKindsOfAnimalsBase && !isEmptyColorsOfAnimalssBase)
                return;

            if (isEmptyKindsOfAnimalsBase)
            {
                KindsOfAnimals.AddRange(new List<KindOfAnimal>()
                {
                    new KindOfAnimal() { KindName = "Кошка", Guid = Guids.CatGuid, Position = 0},
                    new KindOfAnimal() { KindName = "Собака", Guid = Guids.DogGuid, Position = 1},
                    new KindOfAnimal() { KindName = "Птица", Guid = Guids.BirdGuid, Position = 2},
                    new KindOfAnimal() { KindName = "Другой", Guid = Guids.OtherKindGuid, Position = 3}
                });
            }

            if (isEmptyColorsOfAnimalssBase)
            {
                ColorsOfAnimals.AddRange(new List<ColorOfAnimal>()
                {
                    new ColorOfAnimal() { ColorName = "Черный", Guid = Guids.BlackGuid, Position = 0},
                    new ColorOfAnimal() { ColorName = "Белый", Guid = Guids.WhiteGuid, Position = 1},
                    new ColorOfAnimal() { ColorName = "Серый", Guid = Guids.GrayGuid, Position = 2},
                    new ColorOfAnimal() { ColorName = "Рыжий", Guid = Guids.GingerGuid, Position = 3},
                    new ColorOfAnimal() { ColorName = "Бежевый", Guid = Guids.BeigeGuid, Position = 4},
                    new ColorOfAnimal() { ColorName = "Коричневый", Guid = Guids.BrownGuid, Position = 5},
                    new ColorOfAnimal() { ColorName = "Многоцветный", Guid = Guids.MultiColorGuid , Position = 6},
                    new ColorOfAnimal() { ColorName = "Другой", Guid = Guids.OtherColorGuid , Position = 7},
                });
            }

            SaveChanges();
        }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AdCoordinates> AdCoordinates { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ColorOfAnimal> ColorsOfAnimals { get; set; }
        public DbSet<KindOfAnimal> KindsOfAnimals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>().HasKey(a => a.Guid);
            modelBuilder.Entity<AdCoordinates>().HasKey(a => a.AdGuid);
            modelBuilder.Entity<Image>().HasKey(a => a.AdGuid);

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
