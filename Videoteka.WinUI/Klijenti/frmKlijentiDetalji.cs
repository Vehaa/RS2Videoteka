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

namespace Videoteka.WinUI.Klijenti
{
    public partial class frmKlijentiDetalji : Form
    {

        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _klijentiService = new APIService("Klijent");

        KlijentUpsertRequest request = new KlijentUpsertRequest();
        private int? _klijentId = null;

        public frmKlijentiDetalji(int klijentId)
        {
            _klijentId = klijentId;
            InitializeComponent();
        }

        private async void frmKlijentiDetalji_Load(object sender, EventArgs e)
        {
            if (_klijentId.HasValue)
            {
                var klijent = await _klijentiService.GetById<Model.Models.Klijent>(_klijentId);
                var grad = await _gradoviService.GetById<Model.Models.Grad>(klijent.GradId);

                txtIme.Text = klijent.Ime;
                txtPrezime.Text = klijent.Prezime;
                txtAdresa.Text = klijent.Adresa;
                txtDatumRegistracije.Text = klijent.DatumRegistracije.ToShortDateString();
                txtDatumRodjenja.Text = klijent.DatumRodjenja.ToShortDateString();
                txtEmail.Text = klijent.Email;
                txtGrad.Text = grad.Naziv;
                txtTelefon.Text = klijent.Telefon;
                cbStatus.Checked = klijent.Status;

                byte[] slika = klijent.Slika;
                
                if (slika.Length>0)
                {
                    MemoryStream memoryStream = new MemoryStream(slika);
                    pictureBox1.Image = Image.FromStream(memoryStream);
                }
                else
                {
                    var filename = Properties.Resources.no_image;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);



                    pictureBox1.Image = Image.FromStream(ms);
                }
                

                request.Ime = klijent.Ime;
                request.Prezime = klijent.Prezime;
                request.Email = klijent.Email;
                request.Telefon = klijent.Telefon;
                request.Adresa = klijent.Adresa;
                request.DatumRodjenja = klijent.DatumRodjenja;
                request.DatumRegistracije = klijent.DatumRegistracije;
                request.GradId = klijent.GradId;
                request.Status = klijent.Status;
                request.UserName = klijent.UserName;
                request.Slika = klijent.Slika;
                request.SlikaThumb = klijent.SlikaThumb;

            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            request.Status = cbStatus.Checked;
            if (_klijentId.HasValue)
                request.KlijentId = (int)_klijentId;

            var entity = await _klijentiService.Update<Model.Models.Korisnici>(request.KlijentId, request);
            if (entity != null)
            {
                MessageBox.Show("Uspješno izmjenjeni podaci o klijentu!");
                _klijentId = 0;
                Close();
            }
        }
    }
}
