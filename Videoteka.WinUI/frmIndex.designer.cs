namespace Videoteka.WinUI
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuKlijent = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKlijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvještajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porukeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primljenePorukeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poslanePorukeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.državeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.žanroviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.režiseriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojProfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.klijentiToolStripMenuItem,
            this.filmoviToolStripMenuItem,
            this.rezervacijeToolStripMenuItem,
            this.izvještajiToolStripMenuItem,
            this.porukeToolStripMenuItem,
            this.državeToolStripMenuItem,
            this.gradoviToolStripMenuItem,
            this.žanroviToolStripMenuItem,
            this.režiseriToolStripMenuItem,
            this.profilToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // klijentiToolStripMenuItem
            // 
            this.klijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuKlijent,
            this.noviKlijentToolStripMenuItem});
            this.klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            this.klijentiToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.klijentiToolStripMenuItem.Text = "Klijenti";
            // 
            // pretragaToolStripMenuKlijent
            // 
            this.pretragaToolStripMenuKlijent.Name = "pretragaToolStripMenuKlijent";
            this.pretragaToolStripMenuKlijent.Size = new System.Drawing.Size(134, 22);
            this.pretragaToolStripMenuKlijent.Text = "Pretraga";
            this.pretragaToolStripMenuKlijent.Click += new System.EventHandler(this.pretragaToolStripMenuKlijent_Click);
            // 
            // noviKlijentToolStripMenuItem
            // 
            this.noviKlijentToolStripMenuItem.Name = "noviKlijentToolStripMenuItem";
            this.noviKlijentToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.noviKlijentToolStripMenuItem.Text = "Novi klijent";
            this.noviKlijentToolStripMenuItem.Click += new System.EventHandler(this.noviKlijentToolStripMenuItem_Click);
            // 
            // filmoviToolStripMenuItem
            // 
            this.filmoviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviFilmToolStripMenuItem});
            this.filmoviToolStripMenuItem.Name = "filmoviToolStripMenuItem";
            this.filmoviToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.filmoviToolStripMenuItem.Text = "Filmovi";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // noviFilmToolStripMenuItem
            // 
            this.noviFilmToolStripMenuItem.Name = "noviFilmToolStripMenuItem";
            this.noviFilmToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.noviFilmToolStripMenuItem.Text = "Novi film";
            this.noviFilmToolStripMenuItem.Click += new System.EventHandler(this.noviFilmToolStripMenuItem_Click);
            // 
            // rezervacijeToolStripMenuItem
            // 
            this.rezervacijeToolStripMenuItem.Name = "rezervacijeToolStripMenuItem";
            this.rezervacijeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.rezervacijeToolStripMenuItem.Text = "Rezervacije";
            this.rezervacijeToolStripMenuItem.Click += new System.EventHandler(this.rezervacijeToolStripMenuItem_Click);
            // 
            // izvještajiToolStripMenuItem
            // 
            this.izvještajiToolStripMenuItem.Name = "izvještajiToolStripMenuItem";
            this.izvještajiToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.izvještajiToolStripMenuItem.Text = "Izvještaji";
            this.izvještajiToolStripMenuItem.Click += new System.EventHandler(this.izvještajiToolStripMenuItem_Click);
            // 
            // porukeToolStripMenuItem
            // 
            this.porukeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.primljenePorukeToolStripMenuItem,
            this.poslanePorukeToolStripMenuItem});
            this.porukeToolStripMenuItem.Name = "porukeToolStripMenuItem";
            this.porukeToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.porukeToolStripMenuItem.Text = "Poruke";
            // 
            // primljenePorukeToolStripMenuItem
            // 
            this.primljenePorukeToolStripMenuItem.Name = "primljenePorukeToolStripMenuItem";
            this.primljenePorukeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.primljenePorukeToolStripMenuItem.Text = "Primljene poruke";
            this.primljenePorukeToolStripMenuItem.Click += new System.EventHandler(this.primljenePorukeToolStripMenuItem_Click);
            // 
            // poslanePorukeToolStripMenuItem
            // 
            this.poslanePorukeToolStripMenuItem.Name = "poslanePorukeToolStripMenuItem";
            this.poslanePorukeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.poslanePorukeToolStripMenuItem.Text = "Poslane poruke";
            this.poslanePorukeToolStripMenuItem.Click += new System.EventHandler(this.poslanePorukeToolStripMenuItem_Click);
            // 
            // državeToolStripMenuItem
            // 
            this.državeToolStripMenuItem.Name = "državeToolStripMenuItem";
            this.državeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.državeToolStripMenuItem.Text = "Države";
            this.državeToolStripMenuItem.Click += new System.EventHandler(this.državeToolStripMenuItem_Click);
            // 
            // gradoviToolStripMenuItem
            // 
            this.gradoviToolStripMenuItem.Name = "gradoviToolStripMenuItem";
            this.gradoviToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.gradoviToolStripMenuItem.Text = "Gradovi";
            this.gradoviToolStripMenuItem.Click += new System.EventHandler(this.gradoviToolStripMenuItem_Click);
            // 
            // žanroviToolStripMenuItem
            // 
            this.žanroviToolStripMenuItem.Name = "žanroviToolStripMenuItem";
            this.žanroviToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.žanroviToolStripMenuItem.Text = "Žanrovi";
            this.žanroviToolStripMenuItem.Click += new System.EventHandler(this.žanroviToolStripMenuItem_Click);
            // 
            // režiseriToolStripMenuItem
            // 
            this.režiseriToolStripMenuItem.Name = "režiseriToolStripMenuItem";
            this.režiseriToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.režiseriToolStripMenuItem.Text = "Režiseri";
            this.režiseriToolStripMenuItem.Click += new System.EventHandler(this.režiseriToolStripMenuItem_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojProfilToolStripMenuItem,
            this.odjaviSeToolStripMenuItem});
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // mojProfilToolStripMenuItem
            // 
            this.mojProfilToolStripMenuItem.Name = "mojProfilToolStripMenuItem";
            this.mojProfilToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.mojProfilToolStripMenuItem.Text = "Moj profil";
            this.mojProfilToolStripMenuItem.Click += new System.EventHandler(this.mojProfilToolStripMenuItem_Click);
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            this.odjaviSeToolStripMenuItem.Click += new System.EventHandler(this.odjaviSeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmIndex";
            this.Text = "Index";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filmoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervacijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvještajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuKlijent;
        private System.Windows.Forms.ToolStripMenuItem noviKlijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noviFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porukeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mojProfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primljenePorukeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poslanePorukeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem državeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem žanroviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem režiseriToolStripMenuItem;
    }
}



