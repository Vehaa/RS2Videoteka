namespace Videoteka.WinUI.Rezervacije
{
    partial class frmRezervacije
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rezervacije = new System.Windows.Forms.GroupBox();
            this.dgvRezervacije = new System.Windows.Forms.DataGridView();
            this.RezervacijaFilmaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilmInformacije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RezervacijaOdDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IznosSaPopustom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAktivna = new System.Windows.Forms.CheckBox();
            this.cbOtkazana = new System.Windows.Forms.CheckBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.cbOd = new System.Windows.Forms.CheckBox();
            this.cbDo = new System.Windows.Forms.CheckBox();
            this.Rezervacije.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // Rezervacije
            // 
            this.Rezervacije.Controls.Add(this.dgvRezervacije);
            this.Rezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rezervacije.Location = new System.Drawing.Point(12, 292);
            this.Rezervacije.Name = "Rezervacije";
            this.Rezervacije.Size = new System.Drawing.Size(693, 242);
            this.Rezervacije.TabIndex = 0;
            this.Rezervacije.TabStop = false;
            this.Rezervacije.Text = "Rezervacije";
            // 
            // dgvRezervacije
            // 
            this.dgvRezervacije.AllowUserToAddRows = false;
            this.dgvRezervacije.AllowUserToDeleteRows = false;
            this.dgvRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RezervacijaFilmaId,
            this.FilmInformacije,
            this.Klijent,
            this.RezervacijaOdDo,
            this.IznosSaPopustom});
            this.dgvRezervacije.Location = new System.Drawing.Point(12, 25);
            this.dgvRezervacije.Name = "dgvRezervacije";
            this.dgvRezervacije.ReadOnly = true;
            this.dgvRezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacije.Size = new System.Drawing.Size(675, 211);
            this.dgvRezervacije.TabIndex = 0;
            this.dgvRezervacije.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRezervacije_MouseDoubleClick);
            // 
            // RezervacijaFilmaId
            // 
            this.RezervacijaFilmaId.DataPropertyName = "RezervacijaFilmaId";
            this.RezervacijaFilmaId.HeaderText = "RezervacijaFilmaId";
            this.RezervacijaFilmaId.Name = "RezervacijaFilmaId";
            this.RezervacijaFilmaId.ReadOnly = true;
            this.RezervacijaFilmaId.Visible = false;
            // 
            // FilmInformacije
            // 
            this.FilmInformacije.DataPropertyName = "FilmInformacije";
            this.FilmInformacije.HeaderText = "Informacije";
            this.FilmInformacije.Name = "FilmInformacije";
            this.FilmInformacije.ReadOnly = true;
            this.FilmInformacije.Width = 150;
            // 
            // Klijent
            // 
            this.Klijent.DataPropertyName = "Klijent";
            this.Klijent.HeaderText = "Klijent";
            this.Klijent.Name = "Klijent";
            this.Klijent.ReadOnly = true;
            this.Klijent.Width = 150;
            // 
            // RezervacijaOdDo
            // 
            this.RezervacijaOdDo.DataPropertyName = "RezervacijaOdDo";
            this.RezervacijaOdDo.HeaderText = "Datum rezervacije";
            this.RezervacijaOdDo.Name = "RezervacijaOdDo";
            this.RezervacijaOdDo.ReadOnly = true;
            this.RezervacijaOdDo.Width = 175;
            // 
            // IznosSaPopustom
            // 
            this.IznosSaPopustom.DataPropertyName = "IznosSaPopustom";
            this.IznosSaPopustom.HeaderText = "Ukupan iznos";
            this.IznosSaPopustom.Name = "IznosSaPopustom";
            this.IznosSaPopustom.ReadOnly = true;
            this.IznosSaPopustom.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime klijenta";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(18, 44);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(154, 20);
            this.txtIme.TabIndex = 2;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(18, 84);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(154, 20);
            this.txtPrezime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prezime klijenta";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(18, 127);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(154, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username klijenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum od:";
            // 
            // dtpOd
            // 
            this.dtpOd.Location = new System.Drawing.Point(21, 171);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(151, 20);
            this.dtpOd.TabIndex = 8;
            // 
            // dtpDo
            // 
            this.dtpDo.Location = new System.Drawing.Point(21, 214);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(151, 20);
            this.dtpDo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Datum do:";
            // 
            // cbAktivna
            // 
            this.cbAktivna.AutoSize = true;
            this.cbAktivna.Location = new System.Drawing.Point(205, 44);
            this.cbAktivna.Name = "cbAktivna";
            this.cbAktivna.Size = new System.Drawing.Size(68, 17);
            this.cbAktivna.TabIndex = 11;
            this.cbAktivna.Text = "Aktivna?";
            this.cbAktivna.UseVisualStyleBackColor = true;
            // 
            // cbOtkazana
            // 
            this.cbOtkazana.AutoSize = true;
            this.cbOtkazana.Location = new System.Drawing.Point(205, 86);
            this.cbOtkazana.Name = "cbOtkazana";
            this.cbOtkazana.Size = new System.Drawing.Size(78, 17);
            this.cbOtkazana.TabIndex = 12;
            this.cbOtkazana.Text = "Otkazana?";
            this.cbOtkazana.UseVisualStyleBackColor = true;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(515, 44);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(184, 36);
            this.btnPrikazi.TabIndex = 13;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // cbOd
            // 
            this.cbOd.AutoSize = true;
            this.cbOd.Location = new System.Drawing.Point(178, 177);
            this.cbOd.Name = "cbOd";
            this.cbOd.Size = new System.Drawing.Size(15, 14);
            this.cbOd.TabIndex = 14;
            this.cbOd.UseVisualStyleBackColor = true;
            this.cbOd.CheckedChanged += new System.EventHandler(this.cbOd_CheckedChanged);
            // 
            // cbDo
            // 
            this.cbDo.AutoSize = true;
            this.cbDo.Location = new System.Drawing.Point(178, 220);
            this.cbDo.Name = "cbDo";
            this.cbDo.Size = new System.Drawing.Size(15, 14);
            this.cbDo.TabIndex = 15;
            this.cbDo.UseVisualStyleBackColor = true;
            this.cbDo.CheckedChanged += new System.EventHandler(this.cbDo_CheckedChanged);
            // 
            // frmRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.cbDo);
            this.Controls.Add(this.cbOd);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.cbOtkazana);
            this.Controls.Add(this.cbAktivna);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rezervacije);
            this.Name = "frmRezervacije";
            this.Text = "frmRezervacije";
            this.Load += new System.EventHandler(this.frmRezervacije_Load);
            this.Rezervacije.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Rezervacije;
        private System.Windows.Forms.DataGridView dgvRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAktivna;
        private System.Windows.Forms.CheckBox cbOtkazana;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaFilmaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilmInformacije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn RezervacijaOdDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IznosSaPopustom;
        private System.Windows.Forms.CheckBox cbOd;
        private System.Windows.Forms.CheckBox cbDo;
    }
}