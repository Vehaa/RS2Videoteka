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

namespace Videoteka.WinUI.Žanrovi
{
    public partial class frmZanrovi : Form
    {

        private readonly APIService _zanroviService = new APIService("Zanr");

        ZanrUpsertRequest request = new ZanrUpsertRequest();
        public frmZanrovi()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new ZanrSearchRequest();

            if (txtPretraga.Text != "")
            {
                search.Naziv = txtPretraga.Text;
            }

            var result = await _zanroviService.Get<List<Model.Models.Zanr>>(search);

            dgvZanrovi.AutoGenerateColumns = false;
            dgvZanrovi.DataSource = result;
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            bool ima = false;
            if (this.ValidateChildren())
            {
                var zanrovi = await _zanroviService.Get<List<Model.Models.Zanr>>(null);
                foreach (var item in zanrovi)
                {
                    if (item.Naziv.ToLower() == txtNaziv.Text.ToLower())
                    {
                        ima = true;
                    }
                }

                if (!ima)
                {
                    request.Naziv = txtNaziv.Text;
                    var entity = await _zanroviService.Insert<Model.Models.Zanr>(request);

                    if (entity != null)
                    {
                        MessageBox.Show("Žanr uspješno dodan!");
                        txtNaziv.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Žanr več postoji!");
                }
            }

        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider.SetError(txtNaziv, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtNaziv, null);

            }
        }
    }
}
