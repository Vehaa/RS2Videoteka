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

namespace Videoteka.WinUI.Gradovi
{
    public partial class frmGradovi : Form
    {
        private readonly APIService _drzaveService = new APIService("Drzava");
        private readonly APIService _gradoviService = new APIService("Grad");

        GradUpsertRequest request = new GradUpsertRequest();
        public frmGradovi()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            var search = new GradSearchRequest();
            var drzavaObj = cmbDrzava.SelectedValue;

            if (drzavaObj != null)
            {
                search.DrzavaId = int.Parse(drzavaObj.ToString());
            }

            if (txtSearchGrad.Text != "")
            {
                search.Naziv = txtSearchGrad.Text.ToLower();
            }

            var result = await _gradoviService.Get<List<Model.Models.Grad>>(search);

            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = result;
        }


        private async Task LoadDrzave()
        {
            var result = await _drzaveService.Get<List<Model.Models.Drzava>>(null);
            result.Insert(0, new Model.Models.Drzava());
            cmbDrzava.DisplayMember = "Naziv";
            cmbDrzava.ValueMember = "DrzavaId";
            cmbDrzava.DataSource = result;

            cmbDrzavaDodaj.DisplayMember = "Naziv";
            cmbDrzavaDodaj.ValueMember = "DrzavaId";
            cmbDrzavaDodaj.DataSource = result;
        }

        private async void frmGradovi_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
        }

        private async  void btnDodaj_Click(object sender, EventArgs e)
        {
            bool ima = false;
            var drzavaId = cmbDrzavaDodaj.SelectedValue;
            if (this.ValidateChildren())
            {
                var gradovi = await _gradoviService.Get<List<Model.Models.Grad>>(null);

                foreach (var item in gradovi)
                {
                    if(int.Parse(drzavaId.ToString())== item.DrzavaId && txtGrad.Text.ToLower() == item.Naziv)
                    {
                        ima = true;
                    }
                }

                if (!ima)
                {
                    request.DrzavaId = int.Parse(drzavaId.ToString());
                    request.Naziv = txtGrad.Text;
                    request.PostanskiBroj = txtPostanskiBroj.Text;

                    var entity = await _gradoviService.Insert<Model.Models.Grad>(request);

                    if (entity != null)
                    {
                        MessageBox.Show("Grad uspješno dodan!");
                        txtGrad.Clear();
                        txtPostanskiBroj.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Grad več postoji u bazi!");
                }
            }
        }

        private void cmbDrzavaDodaj_Validating(object sender, CancelEventArgs e)
        {
            var GradObj = cmbDrzava.SelectedValue;

            if (GradObj == null || GradObj.ToString() == "0")
            {
                errorProvider.SetError(cmbDrzava, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(cmbDrzava, null);
            }
        }

        private void txtGrad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGrad.Text))
            {
                errorProvider.SetError(txtGrad, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtGrad, null);

            }
        }

        private void txtPostanskiBroj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostanskiBroj.Text))
            {
                errorProvider.SetError(txtPostanskiBroj, Properties.Resources.Validation_RequiredField);
                e.Cancel = false;
            }
            else
            {
                errorProvider.SetError(txtPostanskiBroj, null);

            }
        }
    }
}
