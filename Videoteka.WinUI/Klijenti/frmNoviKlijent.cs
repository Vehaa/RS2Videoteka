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
    public partial class frmNoviKlijent : Form
    {

        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _klijentiService = new APIService("Klijent");

        KlijentUpsertRequest request = new KlijentUpsertRequest();
        public frmNoviKlijent()
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
            var filename = Properties.Resources._default;
            MemoryStream ms = new MemoryStream();
            filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Image image = Image.FromStream(ms);
            pictureBox1.Image = image;
        }

        private async void frmNoviKlijent_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            await LoadSlika();
            cbStatus.Checked = true;

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
            if (provjera)
            {
                var gradIdObj = cmbGrad.SelectedValue;

                if (int.TryParse(gradIdObj.ToString(), out int gId))
                {
                    request.GradId = gId;
                }

                if (request.Slika == null)
                {
                    var filename = Properties.Resources._default;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    request.Slika = ms.ToArray();

                    Image image = Image.FromStream(new MemoryStream(request.Slika));
                    Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                    ImageConverter _imageConverter = new ImageConverter();
                    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                    request.SlikaThumb = imagethumbbyte;
                }

                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Email = txtEmail.Text;
                request.Adresa = txtAdresa.Text;
                request.DatumRegistracije = DateTime.Now;
                request.DatumRodjenja = dtpDatumRodjenja.Value;
                request.Status = cbStatus.Checked;
                request.Telefon = txtTelefon.Text;
                request.UserName = txtUsername.Text;
                request.Password = txtPassword.Text;
                request.PasswordPotvrda = txtPasswordPotvrda.Text;

                var entity = await _klijentiService.Insert<Model.Models.Klijent>(request);

                if (entity != null)
                {
                    MessageBox.Show("Klijent uspješno dodan!");

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


        //Validacija
        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);

            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);

            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool postoji = false;
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
                {
                    Status = true,
                    Email = txtEmail.Text
                };

                var users = await _klijentiService.Get<List<Model.Models.Korisnici>>(klijentSearch);

                if (users.Count > 0)
                {
                    postoji = true;
                }

                klijentSearch.Status = false;

                users = await _klijentiService.Get<List<Model.Models.Korisnici>>(klijentSearch);
                if (users.Count > 0)
                {
                    postoji = true;
                }



                if (postoji)
                {
                    errorProvider.SetError(txtEmail, "Email već postoji!");
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtEmail, null);
            }
        
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                errorProvider.SetError(txtTelefon, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);

            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                errorProvider.SetError(txtAdresa, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAdresa, null);

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
                KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
                {
                    Status = true,
                    UserName = txtUsername.Text
                };


                var user = await _klijentiService.Get<List<Model.Models.Klijent>>(klijentSearch);
                if (user.Count > 0)
                {

                    postoji = true;
                }

                klijentSearch.Status = false;
                user = await _klijentiService.Get<List<Model.Models.Klijent>>(klijentSearch);
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
                e.Cancel = false;
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
                    errorProvider.SetError(txtPasswordPotvrda, "Passwordi se ne slažu!");
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

    }
}
