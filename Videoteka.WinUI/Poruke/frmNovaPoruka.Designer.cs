namespace Videoteka.WinUI.Poruke
{
    partial class frmNovaPoruka
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
            this.txtRezervacijaInfo = new System.Windows.Forms.Label();
            this.txtKlijent = new System.Windows.Forms.Label();
            this.aa = new System.Windows.Forms.Label();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtSadrzaj = new System.Windows.Forms.RichTextBox();
            this.bntPosalji = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRezervacijaInfo
            // 
            this.txtRezervacijaInfo.AutoSize = true;
            this.txtRezervacijaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRezervacijaInfo.Location = new System.Drawing.Point(33, 27);
            this.txtRezervacijaInfo.Name = "txtRezervacijaInfo";
            this.txtRezervacijaInfo.Size = new System.Drawing.Size(53, 20);
            this.txtRezervacijaInfo.TabIndex = 0;
            this.txtRezervacijaInfo.Text = "label1";
            // 
            // txtKlijent
            // 
            this.txtKlijent.AutoSize = true;
            this.txtKlijent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKlijent.Location = new System.Drawing.Point(33, 62);
            this.txtKlijent.Name = "txtKlijent";
            this.txtKlijent.Size = new System.Drawing.Size(53, 20);
            this.txtKlijent.TabIndex = 1;
            this.txtKlijent.Text = "label1";
            // 
            // aa
            // 
            this.aa.AutoSize = true;
            this.aa.Location = new System.Drawing.Point(37, 104);
            this.aa.Name = "aa";
            this.aa.Size = new System.Drawing.Size(43, 13);
            this.aa.TabIndex = 2;
            this.aa.Text = "Naslov:";
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(92, 101);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(210, 20);
            this.txtNaslov.TabIndex = 3;
            this.txtNaslov.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaslov_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sadržaj:";
            // 
            // rtxtSadrzaj
            // 
            this.rtxtSadrzaj.Location = new System.Drawing.Point(92, 166);
            this.rtxtSadrzaj.Name = "rtxtSadrzaj";
            this.rtxtSadrzaj.Size = new System.Drawing.Size(211, 186);
            this.rtxtSadrzaj.TabIndex = 5;
            this.rtxtSadrzaj.Text = "";
            this.rtxtSadrzaj.Validating += new System.ComponentModel.CancelEventHandler(this.rtxtSadrzaj_Validating);
            // 
            // bntPosalji
            // 
            this.bntPosalji.BackColor = System.Drawing.Color.YellowGreen;
            this.bntPosalji.Location = new System.Drawing.Point(170, 407);
            this.bntPosalji.Name = "bntPosalji";
            this.bntPosalji.Size = new System.Drawing.Size(133, 39);
            this.bntPosalji.TabIndex = 6;
            this.bntPosalji.Text = "Pošalji";
            this.bntPosalji.UseVisualStyleBackColor = false;
            this.bntPosalji.Click += new System.EventHandler(this.bntPosalji_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmNovaPoruka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 499);
            this.Controls.Add(this.bntPosalji);
            this.Controls.Add(this.rtxtSadrzaj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaslov);
            this.Controls.Add(this.aa);
            this.Controls.Add(this.txtKlijent);
            this.Controls.Add(this.txtRezervacijaInfo);
            this.Name = "frmNovaPoruka";
            this.Text = "frmNovaPoruka";
            this.Load += new System.EventHandler(this.frmNovaPoruka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtRezervacijaInfo;
        private System.Windows.Forms.Label txtKlijent;
        private System.Windows.Forms.Label aa;
        private System.Windows.Forms.TextBox txtNaslov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtSadrzaj;
        private System.Windows.Forms.Button bntPosalji;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}