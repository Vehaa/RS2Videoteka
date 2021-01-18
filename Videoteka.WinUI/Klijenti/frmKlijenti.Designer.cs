namespace Videoteka.WinUI.Klijenti
{
    partial class frmKlijenti
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grad = new System.Windows.Forms.Label();
            this.cmbSearchGrad = new System.Windows.Forms.ComboBox();
            this.txtSearchUsername = new System.Windows.Forms.TextBox();
            this.txtSearchPrezime = new System.Windows.Forms.TextBox();
            this.txtSearchIme = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.KlijentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatumRegistracijeOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumRegistracijeDo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Prezime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ime";
            // 
            // Grad
            // 
            this.Grad.AutoSize = true;
            this.Grad.Location = new System.Drawing.Point(12, 133);
            this.Grad.Name = "Grad";
            this.Grad.Size = new System.Drawing.Size(30, 13);
            this.Grad.TabIndex = 16;
            this.Grad.Text = "Grad";
            // 
            // cmbSearchGrad
            // 
            this.cmbSearchGrad.FormattingEnabled = true;
            this.cmbSearchGrad.Location = new System.Drawing.Point(12, 149);
            this.cmbSearchGrad.Name = "cmbSearchGrad";
            this.cmbSearchGrad.Size = new System.Drawing.Size(177, 21);
            this.cmbSearchGrad.TabIndex = 15;
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.Location = new System.Drawing.Point(12, 110);
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.Size = new System.Drawing.Size(177, 20);
            this.txtSearchUsername.TabIndex = 14;
            // 
            // txtSearchPrezime
            // 
            this.txtSearchPrezime.Location = new System.Drawing.Point(12, 70);
            this.txtSearchPrezime.Name = "txtSearchPrezime";
            this.txtSearchPrezime.Size = new System.Drawing.Size(177, 20);
            this.txtSearchPrezime.TabIndex = 13;
            // 
            // txtSearchIme
            // 
            this.txtSearchIme.Location = new System.Drawing.Point(12, 28);
            this.txtSearchIme.Name = "txtSearchIme";
            this.txtSearchIme.Size = new System.Drawing.Size(177, 20);
            this.txtSearchIme.TabIndex = 12;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(540, 32);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(135, 38);
            this.btnPrikazi.TabIndex = 11;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKlijenti);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 242);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Klijenti";
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.AllowUserToDeleteRows = false;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KlijentId,
            this.Ime,
            this.Prezime,
            this.Username,
            this.Email,
            this.Telefon,
            this.Adresa});
            this.dgvKlijenti.Location = new System.Drawing.Point(0, 25);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(648, 217);
            this.dgvKlijenti.TabIndex = 0;
            this.dgvKlijenti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKlijenti_MouseDoubleClick);
            // 
            // KlijentId
            // 
            this.KlijentId.DataPropertyName = "KlijentId";
            this.KlijentId.HeaderText = "KlijentId";
            this.KlijentId.Name = "KlijentId";
            this.KlijentId.ReadOnly = true;
            this.KlijentId.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "UserName";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 20);
            this.txtEmail.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Datum registracije od:";
            // 
            // dtpDatumRegistracijeOd
            // 
            this.dtpDatumRegistracijeOd.Location = new System.Drawing.Point(12, 235);
            this.dtpDatumRegistracijeOd.Name = "dtpDatumRegistracijeOd";
            this.dtpDatumRegistracijeOd.Size = new System.Drawing.Size(174, 20);
            this.dtpDatumRegistracijeOd.TabIndex = 24;
            // 
            // dtpDatumRegistracijeDo
            // 
            this.dtpDatumRegistracijeDo.Location = new System.Drawing.Point(12, 277);
            this.dtpDatumRegistracijeDo.Name = "dtpDatumRegistracijeDo";
            this.dtpDatumRegistracijeDo.Size = new System.Drawing.Size(174, 20);
            this.dtpDatumRegistracijeDo.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Datum registracije do:";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(12, 313);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(68, 17);
            this.cbStatus.TabIndex = 27;
            this.cbStatus.Text = "Aktivan?";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // frmKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 628);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dtpDatumRegistracijeDo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDatumRegistracijeOd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grad);
            this.Controls.Add(this.cmbSearchGrad);
            this.Controls.Add(this.txtSearchUsername);
            this.Controls.Add(this.txtSearchPrezime);
            this.Controls.Add(this.txtSearchIme);
            this.Controls.Add(this.btnPrikazi);
            this.Name = "frmKlijenti";
            this.Text = "Klijenti";
            this.Load += new System.EventHandler(this.frmKlijenti_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Grad;
        private System.Windows.Forms.ComboBox cmbSearchGrad;
        private System.Windows.Forms.TextBox txtSearchUsername;
        private System.Windows.Forms.TextBox txtSearchPrezime;
        private System.Windows.Forms.TextBox txtSearchIme;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDatumRegistracijeOd;
        private System.Windows.Forms.DateTimePicker dtpDatumRegistracijeDo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn KlijentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.CheckBox cbStatus;
    }
}