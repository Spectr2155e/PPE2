namespace WindowsFormsApp1
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLoginUserName = new System.Windows.Forms.TextBox();
            this.siticoneContextMenuStrip1 = new Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip();
            this.textBoxLoginPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 603);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Se connecter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLoginUserName
            // 
            this.textBoxLoginUserName.Location = new System.Drawing.Point(496, 364);
            this.textBoxLoginUserName.Name = "textBoxLoginUserName";
            this.textBoxLoginUserName.Size = new System.Drawing.Size(447, 31);
            this.textBoxLoginUserName.TabIndex = 1;
            this.textBoxLoginUserName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // siticoneContextMenuStrip1
            // 
            this.siticoneContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.siticoneContextMenuStrip1.Name = "siticoneContextMenuStrip1";
            this.siticoneContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.ColorTable = null;
            this.siticoneContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.siticoneContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxLoginPassword
            // 
            this.textBoxLoginPassword.Location = new System.Drawing.Point(496, 430);
            this.textBoxLoginPassword.Name = "textBoxLoginPassword";
            this.textBoxLoginPassword.PasswordChar = '*';
            this.textBoxLoginPassword.Size = new System.Drawing.Size(447, 31);
            this.textBoxLoginPassword.TabIndex = 3;
            this.textBoxLoginPassword.TextChanged += new System.EventHandler(this.textBoxLoginPassword_TextChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 881);
            this.Controls.Add(this.textBoxLoginPassword);
            this.Controls.Add(this.textBoxLoginUserName);
            this.Controls.Add(this.button1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLoginUserName;
        private Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip siticoneContextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxLoginPassword;
    }
}

