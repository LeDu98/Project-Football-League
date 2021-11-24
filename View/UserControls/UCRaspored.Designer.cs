
namespace View.UserControls
{
    partial class UCRaspored
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.dgUtakmice = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgUtakmice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(3, 63);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(234, 62);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj novu utakmicu";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(306, 63);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(234, 62);
            this.btnUnesi.TabIndex = 1;
            this.btnUnesi.Text = "Unesi rezultat";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // dgUtakmice
            // 
            this.dgUtakmice.AllowUserToAddRows = false;
            this.dgUtakmice.AllowUserToDeleteRows = false;
            this.dgUtakmice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUtakmice.Location = new System.Drawing.Point(14, 165);
            this.dgUtakmice.Name = "dgUtakmice";
            this.dgUtakmice.ReadOnly = true;
            this.dgUtakmice.RowHeadersWidth = 62;
            this.dgUtakmice.RowTemplate.Height = 28;
            this.dgUtakmice.Size = new System.Drawing.Size(942, 383);
            this.dgUtakmice.TabIndex = 2;
            // 
            // UCRaspored
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgUtakmice);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.btnDodaj);
            this.Name = "UCRaspored";
            this.Size = new System.Drawing.Size(959, 709);
            this.Load += new System.EventHandler(this.UCUtakmice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUtakmice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.DataGridView dgUtakmice;
    }
}
