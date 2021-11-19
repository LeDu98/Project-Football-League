
namespace View.Dialogs.Utakmice
{
    partial class DialogKreirajUtakmicu
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
            this.cmbDomacin = new System.Windows.Forms.ComboBox();
            this.cmbGost = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnKreiraj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbDomacin
            // 
            this.cmbDomacin.FormattingEnabled = true;
            this.cmbDomacin.Location = new System.Drawing.Point(12, 94);
            this.cmbDomacin.Name = "cmbDomacin";
            this.cmbDomacin.Size = new System.Drawing.Size(235, 28);
            this.cmbDomacin.TabIndex = 0;
            // 
            // cmbGost
            // 
            this.cmbGost.FormattingEnabled = true;
            this.cmbGost.Location = new System.Drawing.Point(588, 94);
            this.cmbGost.Name = "cmbGost";
            this.cmbGost.Size = new System.Drawing.Size(235, 28);
            this.cmbGost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "DOMACIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(646, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "GOST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(195, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "DATUM I VREME UTAKMICE";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 197);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(435, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // btnKreiraj
            // 
            this.btnKreiraj.Location = new System.Drawing.Point(202, 264);
            this.btnKreiraj.Name = "btnKreiraj";
            this.btnKreiraj.Size = new System.Drawing.Size(435, 59);
            this.btnKreiraj.TabIndex = 6;
            this.btnKreiraj.Text = "Kreiraj utakmicu";
            this.btnKreiraj.UseVisualStyleBackColor = true;
            this.btnKreiraj.Click += new System.EventHandler(this.btnKreiraj_Click);
            // 
            // DialogKreirajUtakmicu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 376);
            this.Controls.Add(this.btnKreiraj);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGost);
            this.Controls.Add(this.cmbDomacin);
            this.Name = "DialogKreirajUtakmicu";
            this.Text = "DialogKreirajUtakmicu";
            this.Load += new System.EventHandler(this.DialogKreirajUtakmicu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDomacin;
        private System.Windows.Forms.ComboBox cmbGost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnKreiraj;
    }
}