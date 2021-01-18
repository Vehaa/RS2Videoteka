namespace Videoteka.WinUI.Filmovi
{
    partial class frmFilmDetalji
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
            this.components = new System.ComponentModel.Container();
            this.mtxtTrajanje = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mtxtCijena = new System.Windows.Forms.MaskedTextBox();
            this.txtCijena = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.labelop = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDrzava = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbZanr = new System.Windows.Forms.ComboBox();
            this.cbDostupan = new System.Windows.Forms.CheckBox();
            this.txtGodina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJezik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGlumac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReditelj = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtTrajanje
            // 
            this.mtxtTrajanje.Location = new System.Drawing.Point(235, 81);
            this.mtxtTrajanje.Mask = "000.00";
            this.mtxtTrajanje.Name = "mtxtTrajanje";
            this.mtxtTrajanje.Size = new System.Drawing.Size(100, 20);
            this.mtxtTrajanje.TabIndex = 82;
            this.mtxtTrajanje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtTrajanje_KeyPress);
            this.mtxtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtTrajanje_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.Location = new System.Drawing.Point(597, 343);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(200, 43);
            this.btnSacuvaj.TabIndex = 80;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(633, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(633, 255);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(164, 23);
            this.btnDodajSliku.TabIndex = 78;
            this.btnDodajSliku.Text = "Promjeni sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(594, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 77;
            this.label11.Text = "Slika:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mtxtCijena
            // 
            this.mtxtCijena.Location = new System.Drawing.Point(235, 313);
            this.mtxtCijena.Mask = "00.00";
            this.mtxtCijena.Name = "mtxtCijena";
            this.mtxtCijena.Size = new System.Drawing.Size(88, 20);
            this.mtxtCijena.TabIndex = 81;
            this.mtxtCijena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCijena_KeyPress);
            this.mtxtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtCijena_Validating);
            // 
            // txtCijena
            // 
            this.txtCijena.AutoSize = true;
            this.txtCijena.Location = new System.Drawing.Point(232, 296);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(36, 13);
            this.txtCijena.TabIndex = 76;
            this.txtCijena.Text = "Cijena";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(235, 124);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(294, 169);
            this.txtOpis.TabIndex = 75;
            this.txtOpis.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpis_Validating);
            // 
            // labelop
            // 
            this.labelop.AutoSize = true;
            this.labelop.Location = new System.Drawing.Point(232, 107);
            this.labelop.Name = "labelop";
            this.labelop.Size = new System.Drawing.Size(52, 13);
            this.labelop.TabIndex = 74;
            this.labelop.Text = "Opis filma";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Trajanje filma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Država";
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.Location = new System.Drawing.Point(4, 355);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(165, 21);
            this.cmbDrzava.TabIndex = 71;
            this.cmbDrzava.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrzava_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Žanr";
            // 
            // cmbZanr
            // 
            this.cmbZanr.FormattingEnabled = true;
            this.cmbZanr.Location = new System.Drawing.Point(4, 312);
            this.cmbZanr.Name = "cmbZanr";
            this.cmbZanr.Size = new System.Drawing.Size(165, 21);
            this.cmbZanr.TabIndex = 69;
            this.cmbZanr.Validating += new System.ComponentModel.CancelEventHandler(this.cmbZanr_Validating);
            // 
            // cbDostupan
            // 
            this.cbDostupan.AutoSize = true;
            this.cbDostupan.Location = new System.Drawing.Point(8, 276);
            this.cbDostupan.Name = "cbDostupan";
            this.cbDostupan.Size = new System.Drawing.Size(78, 17);
            this.cbDostupan.TabIndex = 68;
            this.cbDostupan.Text = "Dostupan?";
            this.cbDostupan.UseVisualStyleBackColor = true;
            // 
            // txtGodina
            // 
            this.txtGodina.Location = new System.Drawing.Point(8, 250);
            this.txtGodina.Name = "txtGodina";
            this.txtGodina.Size = new System.Drawing.Size(165, 20);
            this.txtGodina.TabIndex = 67;
            this.txtGodina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGodina_KeyPress);
            this.txtGodina.Validating += new System.ComponentModel.CancelEventHandler(this.txtGodina_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Godina izdavanja";
            // 
            // txtJezik
            // 
            this.txtJezik.Location = new System.Drawing.Point(8, 207);
            this.txtJezik.Name = "txtJezik";
            this.txtJezik.Size = new System.Drawing.Size(165, 20);
            this.txtJezik.TabIndex = 65;
            this.txtJezik.Validating += new System.ComponentModel.CancelEventHandler(this.txtJezik_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Jezik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Reditelj";
            // 
            // txtGlumac
            // 
            this.txtGlumac.Location = new System.Drawing.Point(8, 122);
            this.txtGlumac.Name = "txtGlumac";
            this.txtGlumac.Size = new System.Drawing.Size(165, 20);
            this.txtGlumac.TabIndex = 61;
            this.txtGlumac.Validating += new System.ComponentModel.CancelEventHandler(this.txtGlumac_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Glavna uloga";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(8, 81);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(165, 20);
            this.txtNaziv.TabIndex = 59;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Naziv filma";
            // 
            // cmbReditelj
            // 
            this.cmbReditelj.FormattingEnabled = true;
            this.cmbReditelj.Location = new System.Drawing.Point(8, 166);
            this.cmbReditelj.Name = "cmbReditelj";
            this.cmbReditelj.Size = new System.Drawing.Size(165, 21);
            this.cmbReditelj.TabIndex = 83;
            this.cmbReditelj.Validating += new System.ComponentModel.CancelEventHandler(this.cmbReditelj_Validating);
            // 
            // frmFilmDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 457);
            this.Controls.Add(this.cmbReditelj);
            this.Controls.Add(this.mtxtTrajanje);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mtxtCijena);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.labelop);
            this.Controls.Add(this.label8);
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
            this.Name = "frmFilmDetalji";
            this.Text = "Detalji filma";
            this.Load += new System.EventHandler(this.frmFilmDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtTrajanje;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mtxtCijena;
        private System.Windows.Forms.Label txtCijena;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label labelop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDrzava;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbZanr;
        private System.Windows.Forms.CheckBox cbDostupan;
        private System.Windows.Forms.TextBox txtGodina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJezik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGlumac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbReditelj;
    }
}