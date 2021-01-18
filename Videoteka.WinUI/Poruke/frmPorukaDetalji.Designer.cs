namespace Videoteka.WinUI.Poruke
{
    partial class frmPorukaDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPosiljaoc = new System.Windows.Forms.TextBox();
            this.txtPrimaoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.asa = new System.Windows.Forms.Label();
            this.dss = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtSadrzaj = new System.Windows.Forms.RichTextBox();
            this.btnNovaPoruka = new System.Windows.Forms.Button();
            this.txtDatumVrijeme = new System.Windows.Forms.TextBox();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pošiljaoc";
            // 
            // txtPosiljaoc
            // 
            this.txtPosiljaoc.Enabled = false;
            this.txtPosiljaoc.Location = new System.Drawing.Point(27, 262);
            this.txtPosiljaoc.Name = "txtPosiljaoc";
            this.txtPosiljaoc.Size = new System.Drawing.Size(209, 20);
            this.txtPosiljaoc.TabIndex = 2;
            // 
            // txtPrimaoc
            // 
            this.txtPrimaoc.Enabled = false;
            this.txtPrimaoc.Location = new System.Drawing.Point(27, 304);
            this.txtPrimaoc.Name = "txtPrimaoc";
            this.txtPrimaoc.Size = new System.Drawing.Size(209, 20);
            this.txtPrimaoc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primaoc";
            // 
            // asa
            // 
            this.asa.AutoSize = true;
            this.asa.Location = new System.Drawing.Point(24, 337);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(79, 13);
            this.asa.TabIndex = 5;
            this.asa.Text = "Datum i vrijeme";
            // 
            // dss
            // 
            this.dss.AutoSize = true;
            this.dss.Location = new System.Drawing.Point(332, 22);
            this.dss.Name = "dss";
            this.dss.Size = new System.Drawing.Size(40, 13);
            this.dss.TabIndex = 6;
            this.dss.Text = "Naslov";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sadržaj";
            // 
            // rtxtSadrzaj
            // 
            this.rtxtSadrzaj.Enabled = false;
            this.rtxtSadrzaj.Location = new System.Drawing.Point(384, 86);
            this.rtxtSadrzaj.Name = "rtxtSadrzaj";
            this.rtxtSadrzaj.Size = new System.Drawing.Size(269, 227);
            this.rtxtSadrzaj.TabIndex = 8;
            this.rtxtSadrzaj.Text = "";
            // 
            // btnNovaPoruka
            // 
            this.btnNovaPoruka.Location = new System.Drawing.Point(458, 364);
            this.btnNovaPoruka.Name = "btnNovaPoruka";
            this.btnNovaPoruka.Size = new System.Drawing.Size(195, 37);
            this.btnNovaPoruka.TabIndex = 9;
            this.btnNovaPoruka.Text = "Nova poruka";
            this.btnNovaPoruka.UseVisualStyleBackColor = true;
            this.btnNovaPoruka.Click += new System.EventHandler(this.btnNovaPoruka_Click);
            // 
            // txtDatumVrijeme
            // 
            this.txtDatumVrijeme.Enabled = false;
            this.txtDatumVrijeme.Location = new System.Drawing.Point(27, 353);
            this.txtDatumVrijeme.Name = "txtDatumVrijeme";
            this.txtDatumVrijeme.Size = new System.Drawing.Size(209, 20);
            this.txtDatumVrijeme.TabIndex = 10;
            // 
            // txtNaslov
            // 
            this.txtNaslov.Enabled = false;
            this.txtNaslov.Location = new System.Drawing.Point(384, 22);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(269, 20);
            this.txtNaslov.TabIndex = 11;
            // 
            // frmPorukaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNaslov);
            this.Controls.Add(this.txtDatumVrijeme);
            this.Controls.Add(this.btnNovaPoruka);
            this.Controls.Add(this.rtxtSadrzaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dss);
            this.Controls.Add(this.asa);
            this.Controls.Add(this.txtPrimaoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPosiljaoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPorukaDetalji";
            this.Text = "frmPorukaDetalji";
            this.Load += new System.EventHandler(this.frmPorukaDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPosiljaoc;
        private System.Windows.Forms.TextBox txtPrimaoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label asa;
        private System.Windows.Forms.Label dss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtSadrzaj;
        private System.Windows.Forms.Button btnNovaPoruka;
        private System.Windows.Forms.TextBox txtDatumVrijeme;
        private System.Windows.Forms.TextBox txtNaslov;
    }
}