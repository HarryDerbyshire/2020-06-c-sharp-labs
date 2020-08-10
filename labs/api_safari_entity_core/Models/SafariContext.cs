using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_safari_entity_core.Models
{
    public partial class SafariContext : DbContext
    {
        public SafariContext()
        {
        }

        public SafariContext(DbContextOptions<SafariContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalType> AnimalTypes { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = Safari.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("animal_types");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.NumberOfLegs)
                    .HasColumnName("numberOfLegs")
                    .HasColumnType("int");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("varchar(40)");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.ToTable("animals");

                entity.Property(e => e.AnimalId)
                    .HasColumnName("animalId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnimalName)
                    .HasColumnName("animalName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.TypeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
