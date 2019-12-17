using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FairyNails.Service.Entity
{
    public partial class FairynailsContext : IdentityDbContext<ApplicationUser>
    {
        public FairynailsContext()
        {
        }

        public FairynailsContext(DbContextOptions<FairynailsContext> options)
            : base(options)
        {
        }


        public virtual DbSet<TPrestation> TPrestation { get; set; }
        public virtual DbSet<TRendezVous> TRendezVous { get; set; }
        public virtual DbSet<TRendezVousHasPrestation> TRendezVousHasPrestation { get; set; }

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

                entity.Property(e => e.Duree).HasColumnType("time");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prix).HasColumnType("money");
            });

            modelBuilder.Entity<TRendezVous>(entity =>
            {
                entity.HasKey(e => e.IdRdv);

                entity.ToTable("T_RENDEZ_VOUS");

                entity.Property(e => e.IdRdv).HasColumnName("Id_rdv");

                entity.Property(e => e.DateRdv).HasColumnType("datetime");

                entity.Property(e => e.PrixTotal).HasColumnType("decimal");

                entity.Property(e => e.DureeTotal).HasColumnType("time");

                entity.Property(e => e.IdClient)
                    .IsRequired()
                    .HasColumnName("Id_client")
                    .HasMaxLength(450);

                entity.Property(e => e.Validate).HasColumnName("validate");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.TRendezVous)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_RENDEZ_VOUS");
            });

            modelBuilder.Entity<TRendezVousHasPrestation>(entity =>
            {
                entity.HasKey(e => new { e.IdRdv, e.IdPrestation });

                entity.ToTable("T_RENDEZ_VOUS_HAS_PRESTATION");

                entity.Property(e => e.IdRdv).HasColumnName("Id_rdv");

                entity.Property(e => e.IdPrestation).HasColumnName("Id_prestation");

                entity.HasOne(d => d.IdPrestationNavigation)
                    .WithMany(p => p.TRendezVousHasPrestation)
                    .HasForeignKey(d => d.IdPrestation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("[FK_T_RENDEZ_VOUS_HAS_PRESTATION");

                entity.HasOne(d => d.IdRdvNavigation)
                    .WithMany(p => p.TRendezVousHasPrestation)
                    .HasForeignKey(d => d.IdRdv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_RENDEZ_VOUS_HAS_PRESTATION_T_RENDEZ_VOUS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
