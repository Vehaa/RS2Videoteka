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

namespace Videoteka.WinUI.Režiseri
{
    public partial class frmReziseri : Form
    {

        private readonly APIService _reziseriService = new APIService("Reziser");

        ReziserUpsertRequest request = new ReziserUpsertRequest();


        public frmReziseri()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new ReziserSearchRequest();

            if (txtIme.Text != "")
            {
                search.Ime = txtIme.Text.ToLower();
            }

            if (txtPrezime.Text != "")
            {
                search.Prezime = txtPrezime.Text.ToLower();
            }

            var result = await _reziseriService.Get<List<Model.Models.Reziser>>(search);

            dgvReziseri.AutoGenerateColumns = false;
            dgvReziseri.DataSource = result;
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            bool ima = false;
            if (this.ValidateChildren())
            {
                var reziseri = await _reziseriService.Get<List<Model.Models.Reziser>>(null);

                foreach (var item in reziseri)
                {
                    if(item.Ime.ToLower()==txtImeDodaj.Text.ToLower() && item.Prezime.ToLower() == txtPrezimeDodaj.Text.ToLower())
                    {
                        ima = true;
                    }
                }

                if (!ima)
                {
                    request.Ime = txtImeDodaj.Text;
                    request.Prezime = txtPrezimeDodaj.Text;
                    request.DatumRodjenja = dtpDatumRodjenja.Value;
                    var entity = await _reziseriService.Insert<Model.Models.Reziser>(request);

                    if (entity != null)
                    {
                        MessageBox.Show("Režiser uspješno dodan!");
                        txtImeDodaj.Clear();
                        txtPrezimeDodaj.Clear();
                       
                    }

                }

                else
                {
                    MessageBox.Show("Režiser več postoji u bazi!");
                }
            }
        }

        private void txtImeDodaj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImeDodaj.Text))
            {
                errorProvider.SetError(txtImeDodaj, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtImeDodaj, null);

            }
        }

        private void txtPrezimeDodaj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezimeDodaj.Text))
            {
                errorProvider.SetError(txtPrezimeDodaj, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtPrezimeDodaj, null);

            }
        }
    }
}
