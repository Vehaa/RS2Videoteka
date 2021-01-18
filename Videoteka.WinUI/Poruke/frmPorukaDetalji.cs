using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Videoteka.Model.Requests;

namespace Videoteka.WinUI.Poruke
{
    public partial class frmPorukaDetalji : Form
    {
        private readonly APIService _PorukaService = new APIService("Poruka");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaFilma");
        private int _userId = 0, _porukaId = 0;

        private async void frmPorukaDetalji_Load(object sender, EventArgs e)
        {
            var poruka = await _PorukaService.GetById<Model.Models.Poruka>(_porukaId);
            PorukaUpsertRequest update = new PorukaUpsertRequest();
            if (poruka.Procitano == false && poruka.Posiljaoc=="Klijent")
            {
                update.Procitano = true;
                update.PorukaId = poruka.PorukaId;
                update.RezervacijaFilmaId = poruka.RezervacijaFilmaId;
                update.KlijentId = poruka.KlijentId;
                update.UposlenikId = poruka.UposlenikId;
                update.Sadrzaj = poruka.Sadrzaj;
                update.Naslov = poruka.Naslov;
                update.Posiljaoc = poruka.Posiljaoc;
                update.DatumVrijeme = poruka.DatumVrijeme;
                await _PorukaService.Update<Model.Models.Poruka>(update.PorukaId, update);
            }

            txtPosiljaoc.Text = poruka.PosiljaocInfo;
            txtPrimaoc.Text = poruka.PrimaocInfo;
            txtDatumVrijeme.Text = poruka.DatumVrijeme.ToString();
            txtNaslov.Text = poruka.Naslov;
            rtxtSadrzaj.Text = poruka.Sadrzaj;

            byte[] slika = poruka.PosiljaocSlikaThumb;
            MemoryStream memoryStream = new MemoryStream(slika);
            pictureBox1.Image = Image.FromStream(memoryStream);


        }

        private async  void btnNovaPoruka_Click(object sender, EventArgs e)
        {
            var p = await _PorukaService.GetById<Model.Models.Poruka>(_porukaId);
            var rezervacija = await _rezervacijaService.GetById<Model.Models.RezervacijaFilma>(p.RezervacijaFilmaId);

            frmNovaPoruka frm = new frmNovaPoruka(rezervacija.RezervacijaFilmaId, _userId);
            Close();
            frm.Show();
        }

        public frmPorukaDetalji(int userId,int porukaId)
        {
            _userId = userId;
            _porukaId = porukaId;
            InitializeComponent();
        }
    }
}
