
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.dgUtakmice = new System.Windows.Forms.DataGridView();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgUtakmice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodaj.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDodaj.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDodaj.Location = new System.Drawing.Point(948, 199);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(255, 167);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj novu utakmicu";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUnesi
            // 
            this.btnUnesi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnesi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUnesi.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnesi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUnesi.Location = new System.Drawing.Point(948, 401);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(255, 167);
            this.btnUnesi.TabIndex = 1;
            this.btnUnesi.Text = "Unesi rezultat";
            this.btnUnesi.UseVisualStyleBackColor = false;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // dgUtakmice
            // 
            this.dgUtakmice.AllowUserToAddRows = false;
            this.dgUtakmice.AllowUserToDeleteRows = false;
            this.dgUtakmice.AllowUserToResizeColumns = false;
            this.dgUtakmice.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUtakmice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgUtakmice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUtakmice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUtakmice.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgUtakmice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUtakmice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgUtakmice.ColumnHeadersHeight = 34;
            this.dgUtakmice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUtakmice.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgUtakmice.GridColor = System.Drawing.Color.DarkGreen;
            this.dgUtakmice.Location = new System.Drawing.Point(0, 199);
            this.dgUtakmice.MultiSelect = false;
            this.dgUtakmice.Name = "dgUtakmice";
            this.dgUtakmice.ReadOnly = true;
            this.dgUtakmice.RowHeadersVisible = false;
            this.dgUtakmice.RowHeadersWidth = 62;
            this.dgUtakmice.RowTemplate.Height = 38;
            this.dgUtakmice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUtakmice.Size = new System.Drawing.Size(942, 741);
            this.dgUtakmice.TabIndex = 2;
            this.dgUtakmice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUtakmice_CellDoubleClick);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Font = new System.Drawing.Font("Rockwell", 20F, System.Drawing.FontStyle.Bold);
            this.txtPretraga.Location = new System.Drawing.Point(226, 101);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(570, 54);
            this.txtPretraga.TabIndex = 14;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGreen;
            this.label2.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(-7, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1235, 87);
            this.label2.TabIndex = 13;
            this.label2.Text = "Pretraga:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.DarkGreen;
            this.label3.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(-2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1224, 98);
            this.label3.TabIndex = 12;
            this.label3.Text = "RASPORED UTAKMICA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UCRaspored
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgUtakmice);
            this.Controls.Add(this.btnUnesi);
            this.Controls.Add(this.btnDodaj);
            this.Name = "UCRaspored";
            this.Size = new System.Drawing.Size(1222, 943);
            this.Load += new System.EventHandler(this.UCUtakmice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUtakmice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.DataGridView dgUtakmice;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
