
using System.Collections.Generic;
using System.Windows.Forms;

namespace KoUtilities
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.Rola_Pres_cb1 = new System.Windows.Forms.ComboBox();
            this.Rola_version_cb2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(141, 98);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(103, 21);
            this.buttonAceptar.TabIndex = 0;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // Rola_Pres_cb1
            // 
            this.Rola_Pres_cb1.FormattingEnabled = true;
            this.Rola_Pres_cb1.Location = new System.Drawing.Point(114, 12);
            this.Rola_Pres_cb1.Name = "Rola_Pres_cb1";
            this.Rola_Pres_cb1.Size = new System.Drawing.Size(238, 21);
            this.Rola_Pres_cb1.TabIndex = 1;
            this.Rola_Pres_cb1.SelectedIndexChanged += new System.EventHandler(this.Rola_Pres_cb1_SelectedIndexChanged);
            // 
            // Rola_version_cb2
            // 
            this.Rola_version_cb2.FormattingEnabled = true;
            this.Rola_version_cb2.Location = new System.Drawing.Point(114, 56);
            this.Rola_version_cb2.Name = "Rola_version_cb2";
            this.Rola_version_cb2.Size = new System.Drawing.Size(238, 21);
            this.Rola_version_cb2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Presupuesto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Versión";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rola_version_cb2);
            this.Controls.Add(this.Rola_Pres_cb1);
            this.Controls.Add(this.buttonAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "KoUtilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.ComboBox Rola_Pres_cb1;
        private ComboBox Rola_version_cb2;
        private Label label1;
        private Label label2;
    }
}

