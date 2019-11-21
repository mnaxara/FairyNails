using System;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FairyNailsApp.Entity
{
    public partial class FairynailsContext : IdentityDbContext
    {
        public FairynailsContext()
        {
        }

        public FairynailsContext(DbContextOptions<FairynailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TPrestation> TPrestation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FairynailConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TPrestation>(entity =>
            {
                entity.HasKey(e => e.IdPrestation);

                entity.ToTable("T_PRESTATION");

                entity.Property(e => e.IdPrestation).HasColumnName("Id_prestation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Duree).HasColumnType("datetime");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
