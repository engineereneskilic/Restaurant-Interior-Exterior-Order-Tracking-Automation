namespace MaterialSkinExample
{
    partial class giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(giris));
            this.kullanici_adi_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kullanici_adi_textbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.sifre_textbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.giris_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guvenlik_textbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.guvenlik_kodu_label = new System.Windows.Forms.Label();
            this.guvenlik_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kullanici_adi_label
            // 
            this.kullanici_adi_label.AutoSize = true;
            this.kullanici_adi_label.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici_adi_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.kullanici_adi_label.Location = new System.Drawing.Point(16, 367);
            this.kullanici_adi_label.Name = "kullanici_adi_label";
            this.kullanici_adi_label.Size = new System.Drawing.Size(110, 22);
            this.kullanici_adi_label.TabIndex = 3;
            this.kullanici_adi_label.Text = "Kullanıcı Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(70, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Şifre:";
            // 
            // kullanici_adi_textbox
            // 
            this.kullanici_adi_textbox.Depth = 0;
            this.kullanici_adi_textbox.Hint = "Kullanıcı Adı";
            this.kullanici_adi_textbox.Location = new System.Drawing.Point(132, 366);
            this.kullanici_adi_textbox.MaxLength = 32767;
            this.kullanici_adi_textbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.kullanici_adi_textbox.Name = "kullanici_adi_textbox";
            this.kullanici_adi_textbox.PasswordChar = '\0';
            this.kullanici_adi_textbox.SelectedText = "";
            this.kullanici_adi_textbox.SelectionLength = 0;
            this.kullanici_adi_textbox.SelectionStart = 0;
            this.kullanici_adi_textbox.Size = new System.Drawing.Size(190, 23);
            this.kullanici_adi_textbox.TabIndex = 1;
            this.kullanici_adi_textbox.TabStop = false;
            this.kullanici_adi_textbox.UseSystemPasswordChar = false;
            // 
            // sifre_textbox
            // 
            this.sifre_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sifre_textbox.Depth = 0;
            this.sifre_textbox.Hint = "Şifre";
            this.sifre_textbox.Location = new System.Drawing.Point(132, 398);
            this.sifre_textbox.MaxLength = 32767;
            this.sifre_textbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.sifre_textbox.Name = "sifre_textbox";
            this.sifre_textbox.PasswordChar = '*';
            this.sifre_textbox.SelectedText = "";
            this.sifre_textbox.SelectionLength = 0;
            this.sifre_textbox.SelectionStart = 0;
            this.sifre_textbox.Size = new System.Drawing.Size(190, 23);
            this.sifre_textbox.TabIndex = 2;
            this.sifre_textbox.TabStop = false;
            this.sifre_textbox.UseSystemPasswordChar = true;
            // 
            // giris_button
            // 
            this.giris_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.giris_button.AutoSize = true;
            this.giris_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.giris_button.Depth = 0;
            this.giris_button.ForeColor = System.Drawing.Color.DarkRed;
            this.giris_button.Icon = null;
            this.giris_button.Location = new System.Drawing.Point(269, 473);
            this.giris_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.giris_button.Name = "giris_button";
            this.giris_button.Primary = true;
            this.giris_button.Size = new System.Drawing.Size(55, 36);
            this.giris_button.TabIndex = 8;
            this.giris_button.Text = "Giriş";
            this.giris_button.UseVisualStyleBackColor = false;
            this.giris_button.Click += new System.EventHandler(this.giris_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaterialSkinExample.resimlerim.logo1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(52, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 302);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // guvenlik_textbox
            // 
            this.guvenlik_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guvenlik_textbox.Depth = 0;
            this.guvenlik_textbox.Hint = "";
            this.guvenlik_textbox.Location = new System.Drawing.Point(132, 435);
            this.guvenlik_textbox.MaxLength = 32767;
            this.guvenlik_textbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.guvenlik_textbox.Name = "guvenlik_textbox";
            this.guvenlik_textbox.PasswordChar = '\0';
            this.guvenlik_textbox.SelectedText = "";
            this.guvenlik_textbox.SelectionLength = 0;
            this.guvenlik_textbox.SelectionStart = 0;
            this.guvenlik_textbox.Size = new System.Drawing.Size(121, 23);
            this.guvenlik_textbox.TabIndex = 3;
            this.guvenlik_textbox.TabStop = false;
            this.guvenlik_textbox.UseSystemPasswordChar = false;
            // 
            // guvenlik_kodu_label
            // 
            this.guvenlik_kodu_label.AutoSize = true;
            this.guvenlik_kodu_label.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guvenlik_kodu_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.guvenlik_kodu_label.Location = new System.Drawing.Point(6, 436);
            this.guvenlik_kodu_label.Name = "guvenlik_kodu_label";
            this.guvenlik_kodu_label.Size = new System.Drawing.Size(120, 22);
            this.guvenlik_kodu_label.TabIndex = 10;
            this.guvenlik_kodu_label.Text = "Güvenlik Kodu:";
            // 
            // guvenlik_label
            // 
            this.guvenlik_label.AutoSize = true;
            this.guvenlik_label.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guvenlik_label.ForeColor = System.Drawing.Color.Black;
            this.guvenlik_label.Location = new System.Drawing.Point(254, 440);
            this.guvenlik_label.Name = "guvenlik_label";
            this.guvenlik_label.Size = new System.Drawing.Size(74, 22);
            this.guvenlik_label.TabIndex = 12;
            this.guvenlik_label.Text = "79643089";
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(367, 525);
            this.Controls.Add(this.guvenlik_label);
            this.Controls.Add(this.guvenlik_textbox);
            this.Controls.Add(this.guvenlik_kodu_label);
            this.Controls.Add(this.giris_button);
            this.Controls.Add(this.sifre_textbox);
            this.Controls.Add(this.kullanici_adi_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kullanici_adi_label);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.Name = "giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KILIÇ LOKANTASI SİPARİŞ TAKİP PROGRAMI";
            this.Load += new System.EventHandler(this.giris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label kullanici_adi_label;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField kullanici_adi_textbox;
        private MaterialSkin.Controls.MaterialSingleLineTextField sifre_textbox;
        private MaterialSkin.Controls.MaterialRaisedButton giris_button;
        private MaterialSkin.Controls.MaterialSingleLineTextField guvenlik_textbox;
        private System.Windows.Forms.Label guvenlik_kodu_label;
        private System.Windows.Forms.Label guvenlik_label;
    }
}