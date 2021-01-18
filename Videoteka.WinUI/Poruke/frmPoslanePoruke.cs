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
    public partial class frmPoslanePoruke : Form
    {
        private readonly APIService _PorukaService = new APIService("Poruka");
        private int _userId = 0, _porukaId = 0;
        public frmPoslanePoruke(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void frmPoslanePoruke_Load(object sender, EventArgs e)
        {
            await PoslanePoruke();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            PorukaSearchRequest search = new PorukaSearchRequest();

            if (txtIme.Text != "")
            {
                search.PrimaocIme = txtIme.Text;
            }

            if (txtPrezime.Text != "")
            {
                search.PrimaocPrezime = txtPrezime.Text;
            }

            if (txtUsername.Text != "")
            {
                search.PrimaocUsername = txtUsername.Text;
            }
            search.UposlenikId = _userId;
            search.Posiljaoc = "Uposlenik";
            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(search);
            dgvPoslanePoruke.AutoGenerateColumns = false;
            dgvPoslanePoruke.DataSource = result;
        }

        private void dgvPoslanePoruke_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Id = 0;
            if (dgvPoslanePoruke.RowCount > 0)
            {
                var val = dgvPoslanePoruke.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            _porukaId = Id;
            frmPorukaDetalji frm = new frmPorukaDetalji(_userId, _porukaId);
            frm.Show();
        }

        private async Task PoslanePoruke()
        {
            PorukaSearchRequest request = new PorukaSearchRequest();
            request.UposlenikId = _userId;
            request.Posiljaoc = "Uposlenik";

            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(request);
            dgvPoslanePoruke.AutoGenerateColumns = false;
            dgvPoslanePoruke.DataSource = result;
        }



    }
}
