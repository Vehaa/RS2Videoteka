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

namespace Videoteka.WinUI.Izvjestaji
{
    public partial class frmIRezervacijaUkupno : Form
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");

        public string _rezervacijaU;
        public frmIRezervacijaUkupno()
        {
            InitializeComponent();
        }

        private async Task Inicijaliziraj()
        {
            RezervacijaFilmaSearchRequest rezervacijeSearch = new RezervacijaFilmaSearchRequest
            {
                Otkazana = false
            };

            var rezervacije = await _rezervacijeService.Get<List<Model.Models.RezervacijaFilma>>(rezervacijeSearch);

            _rezervacijaU = rezervacije.Count().ToString();
        }

        private async void frmIRezervacijaUkupno_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtIznos.Text = _rezervacijaU;
        }
    }
}
