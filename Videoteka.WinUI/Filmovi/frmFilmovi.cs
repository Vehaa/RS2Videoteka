using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;


namespace Videoteka.WinUI.Filmovi
{
    public partial class frmFilmovi : Form
    {

        private readonly APIService _drzaveService = new APIService("Drzava");
        private readonly APIService _zanrService = new APIService("Zanr");
        private readonly APIService _filmoviService = new APIService("Film");
        private readonly APIService _reziseriService = new APIService("Reziser");
        public frmFilmovi()
        {
            InitializeComponent();
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

        private async void frmFilmovi_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            await LoadZanrovi();
            await LoadReziseri();
            cbDostupan.Checked = true;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new FilmSearchRequest();
            search.Dostupan = cbDostupan.Checked;
            var DrzavaObj = cmbDrzava.SelectedValue;
            var ZanrObj = cmbZanr.SelectedValue;
            var DirObj = cmbDirektor.SelectedIndex;

            if (DirObj != null)
            {
                search.ReziserId = int.Parse(DirObj.ToString());
            }

            if (DrzavaObj != null)
            {
                search.DrzavaId = int.Parse(DrzavaObj.ToString());
            }

            if (ZanrObj != null)
            {
                search.ZanrId = int.Parse(ZanrObj.ToString());
            }

            if (txtNaziv.Text != "")
            {
                search.Naziv = txtNaziv.Text.ToLower();
            }

            if (txtJezik.Text != "")
            {
                search.Jezik = txtJezik.Text.ToLower();
            }

            if (txtGodina.Text != "")
            {
                search.Godina = int.Parse(txtGodina.Text);
            }

            if (txtGlumac.Text != "")
            {
                search.Glumac = txtGlumac.Text.ToLower();
            }

            //if (txtDirektor.Text != "")
            //{
            //    search.Direktor = txtDirektor.Text.ToLower();
            //}

            var result = await _filmoviService.Get<List<Model.Models.Film>>(search);

            dgvFilmovi.AutoGenerateColumns = false;
            dgvFilmovi.DataSource = result;
        }

        private void dgvFilmovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvFilmovi.SelectedRows[0].Cells[0].Value;

            frmFilmDetalji frm = new frmFilmDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
