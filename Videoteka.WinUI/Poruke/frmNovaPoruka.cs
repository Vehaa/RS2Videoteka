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
    public partial class frmNovaPoruka : Form
    {

        private readonly APIService _porukaService = new APIService("Poruka");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaFilma");
        private int _rezervacijaId = 0, _uposlenikId = 0;

        private async void frmNovaPoruka_Load(object sender, EventArgs e)
        {
            var rezervacija = await _rezervacijaService.GetById<Model.Models.RezervacijaFilma>(_rezervacijaId);
            txtRezervacijaInfo.Text = rezervacija.RezervacijaInformacije;
            txtKlijent.Text = rezervacija.Klijent;
        }

        private async void bntPosalji_Click(object sender, EventArgs e)
        {
            var rezervacija = await _rezervacijaService.GetById<Model.Models.RezervacijaFilma>(_rezervacijaId);

            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest();
            porukaUpsert.RezervacijaFilmaId = _rezervacijaId;
            porukaUpsert.DatumVrijeme = DateTime.Now;
            porukaUpsert.UposlenikId = _uposlenikId;
            porukaUpsert.KlijentId = rezervacija.KlijentId;
            porukaUpsert.Procitano = false;
            porukaUpsert.Sadrzaj = rtxtSadrzaj.Text;
            porukaUpsert.Naslov = txtNaslov.Text;
            porukaUpsert.Posiljaoc = "Uposlenik";
            var entity = await _porukaService.Insert<Model.Models.Poruka>(porukaUpsert);
            if (entity != null)
            {
                MessageBox.Show("Poruka je uspješno poslana");
                this.Close();
            }

        }

        private void txtNaslov_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaslov.Text))
            {
                errorProvider.SetError(txtNaslov, Properties.Resources.Validation_RequiredField);
            }
            else
                errorProvider.SetError(txtNaslov, null);
        }

        private void rtxtSadrzaj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtSadrzaj.Text))
            {
                errorProvider.SetError(rtxtSadrzaj, Properties.Resources.Validation_RequiredField);
            }
            else
                errorProvider.SetError(rtxtSadrzaj, null);
        }

        public frmNovaPoruka(int rezervacijaId,int uposlenikId)
        {
            _rezervacijaId = rezervacijaId;
            _uposlenikId = uposlenikId;
            InitializeComponent();
        }
    }
}
