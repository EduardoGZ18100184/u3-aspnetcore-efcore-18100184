using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace u3_aspnetcore_efcore_18100184.Models
{
    public partial class SeriesContext : DbContext
    {
        public SeriesContext()
        {
        }

        public SeriesContext(DbContextOptions<SeriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Productora> Productoras { get; set; }
        public virtual DbSet<Serie> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G7E9JIC\\SQL18100184;Database=Series;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productora>(entity =>
            {
                entity.HasKey(e => e.IdProductora)
                    .HasName("PK__Producto__C0568584D1690E87");

                entity.ToTable("Productora");

                entity.Property(e => e.NombreProductora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.Property(e => e.SerieId).HasColumnName("SerieID");

                entity.Property(e => e.NombreSerie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProductoraNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdProductora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Serie__IdProduct__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
