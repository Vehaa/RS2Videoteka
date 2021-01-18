using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _ulogeService = new APIService("Uloga");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        public frmKorisnici()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest();
            var GradObj = cmbSearchGrad.SelectedValue;

            if (GradObj!=null)
            {
                search.GradId = int.Parse(GradObj.ToString());
            }

            if (txtSearchIme.Text != "")
            {
                search.Ime = txtSearchIme.Text.ToLower();
            }

            if (txtSearchPrezime.Text != "")
            {
                search.Prezime = txtSearchPrezime.Text.ToLower();
            }

            if (txtSearchUsername.Text != "")
            {
                search.UserName = txtSearchUsername.Text.ToLower();
            }

            search.Status = true;


            var result = await _korisniciService.Get<List<Model.Models.Korisnici>>(search);

            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }

        private void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKorisnici.SelectedRows[0].Cells[0].Value;

            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            
        }

        private async Task LoadGradovi()
        {
            var result = await _gradoviService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());
            cmbSearchGrad.DisplayMember = "Naziv";
            cmbSearchGrad.ValueMember = "GradId";
            cmbSearchGrad.DataSource = result;
        }

      

        
    }
}
