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
using Videoteka.WinUI.Države;
using Videoteka.WinUI.Filmovi;
using Videoteka.WinUI.Gradovi;
using Videoteka.WinUI.Izvjestaji;
using Videoteka.WinUI.Klijenti;
using Videoteka.WinUI.Korisnici;
using Videoteka.WinUI.Poruke;
using Videoteka.WinUI.Profil;
using Videoteka.WinUI.Rezervacije;
using Videoteka.WinUI.Režiseri;
using Videoteka.WinUI.Žanrovi;

namespace Videoteka.WinUI
{
    public partial class frmIndex : Form
    {
        private readonly APIService _KorisnikService = new APIService("Korisnici");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        public int _korisnikId;
        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;

        public KorisniciSearchRequest _searchRequest = new KorisniciSearchRequest();

        public frmIndex(int korisnikId, bool ulogaA, bool ulogaM, bool ulogaU)
        {
            _korisnikId = korisnikId;
            ulogaAdmin = ulogaA;
            ulogaMenadzer = ulogaM;
            ulogaUposlenik = ulogaU;

            InitializeComponent();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            if (ulogaAdmin && !ulogaUposlenik && !ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = true;
                this.gradoviToolStripMenuItem.Visible = true;
                this.žanroviToolStripMenuItem.Visible = true;
                this.režiseriToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = true;
                this.klijentiToolStripMenuItem.Visible = true;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = false;
                this.rezervacijeToolStripMenuItem.Visible = false;
                this.izvještajiToolStripMenuItem.Visible = false;
                this.porukeToolStripMenuItem.Visible = false;
            }
            if (ulogaAdmin && ulogaUposlenik && !ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = true;
                this.gradoviToolStripMenuItem.Visible = true;
                this.žanroviToolStripMenuItem.Visible = true;
                this.režiseriToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = true;
                this.klijentiToolStripMenuItem.Visible = true;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = true;
                this.rezervacijeToolStripMenuItem.Visible = true;
                this.izvještajiToolStripMenuItem.Visible = false;
                this.porukeToolStripMenuItem.Visible = true;
            }
            if (ulogaAdmin && ulogaUposlenik && ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = true;
                this.gradoviToolStripMenuItem.Visible = true;
                this.žanroviToolStripMenuItem.Visible = true;
                this.režiseriToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = true;
                this.klijentiToolStripMenuItem.Visible = true;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = true;
                this.rezervacijeToolStripMenuItem.Visible = true;
                this.izvještajiToolStripMenuItem.Visible = true;
                this.porukeToolStripMenuItem.Visible = true;
            }
            if (ulogaAdmin && !ulogaUposlenik && ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = true;
                this.gradoviToolStripMenuItem.Visible = true;
                this.žanroviToolStripMenuItem.Visible = true;
                this.režiseriToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = true;
                this.klijentiToolStripMenuItem.Visible = true;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = false;
                this.rezervacijeToolStripMenuItem.Visible = false;
                this.izvještajiToolStripMenuItem.Visible = true;
                this.porukeToolStripMenuItem.Visible = false;
            }
            if (!ulogaAdmin && ulogaUposlenik && ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = false;
                this.gradoviToolStripMenuItem.Visible = false;
                this.žanroviToolStripMenuItem.Visible = false;
                this.režiseriToolStripMenuItem.Visible = false;
                this.profilToolStripMenuItem.Visible = true;
                this.izvještajiToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = false;
                this.klijentiToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = true;
                this.rezervacijeToolStripMenuItem.Visible = true;
                this.porukeToolStripMenuItem.Visible = true;
            }
            if (!ulogaAdmin && !ulogaUposlenik && ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = false;
                this.gradoviToolStripMenuItem.Visible = false;
                this.žanroviToolStripMenuItem.Visible = false;
                this.režiseriToolStripMenuItem.Visible = false;
                this.klijentiToolStripMenuItem.Visible = false;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = false;
                this.rezervacijeToolStripMenuItem.Visible = false;
                this.porukeToolStripMenuItem.Visible = false;
                this.korisniciToolStripMenuItem.Visible = false;
                this.izvještajiToolStripMenuItem.Visible = true;
            }
            if (!ulogaAdmin && ulogaUposlenik && !ulogaMenadzer)
            {
                this.državeToolStripMenuItem.Visible = false;
                this.gradoviToolStripMenuItem.Visible = false;
                this.žanroviToolStripMenuItem.Visible = false;
                this.režiseriToolStripMenuItem.Visible = false;
                this.klijentiToolStripMenuItem.Visible = true;
                this.profilToolStripMenuItem.Visible = true;
                this.filmoviToolStripMenuItem.Visible = true;
                this.rezervacijeToolStripMenuItem.Visible = true;
                this.porukeToolStripMenuItem.Visible = true;
                this.korisniciToolStripMenuItem.Visible = false;
                this.izvještajiToolStripMenuItem.Visible = false;
            }

        }

        private void pretragaToolStripMenuKlijent_Click(object sender, EventArgs e)
        {
            frmKlijenti frm = new frmKlijenti();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKlijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviKlijent frm = new frmNoviKlijent();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFilmovi frm = new frmFilmovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviFilm frm = new frmNoviFilm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mojProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfil frm = new frmProfil(_korisnikId);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void rezervacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervacije frm = new frmRezervacije(_korisnikId);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void primljenePorukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrimljenePoruke frm = new frmPrimljenePoruke(_korisnikId);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void poslanePorukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPoslanePoruke frm = new frmPoslanePoruke(_korisnikId);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Visible = false;
            frm.Show();
        }

        private void izvještajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzvjestaji frm = new frmIzvjestaji();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void državeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzave frm = new frmDrzave();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void režiseriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReziseri frm = new frmReziseri();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void žanroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZanrovi frm = new frmZanrovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradovi frm = new frmGradovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNoviKorisnik frm = new frmNoviKorisnik();
            frm.WindowState = FormWindowState.Normal;
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
