namespace Proje_Hastane
{
    partial class FrmGirisler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGirisler));
            this.btnHastaGiris = new System.Windows.Forms.Button();
            this.btnDoktorGiris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSekreterGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHastaGiris
            // 
            this.btnHastaGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHastaGiris.BackgroundImage")));
            this.btnHastaGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHastaGiris.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHastaGiris.Location = new System.Drawing.Point(39, 142);
            this.btnHastaGiris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHastaGiris.Name = "btnHastaGiris";
            this.btnHastaGiris.Size = new System.Drawing.Size(260, 162);
            this.btnHastaGiris.TabIndex = 0;
            this.btnHastaGiris.UseVisualStyleBackColor = true;
            this.btnHastaGiris.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDoktorGiris
            // 
            this.btnDoktorGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoktorGiris.BackgroundImage")));
            this.btnDoktorGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDoktorGiris.Location = new System.Drawing.Point(306, 142);
            this.btnDoktorGiris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDoktorGiris.Name = "btnDoktorGiris";
            this.btnDoktorGiris.Size = new System.Drawing.Size(272, 162);
            this.btnDoktorGiris.TabIndex = 1;
            this.btnDoktorGiris.UseVisualStyleBackColor = true;
            this.btnDoktorGiris.Click += new System.EventHandler(this.btnDoktorGiris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(325, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Melek Hastanesi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Doktor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sekreter";
            // 
            // btnSekreterGiris
            // 
            this.btnSekreterGiris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSekreterGiris.BackgroundImage")));
            this.btnSekreterGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSekreterGiris.Location = new System.Drawing.Point(585, 142);
            this.btnSekreterGiris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSekreterGiris.Name = "btnSekreterGiris";
            this.btnSekreterGiris.Size = new System.Drawing.Size(279, 162);
            this.btnSekreterGiris.TabIndex = 2;
            this.btnSekreterGiris.UseVisualStyleBackColor = true;
            this.btnSekreterGiris.Click += new System.EventHandler(this.btnSekreterGiris_Click);
            // 
            // FrmGirisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(893, 498);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSekreterGiris);
            this.Controls.Add(this.btnDoktorGiris);
            this.Controls.Add(this.btnHastaGiris);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmGirisler";
            this.Text = "Melek Hastanesi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHastaGiris;
        private System.Windows.Forms.Button btnDoktorGiris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSekreterGiris;
    }
}

