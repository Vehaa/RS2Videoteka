using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI.Profil
{
    public partial class frmProfilIzmjena : Form
    {

        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _gradoviService = new APIService("Grad");

        KorisniciUpsertRequest request = new KorisniciUpsertRequest();
        private int? _korisnikId = null;
        public frmProfilIzmjena(int korisnikId)
        {
            _korisnikId = korisnikId;
            InitializeComponent();
        }

        private async Task LoadGradovi()
        {
            var result = await _gradoviService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DataSource = result;
        }

        private async void frmProfilIzmjena_Load(object sender, EventArgs e)
        {
            await LoadGradovi();

            var korisnik = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);
            var grad = await _gradoviService.GetById<Model.Models.Grad>(korisnik.GradId);

            cmbGrad.SelectedValue = grad.GradId;

            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtEmail.Text = korisnik.Email;
            txtTelefon.Text = korisnik.Telefon;
            txtAdresa.Text = korisnik.Adresa;
            dtpDatumRodjenja.Value = korisnik.DatumRodjenja.Value;
            txtUsername.Text = korisnik.UserName;

            byte[] slika = korisnik.Slika;
            MemoryStream memoryStream = new MemoryStream(slika);
            pictureBox1.Image = Image.FromStream(memoryStream);

            request.Ime = korisnik.Ime;
            request.Prezime = korisnik.Prezime;
            request.Email = korisnik.Email;
            request.Telefon = korisnik.Telefon;
            request.Adresa = korisnik.Adresa;
            request.DatumRodjenja = korisnik.DatumRodjenja;
            request.Slika = korisnik.Slika;
            request.SlikaThumb = korisnik.SlikaThumb;
            request.UserName = korisnik.UserName;
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                var file = File.ReadAllBytes(filename);

                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));

                request.Slika = file;
                request.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            if (ValidateChildren())
            {
                if (_korisnikId.HasValue)
                    request.KorisnikId = (int)_korisnikId;

                var GradObj = cmbGrad.SelectedValue;
                if (int.TryParse(GradObj.ToString(), out int GradId))
                {
                    request.GradId = GradId;
                }
                var user = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);
                var uloge = user.KorisniciUloge.Select(x => x.UlogaId).ToList();

                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Email = txtEmail.Text;
                request.Telefon = txtTelefon.Text;
                request.Adresa = txtAdresa.Text;
                request.DatumRodjenja = dtpDatumRodjenja.Value;
                request.DatumRegistracije = user.DatumRegistracije;
                request.Uloge = uloge;
                request.Status = true;
                request.UserName = txtUsername.Text;

                

                var entity = await _korisniciService.Update<Model.Models.Korisnici>(request.KorisnikId, request);

                if (entity != null)
                {
                    MessageBox.Show("Podaci uspješno izmjenjeni!");
                    Close();
                    
                }
            }

        }

        

        private async void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            bool postoji = false;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest()
                {
                    Status = true,
                    UserName = txtUsername.Text
                };


                var user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {
                    foreach (var item in user)
                    {
                        if (item.KorisnikId != _korisnikId)
                            postoji = true;
                    }
                }

                korisniciSearch.Status = false;
                user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {
                    foreach (var item in user)
                    {
                        if (item.KorisnikId != _korisnikId)
                            postoji = true;
                    }
                }

                if (postoji)
                {
                    errorProvider.SetError(txtUsername, "Korisničko ime zauzeto!");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtUsername, null);
            }
        }

        private void btnLozinka_Click(object sender, EventArgs e)
        {
            frmPromjenaLozike frm = new frmPromjenaLozike((int)_korisnikId);
            frm.Show();
        }
    }
}
