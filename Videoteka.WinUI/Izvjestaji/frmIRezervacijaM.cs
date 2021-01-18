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
    public partial class frmIRezervacijaM : Form
    {

        private readonly APIService _rezervacijeService = new APIService("RezervacijaFilma");

        public string _rezervacijaM;
        public frmIRezervacijaM()
        {
            InitializeComponent();
        }

        private async void frmIRezervacija_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtIznos.Text = _rezervacijaM;

        }

        private async Task Inicijaliziraj()
        {
            RezervacijaFilmaSearchRequest rezervacijeSearch = new RezervacijaFilmaSearchRequest
            {
                Otkazana = false
            };

            var rezervacije = await _rezervacijeService.Get<List<Model.Models.RezervacijaFilma>>(rezervacijeSearch);
            int rezervacijeM = 0;
            foreach (var item in rezervacije)
            {
                if (item.DatumKreiranja.Month == DateTime.Now.Month)
                    rezervacijeM++;
               
            }

            _rezervacijaM = rezervacijeM.ToString();
        }
    }
}
