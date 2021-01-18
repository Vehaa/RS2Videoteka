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
    public partial class frmNoviFilm : Form
    {


        private readonly APIService _drzaveService = new APIService("Drzava");
        private readonly APIService _zanrService = new APIService("Zanr");
        private readonly APIService _filmoviService = new APIService("Film");
        private readonly APIService _reziseriService = new APIService("Reziser");

        FilmUpsertRequest request = new FilmUpsertRequest();

        public frmNoviFilm()
        {
            InitializeComponent();
        }

        private async void frmNoviFilm_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            await LoadZanrovi();
            await LoadSlika();
            await LoadReziseri();
            cbDostupan.Checked = true;
        }
        private async Task LoadReziseri()
        {
            var result = await _reziseriService.Get<List<Model.Models.Reziser>>(null);
            result.Insert(0, new Model.Models.Reziser());
            cmbDirektor.DisplayMember = "_imePrezime";
            cmbDirektor.ValueMember = "ReziserId";
            cmbDirektor.DataSource = result;
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
            bool provjera = this.ValidateChildren();
            if (provjera)
            {
                var DrzavaIdObj = cmbDrzava.SelectedValue;
                var ZanrIdObj = cmbZanr.SelectedValue;
                var dirOBj = cmbDirektor.SelectedIndex;

                if (int.TryParse(dirOBj.ToString(), out int rId))
                {
                    request.ReziserId = rId;
                }

                if (int.TryParse(DrzavaIdObj.ToString(),out int dId))
                {
                    request.DrzavaId = dId;
                }

                if (int.TryParse(ZanrIdObj.ToString(), out int zId))
                {
                    request.ZanrId = zId;
                }

                if (request.Slika == null)
                {
                    var filename = Properties.Resources.movieDefault;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    request.Slika = ms.ToArray();

                    Image image = Image.FromStream(new MemoryStream(request.Slika));
                    Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                    ImageConverter _imageConverter = new ImageConverter();
                    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                    request.SlikaThumb = imagethumbbyte;
                }

                request.Naziv = txtNaziv.Text;
                request.Glumac = txtGlumac.Text;
                request.Jezik = txtJezik.Text;
                if (int.TryParse(txtGodina.Text, out int gId))
                {
                    request.Godina = gId;
                }
                request.Dostupan = cbDostupan.Checked;
                if(decimal.TryParse(mtxtTrajanje.Text,out decimal tId))
                {
                    request.Trajanje = tId;
                }
                request.Opis = txtOpis.Text;
                if (decimal.TryParse(mtxtCijena.Text, out decimal cId))
                {
                    request.CijenaIznajmljivanja = cId;
                }


                var entity = await _filmoviService.Insert<Model.Models.Film>(request);

                if (entity != null)
                {
                    MessageBox.Show("Film uspješno dodan!");
                    Close();
                }
            }
        }

        private async Task LoadSlika()
        {
            var filename = Properties.Resources.movieDefault;
            MemoryStream ms = new MemoryStream();
            filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            Image image = Image.FromStream(ms);
            pictureBox1.Image = image;
        }


        //Validacija
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

        private void cmbDirektor_Validating(object sender, CancelEventArgs e)
        {
            var dirObj = cmbDirektor.SelectedValue;

            if (dirObj == null || dirObj.ToString() == "0")
            {
                errorProvider.SetError(cmbDirektor, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(cmbDirektor, null);
            }
        }
    }
}
