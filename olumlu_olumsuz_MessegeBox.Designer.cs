namespace MaterialSkinExample
{
    partial class olumlu_olumsuz_MessegeBox
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
            this.gelen_mesaj_label = new System.Windows.Forms.Label();
            this.tamam_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.uyari_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.uyari_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gelen_mesaj_label
            // 
            this.gelen_mesaj_label.AutoSize = true;
            this.gelen_mesaj_label.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gelen_mesaj_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gelen_mesaj_label.Location = new System.Drawing.Point(88, 96);
            this.gelen_mesaj_label.Name = "gelen_mesaj_label";
            this.gelen_mesaj_label.Size = new System.Drawing.Size(105, 25);
            this.gelen_mesaj_label.TabIndex = 10;
            this.gelen_mesaj_label.Text = "Gelen Mesaj";
            // 
            // tamam_button
            // 
            this.tamam_button.AutoSize = true;
            this.tamam_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tamam_button.Depth = 0;
            this.tamam_button.Icon = global::MaterialSkinExample.resimlerim.tick;
            this.tamam_button.Location = new System.Drawing.Point(380, 122);
            this.tamam_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.tamam_button.Name = "tamam_button";
            this.tamam_button.Primary = true;
            this.tamam_button.Size = new System.Drawing.Size(100, 36);
            this.tamam_button.TabIndex = 9;
            this.tamam_button.Text = "TAMAM";
            this.tamam_button.UseVisualStyleBackColor = true;
            this.tamam_button.Click += new System.EventHandler(this.tamam_button_Click);
            // 
            // uyari_pictureBox
            // 
            this.uyari_pictureBox.Image = global::MaterialSkinExample.resimlerim.tick;
            this.uyari_pictureBox.Location = new System.Drawing.Point(12, 75);
            this.uyari_pictureBox.Name = "uyari_pictureBox";
            this.uyari_pictureBox.Size = new System.Drawing.Size(70, 62);
            this.uyari_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uyari_pictureBox.TabIndex = 8;
            this.uyari_pictureBox.TabStop = false;
            // 
            // olumlu_olumsuz_MessegeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(492, 167);
            this.Controls.Add(this.gelen_mesaj_label);
            this.Controls.Add(this.tamam_button);
            this.Controls.Add(this.uyari_pictureBox);
            this.Name = "olumlu_olumsuz_MessegeBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UYARI";
            this.Load += new System.EventHandler(this.olumlu_olumsuzMessegeBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uyari_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gelen_mesaj_label;
        private MaterialSkin.Controls.MaterialRaisedButton tamam_button;
        private System.Windows.Forms.PictureBox uyari_pictureBox;
    }
}