using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Videoteka.WebAPI.Database
{
    public partial class VideotekaContext : DbContext
    {
        public VideotekaContext()
        {
        }

        public VideotekaContext(DbContextOptions<VideotekaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Poruka> Poruka { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<RezervacijaFilma> RezervacijaFilma { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<Zanr> Zanr { get; set; }
        public virtual DbSet<Reziser> Reziser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Videoteka2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.ReziserId).HasColumnName("ReziserID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Glumac)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Jezik)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_DrzavaID");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_ZanrID");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostanskiBroj).HasMaxLength(50);
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.DatumRodjenja).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Klijent)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Klijent_GradID");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Adresa).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnik_GradID");
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.Property(e => e.KorisniciUlogeId).HasColumnName("KorisniciUlogeID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User_UserID");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role_RoleID");
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.DatumEvidentiranja).HasColumnType("datetime");

                entity.Property(e => e.Ocjena1).HasColumnName("Ocjena");

                entity.Property(e => e.RezervacijaFilmaId).HasColumnName("RezervacijaFilmaID");

                entity.HasOne(d => d.RezervacijaFilma)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.RezervacijaFilmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Poruka>(entity =>
            {
                entity.Property(e => e.PorukaId).HasColumnName("PorukaID");

                entity.Property(e => e.DatumVrijeme).HasColumnType("datetime");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Posiljaoc)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RezervacijaFilmaId).HasColumnName("RezervacijaFilmaID");

                entity.Property(e => e.Sadrzaj).IsRequired();

                entity.Property(e => e.UposlenikId).HasColumnName("UposlenikID");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Poruka)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RezervacijaFilma)
                    .WithMany(p => p.Poruka)
                    .HasForeignKey(d => d.RezervacijaFilmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poruka_RezervacijaFilmaID");

                entity.HasOne(d => d.Uposlenik)
                    .WithMany(p => p.Poruka)
                    .HasForeignKey(d => d.UposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poruka_UposlenikID");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.Property(e => e.DatumIzdavanja).HasColumnType("datetime");
            });

            modelBuilder.Entity<RezervacijaFilma>(entity =>
            {
                entity.Property(e => e.RezervacijaFilmaId).HasColumnName("RezervacijaFilmaID");

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.RacunId).HasColumnName("RacunID");

                entity.Property(e => e.RezervacijaDo).HasColumnType("datetime");

                entity.Property(e => e.RezervacijaOd).HasColumnType("datetime");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.RezervacijaFilma)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezervacijaFilma_FilmID");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.RezervacijaFilma)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezervacijaFilma_KlijentID");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.RezervacijaFilma)
                    .HasForeignKey(d => d.RacunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezervacijaFilma_RacunID");
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
