namespace WindowsFormsApp1
{
    partial class FormAccueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MonCompte = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seDéconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAdministrateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesUtilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gérerLesOrganisationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantité = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Poids = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.catégorie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonActualiser = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1084, 601);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MonCompte,
            this.panelAdministrateurToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 42);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MonCompte
            // 
            this.MonCompte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.seDéconnecterToolStripMenuItem});
            this.MonCompte.Name = "MonCompte";
            this.MonCompte.Size = new System.Drawing.Size(176, 38);
            this.MonCompte.Text = "Mon Compte";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.testToolStripMenuItem.Size = new System.Drawing.Size(517, 44);
            this.testToolStripMenuItem.Text = "Accéder à mes informations";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // seDéconnecterToolStripMenuItem
            // 
            this.seDéconnecterToolStripMenuItem.Name = "seDéconnecterToolStripMenuItem";
            this.seDéconnecterToolStripMenuItem.Size = new System.Drawing.Size(517, 44);
            this.seDéconnecterToolStripMenuItem.Text = "Se déconnecter";
            this.seDéconnecterToolStripMenuItem.Click += new System.EventHandler(this.seDéconnecterToolStripMenuItem_Click);
            // 
            // panelAdministrateurToolStripMenuItem
            // 
            this.panelAdministrateurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerLesUtilisateursToolStripMenuItem,
            this.gérerLesOrganisationsToolStripMenuItem});
            this.panelAdministrateurToolStripMenuItem.Name = "panelAdministrateurToolStripMenuItem";
            this.panelAdministrateurToolStripMenuItem.Size = new System.Drawing.Size(252, 38);
            this.panelAdministrateurToolStripMenuItem.Text = "Panel administrateur";
            // 
            // gérerLesUtilisateursToolStripMenuItem
            // 
            this.gérerLesUtilisateursToolStripMenuItem.Name = "gérerLesUtilisateursToolStripMenuItem";
            this.gérerLesUtilisateursToolStripMenuItem.Size = new System.Drawing.Size(390, 44);
            this.gérerLesUtilisateursToolStripMenuItem.Text = "Gérer les utilisateurs";
            this.gérerLesUtilisateursToolStripMenuItem.Click += new System.EventHandler(this.gérerLesUtilisateursToolStripMenuItem_Click);
            // 
            // gérerLesOrganisationsToolStripMenuItem
            // 
            this.gérerLesOrganisationsToolStripMenuItem.Name = "gérerLesOrganisationsToolStripMenuItem";
            this.gérerLesOrganisationsToolStripMenuItem.Size = new System.Drawing.Size(390, 44);
            this.gérerLesOrganisationsToolStripMenuItem.Text = "Gérer les organisations";
            this.gérerLesOrganisationsToolStripMenuItem.Click += new System.EventHandler(this.gérerLesOrganisationsToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightGray;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nom,
            this.Quantité,
            this.Poids,
            this.catégorie,
            this.Date});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(255, 328);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(575, 244);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.Width = 122;
            // 
            // Quantité
            // 
            this.Quantité.Text = "Quantité";
            this.Quantité.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantité.Width = 83;
            // 
            // Poids
            // 
            this.Poids.Text = "Poids (en kg)";
            this.Poids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Poids.Width = 105;
            // 
            // catégorie
            // 
            this.catégorie.Text = "Catégorie";
            this.catégorie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.catégorie.Width = 111;
            // 
            // Date
            // 
            this.Date.Text = "Date d\'ajout";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 150;
            // 
            // buttonActualiser
            // 
            this.buttonActualiser.Location = new System.Drawing.Point(174, 535);
            this.buttonActualiser.Name = "buttonActualiser";
            this.buttonActualiser.Size = new System.Drawing.Size(75, 23);
            this.buttonActualiser.TabIndex = 5;
            this.buttonActualiser.Text = "Actualiser";
            this.buttonActualiser.UseVisualStyleBackColor = true;
            this.buttonActualiser.Click += new System.EventHandler(this.buttonActualiser_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Location = new System.Drawing.Point(174, 506);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(75, 23);
            this.buttonSupprimer.TabIndex = 6;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = true;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // labelMain
            // 
            this.labelMain.BackColor = System.Drawing.Color.Black;
            this.labelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.ForeColor = System.Drawing.Color.White;
            this.labelMain.Location = new System.Drawing.Point(93, 82);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(911, 81);
            this.labelMain.TabIndex = 8;
            this.labelMain.Text = "label";
            this.labelMain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormAccueil
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1084, 601);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSupprimer);
            this.Controls.Add(this.buttonActualiser);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAccueil";
            this.Load += new System.EventHandler(this.FormAccueil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MonCompte;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seDéconnecterToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader Quantité;
        private System.Windows.Forms.ColumnHeader Poids;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader catégorie;
        private System.Windows.Forms.Button buttonActualiser;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.ToolStripMenuItem panelAdministrateurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesUtilisateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gérerLesOrganisationsToolStripMenuItem;
    }
}