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

namespace Videoteka.WinUI.Poruke
{
    public partial class frmPrimljenePoruke : Form
    {
        private readonly APIService _PorukaService = new APIService("Poruka");
        private int _userId = 0, _porukaId = 0;
        public frmPrimljenePoruke(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void frmPrimljenePoruke_Load(object sender, EventArgs e)
        {
            await PrimljenePoruke();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            PorukaSearchRequest search = new PorukaSearchRequest();

            if (txtIme.Text != "")
            {
                search.PosiljaocIme = txtIme.Text;
            }

            if (txtPrezime.Text != "")
            {
                search.PosiljaocPrezime = txtPrezime.Text;
            }

            if (txtUsername.Text != "")
            {
                search.PosiljaocUsername = txtUsername.Text;
            }
            search.UposlenikId = _userId;
            search.Posiljaoc = "Klijent";
            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(search);
            dgvPrimljenePoruke.AutoGenerateColumns = false;
            dgvPrimljenePoruke.DataSource = result;
        }

        private void dgvPrimljenePoruke_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Id = 0;
            if (dgvPrimljenePoruke.RowCount > 0)
            {
                var val = dgvPrimljenePoruke.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            _porukaId = Id;
            frmPorukaDetalji frm = new frmPorukaDetalji(_userId, _porukaId);
            frm.Show();

        }

        private async Task PrimljenePoruke()
        {
            PorukaSearchRequest request = new PorukaSearchRequest();
            request.UposlenikId = _userId;
            request.Posiljaoc = "Klijent";

            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(request);
            dgvPrimljenePoruke.AutoGenerateColumns = false;
            dgvPrimljenePoruke.DataSource = result;
        }
    }
}
