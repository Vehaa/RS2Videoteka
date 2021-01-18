using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Videoteka.WebAPI.Migrations
{
    public partial class Inicijalno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false),
                    PostanskiBroj = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    UkupanIznos = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunID);
                });

            migrationBuilder.CreateTable(
                name: "Reziser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reziser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime", nullable: false),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(maxLength: 100, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentID);
                    table.ForeignKey(
                        name: "FK_Klijent_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: true),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(maxLength: 100, nullable: true),
                    LozinkaHash = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZanrID = table.Column<int>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false),
                    ReziserID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Glumac = table.Column<string>(maxLength: 50, nullable: false),
                    Opis = table.Column<string>(maxLength: 200, nullable: false),
                    Godina = table.Column<int>(nullable: false),
                    Trajanje = table.Column<decimal>(nullable: false),
                    Jezik = table.Column<string>(maxLength: 200, nullable: false),
                    Dostupan = table.Column<bool>(nullable: false),
                    CijenaIznajmljivanja = table.Column<decimal>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmID);
                    table.ForeignKey(
                        name: "FK_Film_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Film_Reziser_ReziserID",
                        column: x => x.ReziserID,
                        principalTable: "Reziser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_ZanrID",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisniciUlogeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnikID = table.Column<int>(nullable: false),
                    UlogaID = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisniciUlogeID);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervacijaFilma",
                columns: table => new
                {
                    RezervacijaFilmaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RacunID = table.Column<int>(nullable: false),
                    FilmID = table.Column<int>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    RezervacijaOd = table.Column<DateTime>(type: "datetime", nullable: false),
                    RezervacijaDo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Otkazana = table.Column<bool>(nullable: true),
                    Popust = table.Column<double>(nullable: false),
                    IznosSaPopustom = table.Column<decimal>(nullable: true),
                    Iznos = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervacijaFilma", x => x.RezervacijaFilmaID);
                    table.ForeignKey(
                        name: "FK_RezervacijaFilma_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervacijaFilma_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervacijaFilma_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Racun",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RezervacijaFilmaID = table.Column<int>(nullable: false),
                    DatumEvidentiranja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ocjena = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.OcjenaID);
                    table.ForeignKey(
                        name: "FK_Ocjena_RezervacijaFilma_RezervacijaFilmaID",
                        column: x => x.RezervacijaFilmaID,
                        principalTable: "RezervacijaFilma",
                        principalColumn: "RezervacijaFilmaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    PorukaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RezervacijaFilmaID = table.Column<int>(nullable: false),
                    KlijentID = table.Column<int>(nullable: false),
                    UposlenikID = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(maxLength: 100, nullable: false),
                    Sadrzaj = table.Column<string>(nullable: false),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime", nullable: false),
                    Procitano = table.Column<bool>(nullable: false),
                    Posiljaoc = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.PorukaID);
                    table.ForeignKey(
                        name: "FK_Poruka_Klijent_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijent",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruka_RezervacijaFilmaID",
                        column: x => x.RezervacijaFilmaID,
                        principalTable: "RezervacijaFilma",
                        principalColumn: "RezervacijaFilmaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruka_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_DrzavaID",
                table: "Film",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ReziserID",
                table: "Film",
                column: "ReziserID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ZanrID",
                table: "Film",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_GradID",
                table: "Klijent",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_GradID",
                table: "Korisnici",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjena_RezervacijaFilmaID",
                table: "Ocjena",
                column: "RezervacijaFilmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_KlijentID",
                table: "Poruka",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_RezervacijaFilmaID",
                table: "Poruka",
                column: "RezervacijaFilmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_UposlenikID",
                table: "Poruka",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaFilma_FilmID",
                table: "RezervacijaFilma",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaFilma_KlijentID",
                table: "RezervacijaFilma",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervacijaFilma_RacunID",
                table: "RezervacijaFilma",
                column: "RacunID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "Ocjena");

            migrationBuilder.DropTable(
                name: "Poruka");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "RezervacijaFilma");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Reziser");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
