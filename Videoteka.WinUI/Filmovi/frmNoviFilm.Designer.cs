namespace Videoteka.WinUI.Filmovi
{
    partial class frmNoviFilm
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.labelop = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.mtxtCijena = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTrajanje = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbDirektor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Država";
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.Location = new System.Drawing.Point(26, 339);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(165, 21);
            this.cmbDrzava.TabIndex = 29;
            this.cmbDrzava.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrzava_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Žanr";
            // 
            // cmbZanr
            // 
            this.cmbZanr.FormattingEnabled = true;
            this.cmbZanr.Location = new System.Drawing.Point(26, 296);
            this.cmbZanr.Name = "cmbZanr";
            this.cmbZanr.Size = new System.Drawing.Size(165, 21);
            this.cmbZanr.TabIndex = 27;
            this.cmbZanr.Validating += new System.ComponentModel.CancelEventHandler(this.cmbZanr_Validating);
            // 
            // cbDostupan
            // 
            this.cbDostupan.AutoSize = true;
            this.cbDostupan.Location = new System.Drawing.Point(30, 260);
            this.cbDostupan.Name = "cbDostupan";
            this.cbDostupan.Size = new System.Drawing.Size(78, 17);
            this.cbDostupan.TabIndex = 26;
            this.cbDostupan.Text = "Dostupan?";
            this.cbDostupan.UseVisualStyleBackColor = true;
            // 
            // txtGodina
            // 
            this.txtGodina.Location = new System.Drawing.Point(30, 234);
            this.txtGodina.Name = "txtGodina";
            this.txtGodina.Size = new System.Drawing.Size(165, 20);
            this.txtGodina.TabIndex = 25;
            this.txtGodina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGodina_KeyPress);
            this.txtGodina.Validating += new System.ComponentModel.CancelEventHandler(this.txtGodina_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Godina izdavanja";
            // 
            // txtJezik
            // 
            this.txtJezik.Location = new System.Drawing.Point(30, 191);
            this.txtJezik.Name = "txtJezik";
            this.txtJezik.Size = new System.Drawing.Size(165, 20);
            this.txtJezik.TabIndex = 23;
            this.txtJezik.Validating += new System.ComponentModel.CancelEventHandler(this.txtJezik_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Jezik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Reditelj";
            // 
            // txtGlumac
            // 
            this.txtGlumac.Location = new System.Drawing.Point(30, 106);
            this.txtGlumac.Name = "txtGlumac";
            this.txtGlumac.Size = new System.Drawing.Size(165, 20);
            this.txtGlumac.TabIndex = 19;
            this.txtGlumac.Validating += new System.ComponentModel.CancelEventHandler(this.txtGlumac_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Glavna uloga";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(30, 65);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(165, 20);
            this.txtNaziv.TabIndex = 17;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Naziv filma";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Trajanje filma";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(257, 108);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(294, 169);
            this.txtOpis.TabIndex = 34;
            this.txtOpis.Validating += new System.ComponentModel.CancelEventHandler(this.txtOpis_Validating);
            // 
            // labelop
            // 
            this.labelop.AutoSize = true;
            this.labelop.Location = new System.Drawing.Point(254, 91);
            this.labelop.Name = "labelop";
            this.labelop.Size = new System.Drawing.Size(52, 13);
            this.labelop.TabIndex = 33;
            this.labelop.Text = "Opis filma";
            // 
            // txtCijena
            // 
            this.txtCijena.AutoSize = true;
            this.txtCijena.Location = new System.Drawing.Point(254, 280);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(36, 13);
            this.txtCijena.TabIndex = 35;
            this.txtCijena.Text = "Cijena";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(655, 239);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(164, 23);
            this.btnDodajSliku.TabIndex = 53;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "Slika:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(655, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.Location = new System.Drawing.Point(619, 327);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(200, 43);
            this.btnSacuvaj.TabIndex = 55;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // mtxtCijena
            // 
            this.mtxtCijena.Location = new System.Drawing.Point(257, 297);
            this.mtxtCijena.Mask = "00.00";
            this.mtxtCijena.Name = "mtxtCijena";
            this.mtxtCijena.Size = new System.Drawing.Size(88, 20);
            this.mtxtCijena.TabIndex = 56;
            this.mtxtCijena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCijena_KeyPress);
            this.mtxtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtCijena_Validating);
            // 
            // mtxtTrajanje
            // 
            this.mtxtTrajanje.Location = new System.Drawing.Point(257, 65);
            this.mtxtTrajanje.Mask = "000.00";
            this.mtxtTrajanje.Name = "mtxtTrajanje";
            this.mtxtTrajanje.Size = new System.Drawing.Size(100, 20);
            this.mtxtTrajanje.TabIndex = 57;
            this.mtxtTrajanje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtTrajanje_KeyPress);
            this.mtxtTrajanje.Validating += new System.ComponentModel.CancelEventHandler(this.mtxtTrajanje_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cmbDirektor
            // 
            this.cmbDirektor.FormattingEnabled = true;
            this.cmbDirektor.Location = new System.Drawing.Point(30, 148);
            this.cmbDirektor.Name = "cmbDirektor";
            this.cmbDirektor.Size = new System.Drawing.Size(165, 21);
            this.cmbDirektor.TabIndex = 58;
            this.cmbDirektor.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDirektor_Validating);
            // 
            // frmNoviFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 425);
            this.Controls.Add(this.cmbDirektor);
            this.Controls.Add(this.mtxtTrajanje);
            this.Controls.Add(this.mtxtCijena);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.label11);
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
            this.Name = "frmNoviFilm";
            this.Text = "Novi film";
            this.Load += new System.EventHandler(this.frmNoviFilm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label labelop;
        private System.Windows.Forms.Label txtCijena;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.MaskedTextBox mtxtTrajanje;
        private System.Windows.Forms.MaskedTextBox mtxtCijena;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cmbDirektor;
    }
}