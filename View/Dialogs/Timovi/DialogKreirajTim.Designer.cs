
namespace View.Dialogs.Timovi
{
    partial class DialogKreirajTim
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.txtBojaKluba = new System.Windows.Forms.TextBox();
            this.txtPobede = new System.Windows.Forms.TextBox();
            this.txtNeresene = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPorazi = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(214, 65);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(307, 26);
            this.txtNaziv.TabIndex = 0;
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(214, 108);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(307, 26);
            this.txtGrad.TabIndex = 1;
            // 
            // txtBojaKluba
            // 
            this.txtBojaKluba.Location = new System.Drawing.Point(214, 152);
            this.txtBojaKluba.Name = "txtBojaKluba";
            this.txtBojaKluba.Size = new System.Drawing.Size(307, 26);
            this.txtBojaKluba.TabIndex = 2;
            // 
            // txtPobede
            // 
            this.txtPobede.Location = new System.Drawing.Point(214, 195);
            this.txtPobede.Name = "txtPobede";
            this.txtPobede.Size = new System.Drawing.Size(307, 26);
            this.txtPobede.TabIndex = 3;
            // 
            // txtNeresene
            // 
            this.txtNeresene.Location = new System.Drawing.Point(214, 240);
            this.txtNeresene.Name = "txtNeresene";
            this.txtNeresene.Size = new System.Drawing.Size(307, 26);
            this.txtNeresene.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Naziv tima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Grad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Boja kluba";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pobede";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Neresene";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Porazi";
            // 
            // txtPorazi
            // 
            this.txtPorazi.Location = new System.Drawing.Point(214, 285);
            this.txtPorazi.Name = "txtPorazi";
            this.txtPorazi.Size = new System.Drawing.Size(307, 26);
            this.txtPorazi.TabIndex = 10;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(75, 343);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(446, 38);
            this.btnDodaj.TabIndex = 12;
            this.btnDodaj.Text = "Dodaj tim";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // DialogKreirajTim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 437);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPorazi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNeresene);
            this.Controls.Add(this.txtPobede);
            this.Controls.Add(this.txtBojaKluba);
            this.Controls.Add(this.txtGrad);
            this.Controls.Add(this.txtNaziv);
            this.Name = "DialogKreirajTim";
            this.Text = "DialogDodajTim";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtGrad;
        private System.Windows.Forms.TextBox txtBojaKluba;
        private System.Windows.Forms.TextBox txtPobede;
        private System.Windows.Forms.TextBox txtNeresene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPorazi;
        private System.Windows.Forms.Button btnDodaj;
    }
}