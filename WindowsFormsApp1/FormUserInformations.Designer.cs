namespace WindowsFormsApp1
{
    partial class FormUserInformations
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
            this.labelMail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.labelLastConnection = new System.Windows.Forms.Label();
            this.labelOrganisation = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(35, 45);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(98, 25);
            this.labelMail.TabIndex = 0;
            this.labelMail.Text = "labelMail";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(35, 109);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(152, 25);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "labelPassword";
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.AutoSize = true;
            this.labelCreationDate.Location = new System.Drawing.Point(35, 171);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(184, 25);
            this.labelCreationDate.TabIndex = 2;
            this.labelCreationDate.Text = "labelCreationDate";
            // 
            // labelLastConnection
            // 
            this.labelLastConnection.AutoSize = true;
            this.labelLastConnection.Location = new System.Drawing.Point(35, 236);
            this.labelLastConnection.Name = "labelLastConnection";
            this.labelLastConnection.Size = new System.Drawing.Size(208, 25);
            this.labelLastConnection.TabIndex = 3;
            this.labelLastConnection.Text = "labelLastConnection";
            // 
            // labelOrganisation
            // 
            this.labelOrganisation.AutoSize = true;
            this.labelOrganisation.Location = new System.Drawing.Point(35, 304);
            this.labelOrganisation.Name = "labelOrganisation";
            this.labelOrganisation.Size = new System.Drawing.Size(180, 25);
            this.labelOrganisation.TabIndex = 4;
            this.labelOrganisation.Text = "labelOrganisation";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(487, 455);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(145, 47);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormUserInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 514);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelOrganisation);
            this.Controls.Add(this.labelLastConnection);
            this.Controls.Add(this.labelCreationDate);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormUserInformations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUserInformations";
            this.Load += new System.EventHandler(this.FormUserInformations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.Label labelLastConnection;
        private System.Windows.Forms.Label labelOrganisation;
        private System.Windows.Forms.Button buttonOK;
    }
}