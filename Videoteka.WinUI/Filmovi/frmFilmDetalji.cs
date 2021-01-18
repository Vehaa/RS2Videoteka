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

namespace Videoteka.WinUI.Filmovi
{
    public partial class frmFilmDetalji : Form
    {

        private readonly APIService _drzaveService = new APIService("Drzava");
        private readonly APIService _zanrService = new APIService("Zanr");
        private readonly APIService _filmoviService = new APIService("Film");
        private readonly APIService _reziseriService = new APIService("Reziser");

        FilmUpsertRequest request = new FilmUpsertRequest();

        private int? _filmId = null;
        public frmFilmDetalji(int filmId)
        {
            _filmId = filmId;
            InitializeComponent();
        }

        private async void frmFilmDetalji_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            await LoadZanrovi();
            await LoadReziseri();
            if (_filmId.HasValue)
            { 
                var film = await _filmoviService.GetById<Model.Models.Film>(_filmId);
                var drzava = await _drzaveService.GetById<Model.Models.Drzava>(film.DrzavaId);
                var zanr = await _zanrService.GetById<Model.Models.Zanr>(film.ZanrId);
                var direktor = await _reziseriService.GetById<Model.Models.Reziser>(film.ReziserId);
                direktor.ReziserId = film.ReziserId;
                cmbDrzava.SelectedValue = drzava.DrzavaId;
                cmbZanr.SelectedValue= zanr.ZanrId;
                cmbReditelj.SelectedIndex = film.ReziserId;

                txtNaziv.Text = film.Naziv;
                txtGlumac.Text = film.Glumac;
                txtJezik.Text = film.Jezik;
                txtGodina.Text = film.Godina.ToString();
                cbDostupan.Checked = film.Dostupan;
                mtxtTrajanje.Text = film.Trajanje.ToString();
                txtOpis.Text = film.Opis;
                mtxtCijena.Text = film.CijenaIznajmljivanja.ToString();

                byte[] slika = film.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox1.Image = Image.FromStream(memoryStream);

                request.Naziv = film.Naziv;
                request.Glumac = film.Glumac;
                request.Jezik = film.Jezik;
                request.Godina = film.Godina;
                request.Trajanje = film.Trajanje;
                request.CijenaIznajmljivanja = film.CijenaIznajmljivanja;
                request.Opis = film.Opis;
                request.Slika = film.Slika;
                request.SlikaThumb = film.SlikaThumb;
            }
        }
        private async Task LoadReziseri()
        {
            var result = await _reziseriService.Get<List<Model.Models.Reziser>>(null);
            result.Insert(0, new Model.Models.Reziser());
            cmbReditelj.DisplayMember = "_imePrezime";
            cmbReditelj.ValueMember = "ReziserId";
            cmbReditelj.DataSource = result;
        }
        private async Task LoadDrzave()
        {
            var result = await _drzaveService.Get<List<Model.Models.Drzava>>(null);
            result.Insert(0, new Model.Models.Drzava());
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "DrzavaId";
            cmbDrzava.DataSource = result;
        }

        private async Task LoadZanrovi()
        {
            var result = await _zanrService.Get<List<Model.Models.Zanr>>(null);
            result.Insert(0, new Model.Models.Zanr());
            cmbZanr.DisplayMember = "Naziv";
            cmbZanr.ValueMember = "ZanrId";
            cmbZanr.DataSource = result;
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
            if (_filmId.HasValue)
            {
                request.FilmId =(int) _filmId;
            }
            request.Dostupan = cbDostupan.Checked;
            request.ZanrId = cmbZanr.SelectedIndex;
            request.DrzavaId = cmbDrzava.SelectedIndex;
            request.ReziserId = cmbReditelj.SelectedIndex;
            request.Naziv = txtNaziv.Text;
            request.Glumac = txtGlumac.Text;
            request.Jezik = txtJezik.Text;
            request.Godina = int.Parse(txtGodina.Text);
            request.Trajanje = decimal.Parse(mtxtTrajanje.Text);
            request.CijenaIznajmljivanja = decimal.Parse(mtxtCijena.Text);
            request.Opis = txtOpis.Text;

            var entity = await _filmoviService.Update<Model.Models.Film>(request.FilmId, request);

            if (entity != null)
            {
                MessageBox.Show("Uspješno izmjenjeni podaci o filmu!");
                _filmId = 0;
                Close();
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtNaziv, null);

            }
        }

        private void txtGlumac_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGlumac.Text))
            {
                errorProvider.SetError(txtGlumac, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtGlumac, null);

            }
        }

        

        private void txtJezik_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJezik.Text))
            {
                errorProvider.SetError(txtJezik, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtJezik, null);

            }
        }

        private void txtGodina_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGodina.Text))
            {
                errorProvider.SetError(txtGodina, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtGodina, null);

            }
        }

        private void cmbZanr_Validating(object sender, CancelEventArgs e)
        {
            var ZanrObj = cmbZanr.SelectedValue;

            if (ZanrObj == null || ZanrObj.ToString() == "0")
            {
                errorProvider.SetError(cmbZanr, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(cmbZanr, null);
            }
        }

        private void cmbDrzava_Validating(object sender, CancelEventArgs e)
        {
            var DrzavaObj = cmbDrzava.SelectedValue;

            if (DrzavaObj == null || DrzavaObj.ToString() == "0")
            {
                errorProvider.SetError(cmbDrzava, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(cmbDrzava, null);
            }
        }

        private void mtxtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtxtTrajanje.Text))
            {
                errorProvider.SetError(mtxtTrajanje, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(mtxtTrajanje, null);

            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider.SetError(txtOpis, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtOpis, null);

            }
        }

        private void mtxtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtxtCijena.Text))
            {
                errorProvider.SetError(mtxtCijena, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(mtxtCijena, null);

            }
        }

        private void mtxtTrajanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void mtxtCijena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGodina_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cmbReditelj_Validating(object sender, CancelEventArgs e)
        {
            var dirObj = cmbReditelj.SelectedValue;

            if (dirObj == null || dirObj.ToString() == "0")
            {
                errorProvider.SetError(cmbReditelj, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(cmbReditelj, null);
            }
        }
    }
}
