﻿using System;
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
    public partial class frmKlijentiM : Form
    {

        private readonly APIService _klijentService = new APIService("Klijent");

        public string _klijenataM;
        public frmKlijentiM()
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
            int klijenataM = 0;

            int ukupnoKlijenata = klijentiA.Count();
            foreach (var item in klijentiA)
            {
                if (item.DatumRegistracije.Month == DateTime.Now.Month)
                    klijenataM++;

            }
            _klijenataM = klijenataM.ToString();
        }

        private async void frmKlijentiM_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
            txtBroj.Text = _klijenataM;
        }
    }
}