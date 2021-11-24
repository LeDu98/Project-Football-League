
namespace View.Dialogs.Utakmice
{
    partial class DialogUpdateUtakmicu
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
            this.lblDomacin = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblGost = new System.Windows.Forms.Label();
            this.numericDomacinGolovi = new System.Windows.Forms.NumericUpDown();
            this.numericGostGolovi = new System.Windows.Forms.NumericUpDown();
            this.dgDomacin = new System.Windows.Forms.DataGridView();
            this.btnUnesiRezultat = new System.Windows.Forms.Button();
            this.dgGost = new System.Windows.Forms.DataGridView();
            this.btnDomacinStrelac = new System.Windows.Forms.Button();
            this.btnGostiStrelac = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.lblDomacinStrelac = new System.Windows.Forms.Label();
            this.lblGostStrelac = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericDomacinGolovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGostGolovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDomacin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGost)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDomacin
            // 
            this.lblDomacin.AutoSize = true;
            this.lblDomacin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomacin.Location = new System.Drawing.Point(12, 93);
            this.lblDomacin.Name = "lblDomacin";
            this.lblDomacin.Size = new System.Drawing.Size(100, 37);
            this.lblDomacin.TabIndex = 0;
            this.lblDomacin.Text = "label1";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(229, 9);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(102, 37);
            this.lblDatum.TabIndex = 1;
            this.lblDatum.Text = "label2";
            // 
            // lblGost
            // 
            this.lblGost.AutoSize = true;
            this.lblGost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGost.Location = new System.Drawing.Point(574, 93);
            this.lblGost.Name = "lblGost";
            this.lblGost.Size = new System.Drawing.Size(102, 37);
            this.lblGost.TabIndex = 1;
            this.lblGost.Text = "label2";
            // 
            // numericDomacinGolovi
            // 
            this.numericDomacinGolovi.Location = new System.Drawing.Point(236, 104);
            this.numericDomacinGolovi.Name = "numericDomacinGolovi";
            this.numericDomacinGolovi.Size = new System.Drawing.Size(120, 26);
            this.numericDomacinGolovi.TabIndex = 2;
            // 
            // numericGostGolovi
            // 
            this.numericGostGolovi.Location = new System.Drawing.Point(362, 104);
            this.numericGostGolovi.Name = "numericGostGolovi";
            this.numericGostGolovi.Size = new System.Drawing.Size(120, 26);
            this.numericGostGolovi.TabIndex = 3;
            // 
            // dgDomacin
            // 
            this.dgDomacin.AllowUserToAddRows = false;
            this.dgDomacin.AllowUserToDeleteRows = false;
            this.dgDomacin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDomacin.Location = new System.Drawing.Point(29, 270);
            this.dgDomacin.Name = "dgDomacin";
            this.dgDomacin.ReadOnly = true;
            this.dgDomacin.RowHeadersWidth = 62;
            this.dgDomacin.RowTemplate.Height = 28;
            this.dgDomacin.Size = new System.Drawing.Size(327, 372);
            this.dgDomacin.TabIndex = 4;
            // 
            // btnUnesiRezultat
            // 
            this.btnUnesiRezultat.Location = new System.Drawing.Point(236, 175);
            this.btnUnesiRezultat.Name = "btnUnesiRezultat";
            this.btnUnesiRezultat.Size = new System.Drawing.Size(246, 63);
            this.btnUnesiRezultat.TabIndex = 5;
            this.btnUnesiRezultat.Text = "Unesi rezultat";
            this.btnUnesiRezultat.UseVisualStyleBackColor = true;
            this.btnUnesiRezultat.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgGost
            // 
            this.dgGost.AllowUserToAddRows = false;
            this.dgGost.AllowUserToDeleteRows = false;
            this.dgGost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGost.Location = new System.Drawing.Point(472, 270);
            this.dgGost.Name = "dgGost";
            this.dgGost.ReadOnly = true;
            this.dgGost.RowHeadersWidth = 62;
            this.dgGost.RowTemplate.Height = 28;
            this.dgGost.Size = new System.Drawing.Size(328, 372);
            this.dgGost.TabIndex = 6;
            // 
            // btnDomacinStrelac
            // 
            this.btnDomacinStrelac.Location = new System.Drawing.Point(29, 667);
            this.btnDomacinStrelac.Name = "btnDomacinStrelac";
            this.btnDomacinStrelac.Size = new System.Drawing.Size(327, 44);
            this.btnDomacinStrelac.TabIndex = 7;
            this.btnDomacinStrelac.Text = "Potvrdi strelca";
            this.btnDomacinStrelac.UseVisualStyleBackColor = true;
            this.btnDomacinStrelac.Click += new System.EventHandler(this.btnDomacinStrelac_Click);
            // 
            // btnGostiStrelac
            // 
            this.btnGostiStrelac.Location = new System.Drawing.Point(473, 667);
            this.btnGostiStrelac.Name = "btnGostiStrelac";
            this.btnGostiStrelac.Size = new System.Drawing.Size(327, 44);
            this.btnGostiStrelac.TabIndex = 8;
            this.btnGostiStrelac.Text = "Potvrdi strelca";
            this.btnGostiStrelac.UseVisualStyleBackColor = true;
            this.btnGostiStrelac.Click += new System.EventHandler(this.btnGostiStrelac_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(473, 782);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(327, 44);
            this.btnSacuvaj.TabIndex = 9;
            this.btnSacuvaj.Text = "Sacuvajte rezultat";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // lblDomacinStrelac
            // 
            this.lblDomacinStrelac.AutoSize = true;
            this.lblDomacinStrelac.Location = new System.Drawing.Point(25, 734);
            this.lblDomacinStrelac.Name = "lblDomacinStrelac";
            this.lblDomacinStrelac.Size = new System.Drawing.Size(51, 20);
            this.lblDomacinStrelac.TabIndex = 10;
            this.lblDomacinStrelac.Text = "label1";
            // 
            // lblGostStrelac
            // 
            this.lblGostStrelac.AutoSize = true;
            this.lblGostStrelac.Location = new System.Drawing.Point(469, 734);
            this.lblGostStrelac.Name = "lblGostStrelac";
            this.lblGostStrelac.Size = new System.Drawing.Size(51, 20);
            this.lblGostStrelac.TabIndex = 11;
            this.lblGostStrelac.Text = "label1";
            // 
            // DialogUpdateUtakmicu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 850);
            this.Controls.Add(this.lblGostStrelac);
            this.Controls.Add(this.lblDomacinStrelac);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnGostiStrelac);
            this.Controls.Add(this.btnDomacinStrelac);
            this.Controls.Add(this.dgGost);
            this.Controls.Add(this.btnUnesiRezultat);
            this.Controls.Add(this.dgDomacin);
            this.Controls.Add(this.numericGostGolovi);
            this.Controls.Add(this.numericDomacinGolovi);
            this.Controls.Add(this.lblGost);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblDomacin);
            this.Name = "DialogUpdateUtakmicu";
            this.Text = "DialogUpdateUtakmicu";
            this.Load += new System.EventHandler(this.DialogUpdateUtakmicu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericDomacinGolovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGostGolovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDomacin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDomacin;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblGost;
        private System.Windows.Forms.NumericUpDown numericDomacinGolovi;
        private System.Windows.Forms.NumericUpDown numericGostGolovi;
        private System.Windows.Forms.DataGridView dgDomacin;
        private System.Windows.Forms.Button btnUnesiRezultat;
        private System.Windows.Forms.DataGridView dgGost;
        private System.Windows.Forms.Button btnDomacinStrelac;
        private System.Windows.Forms.Button btnGostiStrelac;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label lblDomacinStrelac;
        private System.Windows.Forms.Label lblGostStrelac;
    }
}