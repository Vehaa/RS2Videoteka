namespace Videoteka.WinUI.Filmovi
{
    partial class frmFilmovi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFilmovi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtGlumac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJezik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGodina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDostupan = new System.Windows.Forms.CheckBox();
            this.cmbZanr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDrzava = new System.Windows.Forms.ComboBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.FilmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Glumac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trajanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jezik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDirektor = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvFilmovi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filmovi";
            // 
            // dgvFilmovi
            // 
            this.dgvFilmovi.AllowUserToAddRows = false;
            this.dgvFilmovi.AllowUserToDeleteRows = false;
            this.dgvFilmovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilmId,
            this.Naziv,
            this.Glumac,
            this.Godina,
            this.Trajanje,
            this.Jezik});
            this.dgvFilmovi.Location = new System.Drawing.Point(0, 25);
            this.dgvFilmovi.Name = "dgvFilmovi";
            this.dgvFilmovi.ReadOnly = true;
            this.dgvFilmovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilmovi.Size = new System.Drawing.Size(549, 234);
            this.dgvFilmovi.TabIndex = 0;
            this.dgvFilmovi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvFilmovi_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(16, 52);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(165, 20);
            this.txtNaziv.TabIndex = 2;
            // 
            // txtGlumac
            // 
            this.txtGlumac.Location = new System.Drawing.Point(16, 93);
            this.txtGlumac.Name = "txtGlumac";
            this.txtGlumac.Size = new System.Drawing.Size(165, 20);
            this.txtGlumac.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Glavna uloga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reditelj";
            // 
            // txtJezik
            // 
            this.txtJezik.Location = new System.Drawing.Point(16, 178);
            this.txtJezik.Name = "txtJezik";
            this.txtJezik.Size = new System.Drawing.Size(165, 20);
            this.txtJezik.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jezik";
            // 
            // txtGodina
            // 
            this.txtGodina.Location = new System.Drawing.Point(16, 221);
            this.txtGodina.Name = "txtGodina";
            this.txtGodina.Size = new System.Drawing.Size(165, 20);
            this.txtGodina.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Godina";
            // 
            // cbDostupan
            // 
            this.cbDostupan.AutoSize = true;
            this.cbDostupan.Location = new System.Drawing.Point(16, 247);
            this.cbDostupan.Name = "cbDostupan";
            this.cbDostupan.Size = new System.Drawing.Size(78, 17);
            this.cbDostupan.TabIndex = 11;
            this.cbDostupan.Text = "Dostupan?";
            this.cbDostupan.UseVisualStyleBackColor = true;
            // 
            // cmbZanr
            // 
            this.cmbZanr.FormattingEnabled = true;
            this.cmbZanr.Location = new System.Drawing.Point(12, 283);
            this.cmbZanr.Name = "cmbZanr";
            this.cmbZanr.Size = new System.Drawing.Size(165, 21);
            this.cmbZanr.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Žanr";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Država";
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.Location = new System.Drawing.Point(12, 326);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(165, 21);
            this.cmbDrzava.TabIndex = 14;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(491, 52);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(167, 37);
            this.btnPrikazi.TabIndex = 16;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // FilmId
            // 
            this.FilmId.DataPropertyName = "FilmId";
            this.FilmId.HeaderText = "FilmId";
            this.FilmId.Name = "FilmId";
            this.FilmId.ReadOnly = true;
            this.FilmId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Glumac
            // 
            this.Glumac.DataPropertyName = "Glumac";
            this.Glumac.HeaderText = "Glumac";
            this.Glumac.Name = "Glumac";
            this.Glumac.ReadOnly = true;
            // 
            // Godina
            // 
            this.Godina.DataPropertyName = "Godina";
            this.Godina.HeaderText = "Godina";
            this.Godina.Name = "Godina";
            this.Godina.ReadOnly = true;
            // 
            // Trajanje
            // 
            this.Trajanje.DataPropertyName = "Trajanje";
            this.Trajanje.HeaderText = "Trajanje";
            this.Trajanje.Name = "Trajanje";
            this.Trajanje.ReadOnly = true;
            // 
            // Jezik
            // 
            this.Jezik.DataPropertyName = "Jezik";
            this.Jezik.HeaderText = "Jezik";
            this.Jezik.Name = "Jezik";
            this.Jezik.ReadOnly = true;
            // 
            // cmbDirektor
            // 
            this.cmbDirektor.FormattingEnabled = true;
            this.cmbDirektor.Location = new System.Drawing.Point(16, 137);
            this.cmbDirektor.Name = "cmbDirektor";
            this.cmbDirektor.Size = new System.Drawing.Size(161, 21);
            this.cmbDirektor.TabIndex = 17;
            // 
            // frmFilmovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 641);
            this.Controls.Add(this.cmbDirektor);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDrzava);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbZanr);
            this.Controls.Add(this.cbDostupan);
            this.Controls.Add(this.txtGodina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtJezik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGlumac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFilmovi";
            this.Text = "frmFilmovi";
            this.Load += new System.EventHandler(this.frmFilmovi_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFilmovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtGlumac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJezik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGodina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbDostupan;
        private System.Windows.Forms.ComboBox cmbZanr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDrzava;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Glumac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trajanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jezik;
        private System.Windows.Forms.ComboBox cmbDirektor;
    }
}