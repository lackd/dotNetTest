using Musicfy.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Musicfy.Persistance.Data
{
    public class MusicfyContext : DbContext
    {
        public MusicfyContext()
        {
        }

        public MusicfyContext(DbContextOptions<MusicfyContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Album> Albums { get; set; } = null!;
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Album>(entity =>
            //{
            //    entity.ToTable("album");

            //    entity.Property(e => e.Id).HasColumnName("id");

            //    entity.Property(e => e.ArtistName).HasColumnName("artistname");

            //    entity.Property(e => e.Created)
            //        .HasPrecision(6)
            //        .HasColumnName("created");
            //});

            base.OnModelCreating(modelBuilder);

        }
        
    }
}
