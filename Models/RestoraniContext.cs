using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Projekat.Models
{
    public partial class RestoraniContext : DbContext
    {
        public RestoraniContext()
        {
        }

        public RestoraniContext(DbContextOptions<RestoraniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gost> Gosts { get; set; }
        public virtual DbSet<Jelo> Jelos { get; set; }
        public virtual DbSet<Konobar> Konobars { get; set; }
        public virtual DbSet<Kuhinja> Kuhinjas { get; set; }
        public virtual DbSet<Kuvar> Kuvars { get; set; }
        public virtual DbSet<Meni> Menis { get; set; }
        public virtual DbSet<Namirnica> Namirnicas { get; set; }
        public virtual DbSet<Narucuje> Narucujes { get; set; }
        public virtual DbSet<Pravi> Pravis { get; set; }
        public virtual DbSet<Radnik> Radniks { get; set; }
        public virtual DbSet<Restoran> Restorans { get; set; }
        public virtual DbSet<Sadrzi> Sadrzis { get; set; }
        public virtual DbSet<StavkaMenija> StavkaMenijas { get; set; }
        public virtual DbSet<Sto> Stos { get; set; }
        public virtual DbSet<Vlasnik> Vlasniks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["RestoraniConnectionString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gost>(entity =>
            {
                entity.HasKey(e => e.SifrG)
                    .HasName("GOS_PK");

                entity.ToTable("GOST");

                entity.HasIndex(e => e.BrTel, "GOS_BR_UN")
                    .IsUnique();

                entity.HasIndex(e => e.Jmbg, "GOS_JMBG_UN")
                    .IsUnique();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jelo>(entity =>
            {
                entity.HasKey(e => e.SifrJ)
                    .HasName("JEL_PK");

                entity.ToTable("JELO");

                entity.Property(e => e.Naz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Konobar>(entity =>
            {
                entity.HasKey(e => e.SifrR)
                    .HasName("KON_PK");

                entity.ToTable("KONOBAR");

                entity.Property(e => e.SifrR).ValueGeneratedNever();

                entity.HasOne(d => d.SifrRNavigation)
                    .WithOne(p => p.Konobar)
                    .HasForeignKey<Konobar>(d => d.SifrR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KON_FK");
            });

            modelBuilder.Entity<Kuhinja>(entity =>
            {
                entity.HasKey(e => e.SifrK)
                    .HasName("KUH_PK");

                entity.ToTable("KUHINJA");

                entity.HasOne(d => d.SifrNavigation)
                    .WithMany(p => p.Kuhinjas)
                    .HasForeignKey(d => d.Sifr)
                    .HasConstraintName("KUH_FK");
            });

            modelBuilder.Entity<Kuvar>(entity =>
            {
                entity.HasKey(e => e.SifrR)
                    .HasName("KUV_PK");

                entity.ToTable("KUVAR");

                entity.Property(e => e.SifrR).ValueGeneratedNever();

                entity.HasOne(d => d.SifrKNavigation)
                    .WithMany(p => p.Kuvars)
                    .HasForeignKey(d => d.SifrK)
                    .HasConstraintName("KUV_K_FK");

                entity.HasOne(d => d.SifrRNavigation)
                    .WithOne(p => p.Kuvar)
                    .HasForeignKey<Kuvar>(d => d.SifrR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("KUV_R_FK");
            });

            modelBuilder.Entity<Meni>(entity =>
            {
                entity.HasKey(e => e.SifrM)
                    .HasName("MEN_PK");

                entity.ToTable("MENI");

                entity.HasOne(d => d.SifrNavigation)
                    .WithMany(p => p.Menis)
                    .HasForeignKey(d => d.Sifr)
                    .HasConstraintName("MEN_FK");
            });

            modelBuilder.Entity<Namirnica>(entity =>
            {
                entity.HasKey(e => e.SifrN)
                    .HasName("NAM_PK");

                entity.ToTable("NAMIRNICA");

                entity.Property(e => e.Naz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SifrJNavigation)
                    .WithMany(p => p.Namirnicas)
                    .HasForeignKey(d => d.SifrJ)
                    .HasConstraintName("NAM_FK");
            });

            modelBuilder.Entity<Narucuje>(entity =>
            {
                entity.HasKey(e => new { e.SifrG, e.SifrJ })
                    .HasName("NAR_PK");

                entity.ToTable("NARUCUJE");

                entity.HasOne(d => d.SifrGNavigation)
                    .WithMany(p => p.Narucujes)
                    .HasForeignKey(d => d.SifrG)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NAR_G_FK");

                entity.HasOne(d => d.SifrJNavigation)
                    .WithMany(p => p.Narucujes)
                    .HasForeignKey(d => d.SifrJ)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NAR_J_FK");
            });

            modelBuilder.Entity<Pravi>(entity =>
            {
                entity.HasKey(e => new { e.SifrR, e.SifrG, e.SifrJ })
                    .HasName("PRA_PK");

                entity.ToTable("PRAVI");

                entity.HasOne(d => d.SifrRNavigation)
                    .WithMany(p => p.Pravis)
                    .HasForeignKey(d => d.SifrR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRA_R_FN");

                entity.HasOne(d => d.Sifr)
                    .WithMany(p => p.Pravis)
                    .HasForeignKey(d => new { d.SifrG, d.SifrJ })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRA_N_FN");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasKey(e => e.SifrR)
                    .HasName("RAD_PK");

                entity.ToTable("RADNIK");

                entity.HasIndex(e => e.BrTel, "RAD_BR_UN")
                    .IsUnique();

                entity.HasIndex(e => e.Jmbg, "RAD_JMBG_UN")
                    .IsUnique();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SifrVNavigation)
                    .WithMany(p => p.Radniks)
                    .HasForeignKey(d => d.SifrV)
                    .HasConstraintName("RAD_FK");
            });

            modelBuilder.Entity<Restoran>(entity =>
            {
                entity.HasKey(e => e.Sifr)
                    .HasName("RES_PK");

                entity.ToTable("RESTORAN");

                entity.HasIndex(e => e.Adr, "RES_UN")
                    .IsUnique();

                entity.Property(e => e.Adr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mest)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Naz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SifrVNavigation)
                    .WithMany(p => p.Restorans)
                    .HasForeignKey(d => d.SifrV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RES_FK");
            });

            modelBuilder.Entity<Sadrzi>(entity =>
            {
                entity.HasKey(e => new { e.SifrSm, e.SifrG, e.SifrJ })
                    .HasName("SAD_PK");

                entity.ToTable("SADRZI");

                entity.Property(e => e.SifrSm).HasColumnName("SifrSM");

                entity.HasOne(d => d.SifrSmNavigation)
                    .WithMany(p => p.Sadrzis)
                    .HasForeignKey(d => d.SifrSm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SAD_SM_FK");

                entity.HasOne(d => d.Sifr)
                    .WithMany(p => p.Sadrzis)
                    .HasForeignKey(d => new { d.SifrG, d.SifrJ })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SAD_N_FK");
            });

            modelBuilder.Entity<StavkaMenija>(entity =>
            {
                entity.HasKey(e => e.SifrSm)
                    .HasName("SM_PK");

                entity.ToTable("STAVKA_MENIJA");

                entity.Property(e => e.SifrSm).HasColumnName("SifrSM");

                entity.Property(e => e.Naz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SifrMNavigation)
                    .WithMany(p => p.StavkaMenijas)
                    .HasForeignKey(d => d.SifrM)
                    .HasConstraintName("SM_FK");
            });

            modelBuilder.Entity<Sto>(entity =>
            {
                entity.HasKey(e => e.SifrS)
                    .HasName("STO_PK");

                entity.ToTable("STO");

                entity.HasOne(d => d.SifrNavigation)
                    .WithMany(p => p.Stos)
                    .HasForeignKey(d => d.Sifr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STO_R_FK");

                entity.HasOne(d => d.SifrGNavigation)
                    .WithMany(p => p.Stos)
                    .HasForeignKey(d => d.SifrG)
                    .HasConstraintName("STO_G_FK");
            });

            modelBuilder.Entity<Vlasnik>(entity =>
            {
                entity.HasKey(e => e.SifrV)
                    .HasName("VLA_PK");

                entity.ToTable("VLASNIK");

                entity.HasIndex(e => e.BrTel, "VLA_BR_UN")
                    .IsUnique();

                entity.HasIndex(e => e.Jmbg, "VLA_JMBG_UN")
                    .IsUnique();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
