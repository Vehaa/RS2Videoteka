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
    public partial class frmKlijentiBroj : Form
    {
        private readonly APIService _klijentService = new APIService("Klijent");

        public string _ukupnoKlijenata, _klijenataM, _klijenataG;

        private async void frmKlijentiBroj_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtBroj.Text = _ukupnoKlijenata;
        }

        public frmKlijentiBroj()
        {
            InitializeComponent();
        }

        private async Task Inicijaliziraj()
        {
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest
            {
                Status = true
            };
            var klijentiA = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);


            int ukupnoKlijenata = klijentiA.Count();
          
            klijentSearch.Status = false;
            var klijentiN = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            ukupnoKlijenata += klijentiN.Count();
            _ukupnoKlijenata = ukupnoKlijenata.ToString();
        }

    }
}
