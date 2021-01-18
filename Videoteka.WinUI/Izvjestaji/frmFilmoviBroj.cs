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
    public partial class frmFilmoviBroj : Form
    {
        private readonly APIService _filmoviService = new APIService("Film");

        public string _ukupnoFilmova, _filmovaD, _filmovaN;

        private async void frmFilmoviBroj_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtBroj.Text = _ukupnoFilmova;
        }

        public frmFilmoviBroj()
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
            int sviFilmovi = filmoviD.Count();

            filmSearch.Dostupan = false;
            var filmoviN = await _filmoviService.Get<List<Model.Models.Film>>(filmSearch);
            _filmovaN = filmoviN.Count().ToString();
            sviFilmovi += filmoviN.Count();
            _ukupnoFilmova = sviFilmovi.ToString();
        }
    }
}
