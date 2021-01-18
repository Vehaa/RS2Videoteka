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

namespace Videoteka.WinUI.Korisnici
{
    public partial class frmKorisniciDetalji : Form
    {
        private readonly APIService _Korisniciservice = new APIService("Korisnici");
        private readonly APIService _gradService = new APIService("Grad");
        private readonly APIService _ulogeService = new APIService("Uloga");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        KorisniciUpsertRequest request = new KorisniciUpsertRequest();
        private int? _korisnikId = null;
        public frmKorisniciDetalji(int korisnikId)
        {
            _korisnikId = korisnikId;
            InitializeComponent();
        }

        private async void frmKorisniciDetalji_Load(object sender, EventArgs e)
        {
            await LoadUloge();
            if (_korisnikId.HasValue)
            {
                var korisnik = await _Korisniciservice.GetById<Model.Models.Korisnici>(_korisnikId);
                var grad = await _gradService.GetById<Model.Models.Grad>(korisnik.GradId);
                KorisniciUlogeSearchRequest searchRequest = new KorisniciUlogeSearchRequest
                {
                    KorisnikId = korisnik.KorisnikId
                };
                var userUloge = await _korisniciUlogeService.Get<List<Model.Models.KorisniciUloge>>(searchRequest);

                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtTelefon.Text = korisnik.Telefon;
                txtAdresa.Text = korisnik.Adresa;
                txtDatumRegistracije.Text = korisnik.DatumRegistracije.Date.ToShortDateString();
                if (korisnik.DatumRodjenja != null)
                    txtDatumRodjenja.Text = korisnik.DatumRodjenja.Value.ToShortDateString();
                txtGrad.Text = grad.Naziv;
                cbStatus.Checked = korisnik.Status;
                for (int i = 0; i < userUloge.Count; i++)
                {
                    foreach (var item in clbUloge.Items.Cast<Model.Models.Uloge>().ToList())
                    {
                        if (item.UlogaId == userUloge.ElementAt(i).UlogaId)
                            clbUloge.SetItemChecked(userUloge.ElementAt(i).UlogaId - 1, true);
                    }
                }
                byte[] slika = korisnik.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox1.Image = Image.FromStream(memoryStream);

                request.Ime = korisnik.Ime;
                request.Prezime = korisnik.Prezime;
                request.Email = korisnik.Email;
                request.Telefon = korisnik.Telefon;
                request.Adresa = korisnik.Adresa;
                request.DatumRodjenja = korisnik.DatumRodjenja;
                request.DatumRegistracije = korisnik.DatumRegistracije;
                request.GradId = korisnik.GradId;
                request.Status = korisnik.Status;
                request.UserName = korisnik.UserName;
                request.Slika = korisnik.Slika;
                request.SlikaThumb = korisnik.SlikaThumb;
            }
        }

        private async Task LoadUloge()
        {
            var result = await _ulogeService.Get<List<Model.Models.Uloge>>(null);
            clbUloge.DataSource = result;
            clbUloge.DisplayMember = "Naziv";
            clbUloge.ValueMember = "UlogaId";
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            request.Status = cbStatus.Checked;
            if(_korisnikId.HasValue)
                request.KorisnikId = (int)_korisnikId;
            var uloge = clbUloge.CheckedItems.Cast<Model.Models.Uloge>().Select(x => x.UlogaId).ToList();

            request.Uloge = uloge;

            var entity = await _Korisniciservice.Update<Model.Models.Korisnici>(request.KorisnikId, request);
            if (entity != null)
            {
                MessageBox.Show("Uspješno izmjenjeni podaci o korisniku");
                _korisnikId = 0;
                Close();
            }
        }

        private void clbUloge_Validating(object sender, CancelEventArgs e)
        {
            if (clbUloge.CheckedItems.Count < 1)
            {
                errorProvider.SetError(clbUloge, Properties.Resources.Validation_RequiredField);
            }
            else
                errorProvider.SetError(clbUloge, null);
        }
    }
}
