using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiFromScratch2.Models
{
    public partial class Animal2DBContext : DbContext
    {
        public Animal2DBContext()
        {
        }

        public Animal2DBContext(DbContextOptions<Animal2DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalTypes> AnimalTypes { get; set; }
        public virtual DbSet<Animals> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog = Animal2DB;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalTypes>(entity =>
            {
                entity.HasKey(e => e.AnimalTypeId)
                    .HasName("PK__AnimalTy__1E8A4896A16EC027");

                entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalTypeID");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Animals>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__Animals__A21A732713C8DA8E");

                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.AnimalName).HasMaxLength(50);

                entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalTypeID");

                entity.HasOne(d => d.AnimalType)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalTypeId)
                    .HasConstraintName("FK__Animals__AnimalT__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
