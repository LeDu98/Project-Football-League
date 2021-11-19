
namespace View.UserControls
{
    partial class UCTabela
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
            this.dgTabela = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTabela
            // 
            this.dgTabela.AllowUserToAddRows = false;
            this.dgTabela.AllowUserToDeleteRows = false;
            this.dgTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTabela.Location = new System.Drawing.Point(4, 78);
            this.dgTabela.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgTabela.Name = "dgTabela";
            this.dgTabela.ReadOnly = true;
            this.dgTabela.RowHeadersWidth = 62;
            this.dgTabela.Size = new System.Drawing.Size(855, 525);
            this.dgTabela.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "TABELA";
            // 
            // UCTabela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTabela);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UCTabela";
            this.Size = new System.Drawing.Size(867, 608);
            this.Load += new System.EventHandler(this.UCTabela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTabela;
        private System.Windows.Forms.Label label1;
    }
}
