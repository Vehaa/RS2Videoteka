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
    public partial class frmFilmoviNedostupni : Form
    {

        private readonly APIService _filmoviService = new APIService("Film");

        public string _filmovaN;
        public frmFilmoviNedostupni()
        {
            InitializeComponent();
        }

        private async Task Inicijaliziraj()
        {
            FilmSearchRequest filmSearch = new FilmSearchRequest
            {
                Dostupan = false
            };
            var filmoviD = await _filmoviService.Get<List<Model.Models.Film>>(filmSearch);
            _filmovaN = filmoviD.Count().ToString();

        }

        private async void frmFilmoviNedostupni_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtBroj.Text = _filmovaN;
        }
    }
}
