using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _filmoviService = new APIService("Film");
        private readonly APIService _klijentService = new APIService("Klijent");

        public string _ukupnoRezervacija, _rezervacijaM, _rezervacijaG;
        public string _ukupnoFilmova, _filmovaD, _filmovaN;
        public string _ukupnoKlijenata, _klijenataM, _klijenataG;

        private void pnlBrojRezervacija_MouseClick(object sender, MouseEventArgs e)
        {
            frmIRezervacijaUkupno frm = new frmIRezervacijaUkupno();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pnlProsjek_MouseClick(object sender, MouseEventArgs e)
        {
            frmRezervacijaZaradaM frm = new frmRezervacijaZaradaM();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pnlZaradaGodina_MouseClick(object sender, MouseEventArgs e)
        {
            frmRezervracijaZaradaG frm = new frmRezervracijaZaradaG();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pnlUkupnaZarada_MouseClick(object sender, MouseEventArgs e)
        {
            frmRezervacijeUkupnaZarada frm = new frmRezervacijeUkupnaZarada();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pnlBrojFilmova_MouseClick(object sender, MouseEventArgs e)
        {
            frmFilmoviBroj frm = new frmFilmoviBroj();
            frm.Show();
        }

        private void pnlFilmoviDostupni_MouseClick(object sender, MouseEventArgs e)
        {
            frmFilmoviDostupni frm = new frmFilmoviDostupni();
            frm.Show();
        }

        private void pnlFilmoviNedostupni_MouseClick(object sender, MouseEventArgs e)
        {
            frmFilmoviNedostupni frm = new frmFilmoviNedostupni();
            frm.Show();
        }

        private void pnlBrojKlijenata_MouseClick(object sender, MouseEventArgs e)
        {
            frmKlijentiBroj frm = new frmKlijentiBroj();
            frm.Show();
        }

        private void pnlKlijentiMjesec_MouseClick(object sender, MouseEventArgs e)
        {
            frmKlijentiM frm = new frmKlijentiM();
            frm.Show();
        }

        private void pnlKlijentiGodina_MouseClick(object sender, MouseEventArgs e)
        {
            frmKlijentiG frm = new frmKlijentiG();
            frm.Show();
        }

        private void pnlRezervacijeGodina_MouseClick(object sender, MouseEventArgs e)
        {
            frmIRezervacijaG frm = new frmIRezervacijaG();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        public string _prosjekRezervacija, _ukupnaZarada, _zaradaOveGodine;


        private void pnlRezervacijeMjesec_MouseClick(object sender, MouseEventArgs e)
        {
            frmIRezervacijaM frm = new frmIRezervacijaM();
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }


        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        private async void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
        }

        private async Task Inicijaliziraj()
        {
            RezervacijaFilmaSearchRequest rezervacijeSearch = new RezervacijaFilmaSearchRequest
            {
                Otkazana = false
            };

            var rezervacije = await _rezervacijeService.Get<List<Model.Models.RezervacijaFilma>>(rezervacijeSearch);

            _ukupnoRezervacija = rezervacije.Count().ToString();

            int rezervacijeM=0, rezervacijeG = 0;
            double prosjek = 0;
            double zaradaOveG = 0;

            foreach (var item in rezervacije)
            {
                if (item.DatumKreiranja.Month == DateTime.Now.Month)
                    rezervacijeM++;
                if (item.DatumKreiranja.Year == DateTime.Now.Year)
                {
                    zaradaOveG += (double)item.IznosSaPopustom;
                    rezervacijeG++;
                }
                prosjek += (double)item.IznosSaPopustom;
            }
            _prosjekRezervacija = (prosjek / rezervacije.Count()).ToString();
            _ukupnaZarada = prosjek.ToString();
            _rezervacijaM = rezervacijeM.ToString();
            _rezervacijaG = rezervacijeG.ToString();
            _zaradaOveGodine = zaradaOveG.ToString();

            FilmSearchRequest filmSearch = new FilmSearchRequest
            {
                Dostupan = true
            };
            var filmoviD = await _filmoviService.Get<List<Model.Models.Film>>(filmSearch);
            _filmovaD = filmoviD.Count().ToString();
            int sviFilmovi = filmoviD.Count();

            filmSearch.Dostupan = false;
            var filmoviN = await _filmoviService.Get<List<Model.Models.Film>>(filmSearch);
            _filmovaN = filmoviN.Count().ToString();
            sviFilmovi += filmoviN.Count();
            _ukupnoFilmova = sviFilmovi.ToString();

            KlijentSearchRequest klijentSearch = new KlijentSearchRequest
            {
                Status = true
            };
            var klijentiA = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            int klijenataM=0, klijenataG = 0;

            int ukupnoKlijenata = klijentiA.Count();
            foreach (var item in klijentiA)
            {
                if (item.DatumRegistracije.Month == DateTime.Now.Month)
                    klijenataM++;

                if (item.DatumRegistracije.Year == DateTime.Now.Year)
                    klijenataG++;
            }
            klijentSearch.Status = false;
            var klijentiN = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            ukupnoKlijenata += klijentiN.Count();
            _ukupnoKlijenata = ukupnoKlijenata.ToString();
            _klijenataM = klijenataM.ToString();
            _klijenataG = klijenataG.ToString();


        }





    }
}
