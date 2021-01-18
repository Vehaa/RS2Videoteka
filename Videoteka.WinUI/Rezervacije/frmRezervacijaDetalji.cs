using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;
using Videoteka.WinUI.Poruke;

namespace Videoteka.WinUI.Rezervacije
{
    public partial class frmRezervacijaDetalji : Form
    {

        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _filmService = new APIService("Film");
        private readonly APIService _klijentService = new APIService("Klijent");

        RezervacijaFilmaUpsertRequest upsert = new RezervacijaFilmaUpsertRequest();

        public int _rezervacijaId, _userId;

        private async void frmRezervacijaDetalji_Load(object sender, EventArgs e)
        {
            var rezervacija = await _rezervacijeService.GetById<Model.Models.RezervacijaFilma>(_rezervacijaId);
            var film = await _filmService.GetById<Model.Models.Film>(rezervacija.FilmId);

            var klijent = await _klijentService.GetById<Model.Models.Klijent>(rezervacija.KlijentId);

            upsert.FilmId = rezervacija.FilmId;
            upsert.KlijentId = rezervacija.KlijentId;
            upsert.RacunId = rezervacija.RacunId;
            upsert.DatumKreiranja = rezervacija.DatumKreiranja;
            upsert.RezervacijaOd = rezervacija.RezervacijaOd;
            upsert.RezervacijaDo = rezervacija.RezervacijaDo;
            upsert.Iznos = rezervacija.Iznos;
            upsert.IznosSaPopustom = rezervacija.IznosSaPopustom;
            upsert.Popust = rezervacija.Popust;

            if (film.Slika.Length > 0)
            {
                byte[] slika = film.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }

            txtKlijent.Text = klijent.Ime + " " + klijent.Prezime;
            txtFilmInfo.Text = rezervacija.FilmInformacije;
            txtOdDo.Text = rezervacija.RezervacijaOdDo;
            txtPopust.Text = rezervacija.Popust.ToString();
            txtIznosSaPopustom.Text = rezervacija.IznosSaPopustom.ToString()+" KM";
            cbOtkazana.Checked = (bool)rezervacija.Otkazana;

            if(rezervacija.RezervacijaDo<DateTime.Now || (bool)rezervacija.Otkazana)
            {
                txtPopust.Enabled = false;
            }


        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            if (provjera)
            {
                upsert.Popust = double.Parse(txtPopust.Text);
                var popust = Convert.ToDecimal(upsert.Popust);
                upsert.IznosSaPopustom = upsert.Iznos - (upsert.Iznos * popust);
                upsert.Otkazana = cbOtkazana.Checked;
                upsert.RezervacijaFilmaId = _rezervacijaId;

                var entity = await _rezervacijeService.Update<Model.Models.RezervacijaFilma>(_rezervacijaId, upsert);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izmjenjeni podaci o rezervaciji!");
                    _rezervacijaId = 0;
                    Close();
                }
            }
        }

        private void btnPosalji_Click(object sender, EventArgs e)
        {
            frmNovaPoruka frm = new frmNovaPoruka(_rezervacijaId, _userId);
            Close();
            frm.Show();
        }

        public frmRezervacijaDetalji(int rezervacijaId,int userId)
        {
            _rezervacijaId = rezervacijaId;
            _userId = userId;
            InitializeComponent();
        }
    }
}
