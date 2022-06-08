using Microsoft.EntityFrameworkCore;
using Model.Images;

namespace Images.DbContexts
{
    public class ImagesContext : DbContext
    {
        public ImagesContext(DbContextOptions<ImagesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(i =>
            {
                i.HasKey(a => a.Guid);
                i.Property(p => p.Guid);
                i.Property(p => p.AdGuid);
            });
        }

    }
}
