namespace MaterialSkinExample
{
    partial class menu_item_ekle
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
            this.gelen_menu_pictureBox = new System.Windows.Forms.PictureBox();
            this.item_ismi_label = new System.Windows.Forms.Label();
            this.item_fiyati_label = new System.Windows.Forms.Label();
            this.item_ismi_Textbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.item_fiyat_Textbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.menu_item_kaydet_button = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.gelen_menu_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gelen_menu_pictureBox
            // 
            this.gelen_menu_pictureBox.Location = new System.Drawing.Point(12, 78);
            this.gelen_menu_pictureBox.Name = "gelen_menu_pictureBox";
            this.gelen_menu_pictureBox.Size = new System.Drawing.Size(163, 150);
            this.gelen_menu_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gelen_menu_pictureBox.TabIndex = 0;
            this.gelen_menu_pictureBox.TabStop = false;
            // 
            // item_ismi_label
            // 
            this.item_ismi_label.AutoSize = true;
            this.item_ismi_label.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.item_ismi_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))));
            this.item_ismi_label.Location = new System.Drawing.Point(181, 104);
            this.item_ismi_label.Name = "item_ismi_label";
            this.item_ismi_label.Size = new System.Drawing.Size(94, 25);
            this.item_ismi_label.TabIndex = 75;
            this.item_ismi_label.Text = "item ismi:";
            // 
            // item_fiyati_label
            // 
            this.item_fiyati_label.AutoSize = true;
            this.item_fiyati_label.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.item_fiyati_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))));
            this.item_fiyati_label.Location = new System.Drawing.Point(181, 149);
            this.item_fiyati_label.Name = "item_fiyati_label";
            this.item_fiyati_label.Size = new System.Drawing.Size(101, 25);
            this.item_fiyati_label.TabIndex = 76;
            this.item_fiyati_label.Text = "item fiyati";
            // 
            // item_ismi_Textbox
            // 
            this.item_ismi_Textbox.Depth = 0;
            this.item_ismi_Textbox.Hint = "";
            this.item_ismi_Textbox.Location = new System.Drawing.Point(311, 104);
            this.item_ismi_Textbox.MaxLength = 32767;
            this.item_ismi_Textbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.item_ismi_Textbox.Name = "item_ismi_Textbox";
            this.item_ismi_Textbox.PasswordChar = '\0';
            this.item_ismi_Textbox.SelectedText = "";
            this.item_ismi_Textbox.SelectionLength = 0;
            this.item_ismi_Textbox.SelectionStart = 0;
            this.item_ismi_Textbox.Size = new System.Drawing.Size(167, 23);
            this.item_ismi_Textbox.TabIndex = 1;
            this.item_ismi_Textbox.TabStop = false;
            this.item_ismi_Textbox.UseSystemPasswordChar = false;
            // 
            // item_fiyat_Textbox
            // 
            this.item_fiyat_Textbox.Depth = 0;
            this.item_fiyat_Textbox.Hint = "";
            this.item_fiyat_Textbox.Location = new System.Drawing.Point(311, 151);
            this.item_fiyat_Textbox.MaxLength = 32767;
            this.item_fiyat_Textbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.item_fiyat_Textbox.Name = "item_fiyat_Textbox";
            this.item_fiyat_Textbox.PasswordChar = '\0';
            this.item_fiyat_Textbox.SelectedText = "";
            this.item_fiyat_Textbox.SelectionLength = 0;
            this.item_fiyat_Textbox.SelectionStart = 0;
            this.item_fiyat_Textbox.Size = new System.Drawing.Size(167, 23);
            this.item_fiyat_Textbox.TabIndex = 2;
            this.item_fiyat_Textbox.TabStop = false;
            this.item_fiyat_Textbox.UseSystemPasswordChar = false;
            // 
            // menu_item_kaydet_button
            // 
            this.menu_item_kaydet_button.AutoSize = true;
            this.menu_item_kaydet_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menu_item_kaydet_button.Depth = 0;
            this.menu_item_kaydet_button.Icon = global::MaterialSkinExample.resimlerim.save;
            this.menu_item_kaydet_button.Location = new System.Drawing.Point(378, 192);
            this.menu_item_kaydet_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.menu_item_kaydet_button.Name = "menu_item_kaydet_button";
            this.menu_item_kaydet_button.Primary = true;
            this.menu_item_kaydet_button.Size = new System.Drawing.Size(100, 36);
            this.menu_item_kaydet_button.TabIndex = 79;
            this.menu_item_kaydet_button.Text = "Kaydet";
            this.menu_item_kaydet_button.UseVisualStyleBackColor = true;
            this.menu_item_kaydet_button.Click += new System.EventHandler(this.menu_item_kaydet_button_Click);
            // 
            // menu_item_ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 249);
            this.Controls.Add(this.menu_item_kaydet_button);
            this.Controls.Add(this.item_fiyat_Textbox);
            this.Controls.Add(this.item_ismi_Textbox);
            this.Controls.Add(this.item_fiyati_label);
            this.Controls.Add(this.item_ismi_label);
            this.Controls.Add(this.gelen_menu_pictureBox);
            this.Name = "menu_item_ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "menu_item_ekle";
            this.Load += new System.EventHandler(this.menu_item_ekle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gelen_menu_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gelen_menu_pictureBox;
        private System.Windows.Forms.Label item_ismi_label;
        private System.Windows.Forms.Label item_fiyati_label;
        private MaterialSkin.Controls.MaterialSingleLineTextField item_ismi_Textbox;
        private MaterialSkin.Controls.MaterialSingleLineTextField item_fiyat_Textbox;
        private MaterialSkin.Controls.MaterialRaisedButton menu_item_kaydet_button;
    }
}