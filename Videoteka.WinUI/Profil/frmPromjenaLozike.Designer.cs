namespace Videoteka.WinUI.Profil
{
    partial class frmPromjenaLozike
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
            this.txtNoviPasswordPotvrda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoviPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStariPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bntSacuvaj = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoviPasswordPotvrda
            // 
            this.txtNoviPasswordPotvrda.Location = new System.Drawing.Point(45, 165);
            this.txtNoviPasswordPotvrda.Name = "txtNoviPasswordPotvrda";
            this.txtNoviPasswordPotvrda.PasswordChar = '*';
            this.txtNoviPasswordPotvrda.Size = new System.Drawing.Size(150, 20);
            this.txtNoviPasswordPotvrda.TabIndex = 67;
            this.txtNoviPasswordPotvrda.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoviPasswordPotvrda_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Novi password potvrda";
            // 
            // txtNoviPassword
            // 
            this.txtNoviPassword.Location = new System.Drawing.Point(45, 124);
            this.txtNoviPassword.Name = "txtNoviPassword";
            this.txtNoviPassword.PasswordChar = '*';
            this.txtNoviPassword.Size = new System.Drawing.Size(150, 20);
            this.txtNoviPassword.TabIndex = 65;
            this.txtNoviPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoviPassword_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Novi password";
            // 
            // txtStariPassword
            // 
            this.txtStariPassword.Location = new System.Drawing.Point(45, 82);
            this.txtStariPassword.Name = "txtStariPassword";
            this.txtStariPassword.PasswordChar = '*';
            this.txtStariPassword.Size = new System.Drawing.Size(150, 20);
            this.txtStariPassword.TabIndex = 63;
            this.txtStariPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtStariPassword_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Stari password";
            // 
            // bntSacuvaj
            // 
            this.bntSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.bntSacuvaj.Location = new System.Drawing.Point(45, 265);
            this.bntSacuvaj.Name = "bntSacuvaj";
            this.bntSacuvaj.Size = new System.Drawing.Size(150, 36);
            this.bntSacuvaj.TabIndex = 68;
            this.bntSacuvaj.Text = "Sačuvaj";
            this.bntSacuvaj.UseVisualStyleBackColor = false;
            this.bntSacuvaj.Click += new System.EventHandler(this.bntSacuvaj_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmPromjenaLozike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 397);
            this.Controls.Add(this.bntSacuvaj);
            this.Controls.Add(this.txtNoviPasswordPotvrda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNoviPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStariPassword);
            this.Controls.Add(this.label9);
            this.Name = "frmPromjenaLozike";
            this.Text = "frmPromjenaLozike";
            this.Load += new System.EventHandler(this.frmPromjenaLozike_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoviPasswordPotvrda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoviPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStariPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bntSacuvaj;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}