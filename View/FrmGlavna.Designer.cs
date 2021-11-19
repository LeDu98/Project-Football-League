
namespace View
{
    partial class FrmGlavna
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utakmiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.igraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGlavni = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelaToolStripMenuItem,
            this.utakmiceToolStripMenuItem,
            this.timoviToolStripMenuItem,
            this.igraciToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabelaToolStripMenuItem
            // 
            this.tabelaToolStripMenuItem.Name = "tabelaToolStripMenuItem";
            this.tabelaToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.tabelaToolStripMenuItem.Text = "Tabela";
            this.tabelaToolStripMenuItem.Click += new System.EventHandler(this.tabelaToolStripMenuItem_Click);
            // 
            // utakmiceToolStripMenuItem
            // 
            this.utakmiceToolStripMenuItem.Name = "utakmiceToolStripMenuItem";
            this.utakmiceToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            this.utakmiceToolStripMenuItem.Text = "Utakmice";
            this.utakmiceToolStripMenuItem.Click += new System.EventHandler(this.utakmiceToolStripMenuItem_Click);
            // 
            // timoviToolStripMenuItem
            // 
            this.timoviToolStripMenuItem.Name = "timoviToolStripMenuItem";
            this.timoviToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.timoviToolStripMenuItem.Text = "Timovi";
            this.timoviToolStripMenuItem.Click += new System.EventHandler(this.timoviToolStripMenuItem_Click);
            // 
            // igraciToolStripMenuItem
            // 
            this.igraciToolStripMenuItem.Name = "igraciToolStripMenuItem";
            this.igraciToolStripMenuItem.Size = new System.Drawing.Size(71, 29);
            this.igraciToolStripMenuItem.Text = "Igraci";
            this.igraciToolStripMenuItem.Click += new System.EventHandler(this.igraciToolStripMenuItem_Click);
            // 
            // panelGlavni
            // 
            this.panelGlavni.Location = new System.Drawing.Point(0, 42);
            this.panelGlavni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGlavni.Name = "panelGlavni";
            this.panelGlavni.Size = new System.Drawing.Size(1200, 652);
            this.panelGlavni.TabIndex = 1;
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panelGlavni);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmGlavna";
            this.Text = "FrmGlavna";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utakmiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem igraciToolStripMenuItem;
        private System.Windows.Forms.Panel panelGlavni;
    }
}