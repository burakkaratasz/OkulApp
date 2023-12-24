namespace OkulAppSube2BIL
{
    partial class frmOgretmenKayit
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
            this.gbOgretmen = new System.Windows.Forms.GroupBox();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblTc = new System.Windows.Forms.Label();
            this.tbAd = new System.Windows.Forms.TextBox();
            this.tbSoyad = new System.Windows.Forms.TextBox();
            this.tbTc = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.gbOgretmen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOgretmen
            // 
            this.gbOgretmen.Controls.Add(this.tbTc);
            this.gbOgretmen.Controls.Add(this.tbSoyad);
            this.gbOgretmen.Controls.Add(this.tbAd);
            this.gbOgretmen.Controls.Add(this.lblTc);
            this.gbOgretmen.Controls.Add(this.lblSoyad);
            this.gbOgretmen.Controls.Add(this.lblAd);
            this.gbOgretmen.Location = new System.Drawing.Point(25, 36);
            this.gbOgretmen.Name = "gbOgretmen";
            this.gbOgretmen.Size = new System.Drawing.Size(236, 153);
            this.gbOgretmen.TabIndex = 0;
            this.gbOgretmen.TabStop = false;
            this.gbOgretmen.Text = "Öğretmen Bilgileri";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(30, 41);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(20, 13);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "Ad";
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(30, 71);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(37, 13);
            this.lblSoyad.TabIndex = 1;
            this.lblSoyad.Text = "Soyad";
            // 
            // lblTc
            // 
            this.lblTc.AutoSize = true;
            this.lblTc.Location = new System.Drawing.Point(30, 100);
            this.lblTc.Name = "lblTc";
            this.lblTc.Size = new System.Drawing.Size(38, 13);
            this.lblTc.TabIndex = 2;
            this.lblTc.Text = "TC No";
            // 
            // tbAd
            // 
            this.tbAd.Location = new System.Drawing.Point(87, 34);
            this.tbAd.Name = "tbAd";
            this.tbAd.Size = new System.Drawing.Size(100, 20);
            this.tbAd.TabIndex = 3;
            // 
            // tbSoyad
            // 
            this.tbSoyad.Location = new System.Drawing.Point(87, 64);
            this.tbSoyad.Name = "tbSoyad";
            this.tbSoyad.Size = new System.Drawing.Size(100, 20);
            this.tbSoyad.TabIndex = 4;
            // 
            // tbTc
            // 
            this.tbTc.Location = new System.Drawing.Point(87, 97);
            this.tbTc.Name = "tbTc";
            this.tbTc.Size = new System.Drawing.Size(100, 20);
            this.tbTc.TabIndex = 5;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(101, 195);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmOgretmenKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 259);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gbOgretmen);
            this.Name = "frmOgretmenKayit";
            this.Text = "Öğretmen Kayıt İşlemleri";
            this.Load += new System.EventHandler(this.frmOgretmenKayit_Load);
            this.gbOgretmen.ResumeLayout(false);
            this.gbOgretmen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOgretmen;
        private System.Windows.Forms.TextBox tbTc;
        private System.Windows.Forms.TextBox tbSoyad;
        private System.Windows.Forms.TextBox tbAd;
        private System.Windows.Forms.Label lblTc;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Button btnKaydet;
    }
}