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
    public partial class frmFilmoviDostupni : Form
    {
        private readonly APIService _filmoviService = new APIService("Film");

        public string _filmovaD;
        public frmFilmoviDostupni()
        {
            InitializeComponent();
        }

        private async Task Inicijaliziraj()
        {
            FilmSearchRequest filmSearch = new FilmSearchRequest
            {
                Dostupan = true
            };
            var filmoviD = await _filmoviService.Get<List<Model.Models.Film>>(filmSearch);
            _filmovaD = filmoviD.Count().ToString();
           
        }

        private async void frmFilmoviDostupni_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtBroj.Text = _filmovaD;
        }
    }
}
