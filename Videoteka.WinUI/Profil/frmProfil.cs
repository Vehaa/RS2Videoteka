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

namespace Videoteka.WinUI.Profil
{
    public partial class frmProfil : Form
    {

        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _gradService = new APIService("Grad");


        KorisniciUpsertRequest request = new KorisniciUpsertRequest();
        private int? _korisnikId = null;
        public frmProfil(int korisnikId)
        {
            _korisnikId = korisnikId;
            InitializeComponent();
        }

        private async void frmProfil_Load(object sender, EventArgs e)
        {
            var korisnik = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);
            var grad = await _gradService.GetById<Model.Models.Grad>(korisnik.GradId);

            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtEmail.Text = korisnik.Email;
            txtTelefon.Text = korisnik.Telefon;
            txtAdresa.Text = korisnik.Adresa;
            txtDatumRodjenja.Text = korisnik.DatumRodjenja.Value.ToShortDateString();
            txtDatumRegistracije.Text = korisnik.DatumRegistracije.Date.ToShortDateString();
            txtGrad.Text = grad.Naziv;
            cbStatus.Checked = korisnik.Status;

            byte[] slika = korisnik.Slika;
            MemoryStream memoryStream = new MemoryStream(slika);
            pictureBox1.Image = Image.FromStream(memoryStream);

        }

        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            frmProfilIzmjena frm = new frmProfilIzmjena((int)_korisnikId);
            frm.Show();
        }

    }
}
