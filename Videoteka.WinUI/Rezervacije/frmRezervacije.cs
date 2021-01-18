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

namespace Videoteka.WinUI.Rezervacije
{
    public partial class frmRezervacije : Form
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");
        private readonly APIService _filmService = new APIService("Film");
        private readonly APIService _klijentService = new APIService("Klijent");

        RezervacijaFilmaSearchRequest urediRequest = new RezervacijaFilmaSearchRequest();
        public int _rezervacijaId = 0, _userId = 0;

        private void frmRezervacije_Load(object sender, EventArgs e)
        {
            
            cbAktivna.Checked = false;
            cbOtkazana.Checked = false;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new RezervacijaFilmaSearchRequest();

            if (txtIme.Text != "")
            {
                search.Ime = txtIme.Text;
            }

            if (txtPrezime.Text != "")
            {
                search.Prezime = txtPrezime.Text;
            }

            if (txtUsername.Text != "")
            {
                search.Username = txtUsername.Text;
            }

            if(cbOd.Checked==true)
                search.RezervacijaOd = dtpOd.Value;
            if(cbDo.Checked==true)
                search.RezervacijaDo = dtpDo.Value;

            search.StatusAktivna = cbAktivna.Checked;
            search.Otkazana = cbOtkazana.Checked;

            var result = await _rezervacijeService.Get<List<Model.Models.RezervacijaFilma>>(search);
            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = result;
        }

        private void dgvRezervacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Id = 0;
            if (dgvRezervacije.RowCount > 0)
            {
                var val = dgvRezervacije.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }

            _rezervacijaId = Id;

            frmRezervacijaDetalji frm = new frmRezervacijaDetalji(_rezervacijaId,_userId);
            frm.Show();

        }

        private void cbOd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOd.Checked)
                dtpOd.Enabled = true;
            else
                dtpOd.Enabled = false;
        }

        private void cbDo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDo.Checked)
                dtpDo.Enabled = true;
            else
                dtpDo.Enabled = false;
        }

        public frmRezervacije(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }
    }
}
