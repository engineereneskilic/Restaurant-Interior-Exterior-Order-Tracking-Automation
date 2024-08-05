namespace MaterialSkinExample
{
    partial class yesno_Messagebox
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
            this.evet_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.uyari_pictureBox = new System.Windows.Forms.PictureBox();
            this.gelen_mesaj_label = new System.Windows.Forms.Label();
            this.hayir_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.kapat_button = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.uyari_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // evet_button
            // 
            this.evet_button.AutoSize = true;
            this.evet_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.evet_button.Depth = 0;
            this.evet_button.Icon = global::MaterialSkinExample.resimlerim.tick;
            this.evet_button.Location = new System.Drawing.Point(171, 174);
            this.evet_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.evet_button.Name = "evet_button";
            this.evet_button.Primary = true;
            this.evet_button.Size = new System.Drawing.Size(82, 36);
            this.evet_button.TabIndex = 6;
            this.evet_button.Text = "EVET";
            this.evet_button.UseVisualStyleBackColor = true;
            this.evet_button.Click += new System.EventHandler(this.evet_button_Click);
            // 
            // uyari_pictureBox
            // 
            this.uyari_pictureBox.Image = global::MaterialSkinExample.resimlerim.orange_question_icon;
            this.uyari_pictureBox.Location = new System.Drawing.Point(12, 73);
            this.uyari_pictureBox.Name = "uyari_pictureBox";
            this.uyari_pictureBox.Size = new System.Drawing.Size(139, 137);
            this.uyari_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uyari_pictureBox.TabIndex = 5;
            this.uyari_pictureBox.TabStop = false;
            // 
            // gelen_mesaj_label
            // 
            this.gelen_mesaj_label.AutoSize = true;
            this.gelen_mesaj_label.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gelen_mesaj_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.gelen_mesaj_label.Location = new System.Drawing.Point(157, 111);
            this.gelen_mesaj_label.Name = "gelen_mesaj_label";
            this.gelen_mesaj_label.Size = new System.Drawing.Size(116, 28);
            this.gelen_mesaj_label.TabIndex = 7;
            this.gelen_mesaj_label.Text = "Gelen Mesaj";
            // 
            // hayir_button
            // 
            this.hayir_button.AutoSize = true;
            this.hayir_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hayir_button.Depth = 0;
            this.hayir_button.Icon = global::MaterialSkinExample.resimlerim.cancel;
            this.hayir_button.Location = new System.Drawing.Point(259, 174);
            this.hayir_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.hayir_button.Name = "hayir_button";
            this.hayir_button.Primary = true;
            this.hayir_button.Size = new System.Drawing.Size(89, 36);
            this.hayir_button.TabIndex = 8;
            this.hayir_button.Text = "HAYIR";
            this.hayir_button.UseVisualStyleBackColor = true;
            this.hayir_button.Click += new System.EventHandler(this.hayir_button_Click);
            // 
            // kapat_button
            // 
            this.kapat_button.AutoSize = true;
            this.kapat_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kapat_button.Depth = 0;
            this.kapat_button.Icon = global::MaterialSkinExample.resimlerim.cancel;
            this.kapat_button.Location = new System.Drawing.Point(370, 174);
            this.kapat_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.kapat_button.Name = "kapat_button";
            this.kapat_button.Primary = true;
            this.kapat_button.Size = new System.Drawing.Size(93, 36);
            this.kapat_button.TabIndex = 9;
            this.kapat_button.Text = "KAPAT";
            this.kapat_button.UseVisualStyleBackColor = true;
            this.kapat_button.Click += new System.EventHandler(this.kapat_button_Click);
            // 
            // yesno_Messagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 222);
            this.Controls.Add(this.kapat_button);
            this.Controls.Add(this.hayir_button);
            this.Controls.Add(this.gelen_mesaj_label);
            this.Controls.Add(this.evet_button);
            this.Controls.Add(this.uyari_pictureBox);
            this.Name = "yesno_Messagebox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UYARI";
            this.Load += new System.EventHandler(this.yesno_Messagebox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uyari_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton evet_button;
        private System.Windows.Forms.PictureBox uyari_pictureBox;
        private System.Windows.Forms.Label gelen_mesaj_label;
        private MaterialSkin.Controls.MaterialRaisedButton hayir_button;
        private MaterialSkin.Controls.MaterialRaisedButton kapat_button;
    }
}