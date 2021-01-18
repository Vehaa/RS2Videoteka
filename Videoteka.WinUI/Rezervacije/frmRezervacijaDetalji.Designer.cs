namespace Videoteka.WinUI.Rezervacije
{
    partial class frmRezervacijaDetalji
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilmInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKlijent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIznosSaPopustom = new System.Windows.Forms.Label();
            this.txtOdDo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.cbOtkazana = new System.Windows.Forms.CheckBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnPosalji = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(21, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilmInfo
            // 
            this.txtFilmInfo.AutoSize = true;
            this.txtFilmInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilmInfo.Location = new System.Drawing.Point(18, 187);
            this.txtFilmInfo.Name = "txtFilmInfo";
            this.txtFilmInfo.Size = new System.Drawing.Size(52, 18);
            this.txtFilmInfo.TabIndex = 1;
            this.txtFilmInfo.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Klijent: ";
            // 
            // txtKlijent
            // 
            this.txtKlijent.AutoSize = true;
            this.txtKlijent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKlijent.Location = new System.Drawing.Point(145, 234);
            this.txtKlijent.Name = "txtKlijent";
            this.txtKlijent.Size = new System.Drawing.Size(41, 13);
            this.txtKlijent.TabIndex = 3;
            this.txtKlijent.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rezervacija(od-do): ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iznos sa popustom: ";
            // 
            // txtIznosSaPopustom
            // 
            this.txtIznosSaPopustom.AutoSize = true;
            this.txtIznosSaPopustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIznosSaPopustom.Location = new System.Drawing.Point(145, 305);
            this.txtIznosSaPopustom.Name = "txtIznosSaPopustom";
            this.txtIznosSaPopustom.Size = new System.Drawing.Size(41, 13);
            this.txtIznosSaPopustom.TabIndex = 6;
            this.txtIznosSaPopustom.Text = "label4";
            // 
            // txtOdDo
            // 
            this.txtOdDo.AutoSize = true;
            this.txtOdDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOdDo.Location = new System.Drawing.Point(145, 268);
            this.txtOdDo.Name = "txtOdDo";
            this.txtOdDo.Size = new System.Drawing.Size(41, 13);
            this.txtOdDo.TabIndex = 7;
            this.txtOdDo.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Popust: ";
            // 
            // txtPopust
            // 
            this.txtPopust.Location = new System.Drawing.Point(82, 341);
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.Size = new System.Drawing.Size(43, 20);
            this.txtPopust.TabIndex = 9;
            // 
            // cbOtkazana
            // 
            this.cbOtkazana.AutoSize = true;
            this.cbOtkazana.Location = new System.Drawing.Point(24, 383);
            this.cbOtkazana.Name = "cbOtkazana";
            this.cbOtkazana.Size = new System.Drawing.Size(78, 17);
            this.cbOtkazana.TabIndex = 10;
            this.cbOtkazana.Text = "Otkazana?";
            this.cbOtkazana.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Location = new System.Drawing.Point(232, 383);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(91, 23);
            this.btnSacuvaj.TabIndex = 11;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnPosalji
            // 
            this.btnPosalji.BackColor = System.Drawing.Color.Orange;
            this.btnPosalji.Location = new System.Drawing.Point(364, 383);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(98, 23);
            this.btnPosalji.TabIndex = 12;
            this.btnPosalji.Text = "Pošalji poruku";
            this.btnPosalji.UseVisualStyleBackColor = false;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // frmRezervacijaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 450);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbOtkazana);
            this.Controls.Add(this.txtPopust);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOdDo);
            this.Controls.Add(this.txtIznosSaPopustom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKlijent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilmInfo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRezervacijaDetalji";
            this.Text = "frmRezervacijaDetalji";
            this.Load += new System.EventHandler(this.frmRezervacijaDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtFilmInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtKlijent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtIznosSaPopustom;
        private System.Windows.Forms.Label txtOdDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPopust;
        private System.Windows.Forms.CheckBox cbOtkazana;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnPosalji;
    }
}