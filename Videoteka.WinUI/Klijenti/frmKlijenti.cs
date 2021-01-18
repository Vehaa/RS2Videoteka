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

namespace Videoteka.WinUI.Klijenti
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _klijentiService = new APIService("Klijent");

        public frmKlijenti()
        {
            InitializeComponent();
        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            dtpDatumRegistracijeOd.MinDate = DateTime.MinValue;
            dtpDatumRegistracijeOd.MaxDate = DateTime.Now;
            dtpDatumRegistracijeOd.Value = dtpDatumRegistracijeOd.MinDate;
            dtpDatumRegistracijeDo.MaxDate = DateTime.Now;
            dtpDatumRegistracijeDo.Value = dtpDatumRegistracijeDo.MaxDate;
            cbStatus.Checked = true;
        }

        private async Task LoadGradovi()
        {
            var result = await _gradoviService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());
            cmbSearchGrad.DisplayMember = "Naziv";
            cmbSearchGrad.ValueMember = "GradId";
            cmbSearchGrad.DataSource = result;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KlijentSearchRequest();
            search.Status = cbStatus.Checked;
            var GradObj = cmbSearchGrad.SelectedValue;

            if (GradObj != null)
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

            if (txtEmail.Text != "")
            {
                search.Email = txtEmail.Text.ToLower();
            }

            if (dtpDatumRegistracijeOd.Value != DateTime.MinValue || dtpDatumRegistracijeOd.Value == DateTime.MinValue)
            {
                search.DatumRegistracijeOd = dtpDatumRegistracijeOd.Value;
            }

            if (dtpDatumRegistracijeDo.Value != DateTime.Now || dtpDatumRegistracijeDo.Value == DateTime.Now)
            {
                search.DatumRegistracijeDo = dtpDatumRegistracijeDo.Value;
            }

            var result = await _klijentiService.Get<List<Model.Models.Klijent>>(search);

            dgvKlijenti.AutoGenerateColumns = false;
            dgvKlijenti.DataSource = result;
        }

        private void dgvKlijenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvKlijenti.SelectedRows[0].Cells[0].Value;

            frmKlijentiDetalji frm = new frmKlijentiDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
