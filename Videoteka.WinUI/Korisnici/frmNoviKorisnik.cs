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
using Videoteka.WinUI.Properties;

namespace Videoteka.WinUI.Korisnici
{
    public partial class frmNoviKorisnik : Form
    {
        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _ulogeService = new APIService("Uloga");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        KorisniciUpsertRequest DodajRequest = new KorisniciUpsertRequest();

        public frmNoviKorisnik()
        {
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
        private async Task LoadSlika()
        {
            var filename = Properties.Resources.profilna;
            MemoryStream ms = new MemoryStream();
            filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Image image = Image.FromStream(ms);
            pictureBox1.Image = image;
        }
        private async void frmNoviKorisnik_Load(object sender, EventArgs e)
        {
           await LoadGradovi();
            await LoadUloge();
            await LoadSlika();
            cbStatus.Checked = true;
            dtpDatumRodjenja.MaxDate = DateTime.Now;
            
        }

        private async Task LoadUloge()
        {
            var result = await _ulogeService.Get<List<Model.Models.Uloge>>(null);
            clbUloge.DataSource = result;
            clbUloge.DisplayMember = "Naziv";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {

            bool provjera = this.ValidateChildren();
            if (ValidateChildren())
            {
                var uloge = clbUloge.CheckedItems.Cast<Model.Models.Uloge>().Select(x => x.UlogaId).ToList();
                var gradIdObj = cmbGrad.SelectedValue;

                if(int.TryParse(gradIdObj.ToString(),out int gId))
                {
                    DodajRequest.GradId = gId;
                }

                if (DodajRequest.Slika == null)
                {
                    var filename =Properties.Resources.no_image;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    DodajRequest.Slika = ms.ToArray();

                    Image image = Image.FromStream(new MemoryStream(DodajRequest.Slika));
                    Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                    ImageConverter _imageConverter = new ImageConverter();
                    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                    DodajRequest.SlikaThumb = imagethumbbyte;
                }

                DodajRequest.Ime = txtIme.Text;
                DodajRequest.Prezime = txtPrezime.Text;
                DodajRequest.Email = txtEmail.Text;
                DodajRequest.Adresa = txtAdresa.Text;
                DodajRequest.DatumRegistracije = DateTime.Now;
                DodajRequest.DatumRodjenja = dtpDatumRodjenja.Value;
                DodajRequest.Status = cbStatus.Checked;
                DodajRequest.Telefon = txtTelefon.Text;
                DodajRequest.UserName = txtUsername.Text;
                DodajRequest.Password = txtPassword.Text;
                DodajRequest.PasswordPotvrda = txtPasswordPotvrda.Text;
                DodajRequest.Uloge = uloge;

                var entity = await _korisniciService.Insert<Model.Models.Korisnici>(DodajRequest);

                if (entity != null)
                {
                    MessageBox.Show("Korisnik uspješno dodan!");

                    cmbGrad.SelectedIndex = -1;
                    txtIme.Clear();
                    txtPrezime.Clear();
                    txtEmail.Clear();
                    txtUsername.Clear();
                    txtTelefon.Clear();
                    txtAdresa.Clear();
                    txtPassword.Clear();
                    txtPasswordPotvrda.Clear();
                    cbStatus.Checked = true;
                    dtpDatumRodjenja.Value = DateTime.Now.Date;
                    Close();

                }
            }
        }

        //Učitavanje slike
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

                DodajRequest.Slika = file;
                DodajRequest.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
                e.Cancel = false;
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
                e.Cancel = false;
            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool postoji = false;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest()
                {
                    Status = true,
                    Email = txtEmail.Text
                };


                var user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {

                    postoji = true;
                }

                korisniciSearch.Status = false;
                user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {

                    postoji = true;
                }

                if (postoji)
                {
                    errorProvider.SetError(txtEmail, "Email je več zauzet!");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);
                e.Cancel = false;
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);
                e.Cancel = false;
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            var GradObj = cmbGrad.SelectedValue;

            if (GradObj == null || GradObj.ToString() == "0")
            {
                errorProvider.SetError(cmbGrad, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGrad, null);
                e.Cancel = false;

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

                    postoji = true;
                }

                korisniciSearch.Status = false;
                user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {

                    postoji = true;
                }

                if (postoji)
                {
                    errorProvider.SetError(txtUsername, "Username je več zauzet!");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text))
            {
                errorProvider.SetError(txtPasswordPotvrda, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (string.Compare(txtPassword.Text, txtPasswordPotvrda.Text) != 0)
                {
                    errorProvider.SetError(txtPasswordPotvrda,"Passwordi se ne slažu!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPasswordPotvrda, null);
                }
            }
            else
            {
                errorProvider.SetError(txtPasswordPotvrda, null);
            }
        }

        private void clbUloge_Validating(object sender, CancelEventArgs e)
        {
            if (clbUloge.CheckedItems.Count < 1)
            {
                errorProvider.SetError(clbUloge, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(clbUloge, null);
            }
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorProvider.SetError(txtIme, "Obavezno polje!");
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        
    }
}
