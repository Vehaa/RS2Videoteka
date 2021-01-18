namespace Videoteka.WinUI.Gradovi
{
    partial class frmGradovi
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
            this.label2 = new System.Windows.Forms.Label();
            this.ddDrzava = new System.Windows.Forms.Label();
            this.cmbDrzava = new System.Windows.Forms.ComboBox();
            this.txtSearchGrad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDrzavaDodaj = new System.Windows.Forms.ComboBox();
            this.txtPostanskiBroj = new System.Windows.Forms.TextBox();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGradovi = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostanskiBroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Naziv";
            // 
            // ddDrzava
            // 
            this.ddDrzava.AutoSize = true;
            this.ddDrzava.Location = new System.Drawing.Point(19, 34);
            this.ddDrzava.Name = "ddDrzava";
            this.ddDrzava.Size = new System.Drawing.Size(41, 13);
            this.ddDrzava.TabIndex = 13;
            this.ddDrzava.Text = "Država";
            // 
            // cmbDrzava
            // 
            this.cmbDrzava.FormattingEnabled = true;
            this.cmbDrzava.Location = new System.Drawing.Point(19, 50);
            this.cmbDrzava.Name = "cmbDrzava";
            this.cmbDrzava.Size = new System.Drawing.Size(177, 21);
            this.cmbDrzava.TabIndex = 12;
            // 
            // txtSearchGrad
            // 
            this.txtSearchGrad.Location = new System.Drawing.Point(19, 102);
            this.txtSearchGrad.Name = "txtSearchGrad";
            this.txtSearchGrad.Size = new System.Drawing.Size(177, 20);
            this.txtSearchGrad.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Poštanski broj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Naziv grada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Država";
            // 
            // cmbDrzavaDodaj
            // 
            this.cmbDrzavaDodaj.FormattingEnabled = true;
            this.cmbDrzavaDodaj.Location = new System.Drawing.Point(531, 96);
            this.cmbDrzavaDodaj.Name = "cmbDrzavaDodaj";
            this.cmbDrzavaDodaj.Size = new System.Drawing.Size(177, 21);
            this.cmbDrzavaDodaj.TabIndex = 18;
            this.cmbDrzavaDodaj.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrzavaDodaj_Validating);
            // 
            // txtPostanskiBroj
            // 
            this.txtPostanskiBroj.Location = new System.Drawing.Point(531, 188);
            this.txtPostanskiBroj.Name = "txtPostanskiBroj";
            this.txtPostanskiBroj.Size = new System.Drawing.Size(177, 20);
            this.txtPostanskiBroj.TabIndex = 17;
            this.txtPostanskiBroj.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostanskiBroj_Validating);
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(531, 148);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(177, 20);
            this.txtGrad.TabIndex = 16;
            this.txtGrad.Validating += new System.ComponentModel.CancelEventHandler(this.txtGrad_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGradovi);
            this.groupBox1.Location = new System.Drawing.Point(15, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 232);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gradovi";
            // 
            // dgvGradovi
            // 
            this.dgvGradovi.AllowUserToAddRows = false;
            this.dgvGradovi.AllowUserToDeleteRows = false;
            this.dgvGradovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.PostanskiBroj});
            this.dgvGradovi.Location = new System.Drawing.Point(7, 20);
            this.dgvGradovi.Name = "dgvGradovi";
            this.dgvGradovi.ReadOnly = true;
            this.dgvGradovi.Size = new System.Drawing.Size(292, 206);
            this.dgvGradovi.TabIndex = 0;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // PostanskiBroj
            // 
            this.PostanskiBroj.DataPropertyName = "PostanskiBroj";
            this.PostanskiBroj.HeaderText = "Poštanski broj";
            this.PostanskiBroj.Name = "PostanskiBroj";
            this.PostanskiBroj.ReadOnly = true;
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(203, 148);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(111, 23);
            this.btnPretraga.TabIndex = 23;
            this.btnPretraga.Text = "Pretrazi";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.Lime;
            this.btnDodaj.Location = new System.Drawing.Point(531, 245);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(177, 23);
            this.btnDodaj.TabIndex = 25;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Dodaj novi grad";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGradovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDrzavaDodaj);
            this.Controls.Add(this.txtPostanskiBroj);
            this.Controls.Add(this.txtGrad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddDrzava);
            this.Controls.Add(this.cmbDrzava);
            this.Controls.Add(this.txtSearchGrad);
            this.Name = "frmGradovi";
            this.Text = "frmGradovi";
            this.Load += new System.EventHandler(this.frmGradovi_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ddDrzava;
        private System.Windows.Forms.ComboBox cmbDrzava;
        private System.Windows.Forms.TextBox txtSearchGrad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDrzavaDodaj;
        private System.Windows.Forms.TextBox txtPostanskiBroj;
        private System.Windows.Forms.TextBox txtGrad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGradovi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostanskiBroj;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}