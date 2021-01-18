using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI.Profil
{
    public partial class frmPromjenaLozike : Form
    {

        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");
        KorisniciUpsertRequest request = new KorisniciUpsertRequest();

        public int _korisnikId;
        public frmPromjenaLozike(int korisnikId)
        {
            _korisnikId = korisnikId;
            InitializeComponent();
        }

        private void frmPromjenaLozike_Load(object sender, EventArgs e)
        {

        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        private async void txtStariPassword_Validating(object sender, CancelEventArgs e)
        {
            bool izmjena = false;
            if (!string.IsNullOrEmpty(txtNoviPassword.Text) || !string.IsNullOrEmpty(txtNoviPasswordPotvrda.Text))
            {
                izmjena = true;
            }

            //Ako nije unesena stara lozinka
            if (string.IsNullOrEmpty(txtStariPassword.Text) && izmjena)
            {
                errorProvider.SetError(txtStariPassword, "Netačan stari password!");
                e.Cancel = true;
            }

            else if (!string.IsNullOrEmpty(txtStariPassword.Text) && izmjena)
            {
                var user = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);

                string hash = GenerateHash(user.LozinkaSalt, txtStariPassword.Text);

                if (user.LozinkaHash != hash)
                {
                    errorProvider.SetError(txtStariPassword, "Netačan stari password!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtStariPassword, null);
                }
            }
            else if (string.IsNullOrEmpty(txtStariPassword.Text) && !izmjena)
            {
                errorProvider.SetError(txtStariPassword, null);
            }
            else if (!string.IsNullOrEmpty(txtStariPassword.Text) && !izmjena)
            {
                var user = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);

                string hash = GenerateHash(user.LozinkaSalt, txtStariPassword.Text);

                if (user.LozinkaHash != hash)
                {
                    errorProvider.SetError(txtStariPassword, "Netačan stari password!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtStariPassword, null);
                }
            }

        }


        private void txtNoviPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (txtNoviPassword.Text != txtNoviPasswordPotvrda.Text)
            {
                errorProvider.SetError(txtNoviPasswordPotvrda, "Passwordi se ne slažu!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNoviPasswordPotvrda, null);
            }
        }

        private async void bntSacuvaj_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            if (ValidateChildren())
            {

                var user = await _korisniciService.GetById<Model.Models.Korisnici>(_korisnikId);
                KorisniciUlogeSearchRequest ku = new KorisniciUlogeSearchRequest
                {
                    KorisnikId = user.KorisnikId
                };
                var uloge = await _korisniciUlogeService.Get<List<Model.Models.KorisniciUloge>>(ku);
                List<int> uloge1 = new List<int>();
                foreach (var item in uloge)
                {
                    uloge1.Add(item.UlogaId);
                }

                request.Ime = user.Ime;
                request.Prezime = user.Prezime;
                request.Email = user.Email;
                request.Telefon = user.Telefon;
                request.Adresa = user.Adresa;
                request.DatumRegistracije = user.DatumRegistracije;
                request.DatumRodjenja = user.DatumRodjenja;
                request.Uloge = uloge1;
                request.Status = true;
                request.UserName = user.UserName;
                request.Password = txtNoviPassword.Text;
                request.PasswordPotvrda = txtNoviPasswordPotvrda.Text;
                request.GradId = user.GradId;
                request.Slika = user.Slika;
                request.SlikaThumb = user.SlikaThumb;

                var entity = await _korisniciService.Update<Model.Models.Korisnici>(_korisnikId, request);

                if (entity != null)
                {
                    MessageBox.Show("Uspješno ste promjenili lozinku!");
                    Close();
                }
            }
        }

        private void txtNoviPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoviPassword.Text))
            {
                errorProvider.SetError(txtNoviPassword, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtNoviPassword, null);
        }
    }
}
