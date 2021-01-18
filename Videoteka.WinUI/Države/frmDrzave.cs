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

namespace Videoteka.WinUI.Države
{
    public partial class frmDrzave : Form
    {

        private readonly APIService _drzaveService = new APIService("Drzava");

        DrzavaUpsertRequest request = new DrzavaUpsertRequest();


        public frmDrzave()
        {
            InitializeComponent();
        }

        private void frmDrzave_Load(object sender, EventArgs e)
        {

        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new DrzavaSearchRequest();

            if (txtPretraga.Text != "")
            {
                search.Naziv = txtPretraga.Text;
            }

            var result = await _drzaveService.Get<List<Model.Models.Drzava>>(search);

            dgvDrzave.AutoGenerateColumns = false;
            dgvDrzave.DataSource = result;
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            bool ima = false;
            if (this.ValidateChildren())
            {
                var drzave = await _drzaveService.Get<List<Model.Models.Drzava>>(null);
                foreach (var item in drzave)
                {
                    if (item.Naziv.ToLower() == txtNaziv.Text.ToLower())
                    {
                        ima = true;
                    }
                }

                if (!ima)
                {
                    request.Naziv = txtNaziv.Text;
                    var entity = await _drzaveService.Insert<Model.Models.Drzava>(request);

                    if (entity != null)
                    {
                        MessageBox.Show("Država uspješno dodana!");
                        txtNaziv.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Država več postoji!");
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
