
namespace DocCentral.WinForms
{
    partial class ShellView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPatients = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPatients
            // 
            this.btnPatients.Location = new System.Drawing.Point(12, 12);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(160, 160);
            this.btnPatients.TabIndex = 0;
            this.btnPatients.Text = "Patienten";
            this.btnPatients.UseVisualStyleBackColor = true;
            this.btnPatients.Click += new System.EventHandler(this.PatientsButtonOnClick);
            // 
            // ShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnPatients);
            this.Name = "ShellView";
            this.Text = "DocCentral für Windows Forms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPatients;
    }
}

