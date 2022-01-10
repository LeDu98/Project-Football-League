
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGlavna));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listaStrelacaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rezultatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rasporedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.igraciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGlavni = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGreen;
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.timoviToolStripMenuItem,
            this.igraciToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabelaToolStripMenuItem
            // 
            this.tabelaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelaToolStripMenuItem1,
            this.listaStrelacaToolStripMenuItem});
            this.tabelaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabelaToolStripMenuItem.Name = "tabelaToolStripMenuItem";
            this.tabelaToolStripMenuItem.Size = new System.Drawing.Size(137, 38);
            this.tabelaToolStripMenuItem.Text = "Tabela";
            // 
            // tabelaToolStripMenuItem1
            // 
            this.tabelaToolStripMenuItem1.BackColor = System.Drawing.Color.DarkGreen;
            this.tabelaToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabelaToolStripMenuItem1.Name = "tabelaToolStripMenuItem1";
            this.tabelaToolStripMenuItem1.Size = new System.Drawing.Size(334, 42);
            this.tabelaToolStripMenuItem1.Text = "Tabela";
            this.tabelaToolStripMenuItem1.Click += new System.EventHandler(this.tabelaToolStripMenuItem1_Click);
            // 
            // listaStrelacaToolStripMenuItem
            // 
            this.listaStrelacaToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.listaStrelacaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listaStrelacaToolStripMenuItem.Name = "listaStrelacaToolStripMenuItem";
            this.listaStrelacaToolStripMenuItem.Size = new System.Drawing.Size(334, 42);
            this.listaStrelacaToolStripMenuItem.Text = "Lista strelaca";
            this.listaStrelacaToolStripMenuItem.Click += new System.EventHandler(this.listaStrelacaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rezultatiToolStripMenuItem,
            this.rasporedToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 38);
            this.toolStripMenuItem1.Text = "Utakmice";
            // 
            // rezultatiToolStripMenuItem
            // 
            this.rezultatiToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.rezultatiToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rezultatiToolStripMenuItem.Name = "rezultatiToolStripMenuItem";
            this.rezultatiToolStripMenuItem.Size = new System.Drawing.Size(270, 42);
            this.rezultatiToolStripMenuItem.Text = "Rezultati";
            this.rezultatiToolStripMenuItem.Click += new System.EventHandler(this.rezultatiToolStripMenuItem_Click);
            // 
            // rasporedToolStripMenuItem
            // 
            this.rasporedToolStripMenuItem.BackColor = System.Drawing.Color.DarkGreen;
            this.rasporedToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rasporedToolStripMenuItem.Name = "rasporedToolStripMenuItem";
            this.rasporedToolStripMenuItem.Size = new System.Drawing.Size(270, 42);
            this.rasporedToolStripMenuItem.Text = "Raspored";
            this.rasporedToolStripMenuItem.Click += new System.EventHandler(this.rasporedToolStripMenuItem_Click);
            // 
            // timoviToolStripMenuItem
            // 
            this.timoviToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timoviToolStripMenuItem.Name = "timoviToolStripMenuItem";
            this.timoviToolStripMenuItem.Size = new System.Drawing.Size(137, 38);
            this.timoviToolStripMenuItem.Text = "Timovi";
            this.timoviToolStripMenuItem.Click += new System.EventHandler(this.timoviToolStripMenuItem_Click);
            // 
            // igraciToolStripMenuItem
            // 
            this.igraciToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.igraciToolStripMenuItem.Name = "igraciToolStripMenuItem";
            this.igraciToolStripMenuItem.Size = new System.Drawing.Size(125, 38);
            this.igraciToolStripMenuItem.Text = "Igraci";
            this.igraciToolStripMenuItem.Click += new System.EventHandler(this.igraciToolStripMenuItem_Click);
            // 
            // panelGlavni
            // 
            this.panelGlavni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGlavni.BackColor = System.Drawing.Color.Transparent;
            this.panelGlavni.Location = new System.Drawing.Point(0, 38);
            this.panelGlavni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGlavni.Name = "panelGlavni";
            this.panelGlavni.Size = new System.Drawing.Size(1192, 687);
            this.panelGlavni.TabIndex = 1;
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1188, 729);
            this.Controls.Add(this.panelGlavni);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1210, 785);
            this.Name = "FrmGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fudbalska liga";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGlavna_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem igraciToolStripMenuItem;
        private System.Windows.Forms.Panel panelGlavni;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rezultatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rasporedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaStrelacaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabelaToolStripMenuItem1;
    }
}