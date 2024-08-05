namespace MaterialSkinExample
{
    partial class odeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(odeme));
            this.odeme_baslik_label = new System.Windows.Forms.Label();
            this.odenecektutar_label = new System.Windows.Forms.Label();
            this.odenecek_toplam_tutar_label = new System.Windows.Forms.Label();
            this.nakit_materialRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.kredi_karti_materialRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.odemeyi_al_button = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dolar_pictureBox = new System.Windows.Forms.PictureBox();
            this.kredi_karti_pictureBox = new System.Windows.Forms.PictureBox();
            this.odenecekler_materialListView = new MaterialSkin.Controls.MaterialListView();
            this.adi_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.miktar_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.birimfiyat_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toplamfiyat_columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dolar_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kredi_karti_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // odeme_baslik_label
            // 
            this.odeme_baslik_label.AutoSize = true;
            this.odeme_baslik_label.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.odeme_baslik_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))));
            this.odeme_baslik_label.Location = new System.Drawing.Point(589, 73);
            this.odeme_baslik_label.Name = "odeme_baslik_label";
            this.odeme_baslik_label.Size = new System.Drawing.Size(197, 33);
            this.odeme_baslik_label.TabIndex = 41;
            this.odeme_baslik_label.Text = "ÖDEME ŞEKLİ";
            // 
            // odenecektutar_label
            // 
            this.odenecektutar_label.AutoSize = true;
            this.odenecektutar_label.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.odenecektutar_label.ForeColor = System.Drawing.Color.Black;
            this.odenecektutar_label.Location = new System.Drawing.Point(135, 318);
            this.odenecektutar_label.Name = "odenecektutar_label";
            this.odenecektutar_label.Size = new System.Drawing.Size(47, 22);
            this.odenecektutar_label.TabIndex = 47;
            this.odenecektutar_label.Text = "0 TL";
            // 
            // odenecek_toplam_tutar_label
            // 
            this.odenecek_toplam_tutar_label.AutoSize = true;
            this.odenecek_toplam_tutar_label.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.odenecek_toplam_tutar_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(41)))), ((int)(((byte)(39)))));
            this.odenecek_toplam_tutar_label.Location = new System.Drawing.Point(7, 318);
            this.odenecek_toplam_tutar_label.Name = "odenecek_toplam_tutar_label";
            this.odenecek_toplam_tutar_label.Size = new System.Drawing.Size(122, 22);
            this.odenecek_toplam_tutar_label.TabIndex = 46;
            this.odenecek_toplam_tutar_label.Text = "Toplam Tutar:";
            // 
            // nakit_materialRadioButton
            // 
            this.nakit_materialRadioButton.Depth = 0;
            this.nakit_materialRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.nakit_materialRadioButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.nakit_materialRadioButton.Location = new System.Drawing.Point(638, 126);
            this.nakit_materialRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.nakit_materialRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.nakit_materialRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.nakit_materialRadioButton.Name = "nakit_materialRadioButton";
            this.nakit_materialRadioButton.Ripple = true;
            this.nakit_materialRadioButton.Size = new System.Drawing.Size(158, 38);
            this.nakit_materialRadioButton.TabIndex = 48;
            this.nakit_materialRadioButton.Text = "Nakit";
            this.nakit_materialRadioButton.UseVisualStyleBackColor = true;
            this.nakit_materialRadioButton.CheckedChanged += new System.EventHandler(this.nakit_materialRadioButton_CheckedChanged);
            // 
            // kredi_karti_materialRadioButton
            // 
            this.kredi_karti_materialRadioButton.Depth = 0;
            this.kredi_karti_materialRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.kredi_karti_materialRadioButton.Location = new System.Drawing.Point(641, 185);
            this.kredi_karti_materialRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.kredi_karti_materialRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.kredi_karti_materialRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.kredi_karti_materialRadioButton.Name = "kredi_karti_materialRadioButton";
            this.kredi_karti_materialRadioButton.Ripple = true;
            this.kredi_karti_materialRadioButton.Size = new System.Drawing.Size(158, 30);
            this.kredi_karti_materialRadioButton.TabIndex = 49;
            this.kredi_karti_materialRadioButton.TabStop = true;
            this.kredi_karti_materialRadioButton.Text = "Kredi Kartı";
            this.kredi_karti_materialRadioButton.UseVisualStyleBackColor = true;
            this.kredi_karti_materialRadioButton.CheckedChanged += new System.EventHandler(this.kredi_karti_materialRadioButton_CheckedChanged);
            // 
            // odemeyi_al_button
            // 
            this.odemeyi_al_button.AutoSize = true;
            this.odemeyi_al_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.odemeyi_al_button.Depth = 0;
            this.odemeyi_al_button.Icon = global::MaterialSkinExample.resimlerim.notepad;
            this.odemeyi_al_button.Location = new System.Drawing.Point(627, 246);
            this.odemeyi_al_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.odemeyi_al_button.Name = "odemeyi_al_button";
            this.odemeyi_al_button.Primary = true;
            this.odemeyi_al_button.Size = new System.Drawing.Size(127, 36);
            this.odemeyi_al_button.TabIndex = 50;
            this.odemeyi_al_button.Text = "ÖDEMEYİ AL";
            this.odemeyi_al_button.UseVisualStyleBackColor = true;
            this.odemeyi_al_button.Click += new System.EventHandler(this.odemeyi_al_button_Click);
            // 
            // dolar_pictureBox
            // 
            this.dolar_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.dolar_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("dolar_pictureBox.Image")));
            this.dolar_pictureBox.Location = new System.Drawing.Point(593, 126);
            this.dolar_pictureBox.Name = "dolar_pictureBox";
            this.dolar_pictureBox.Size = new System.Drawing.Size(42, 38);
            this.dolar_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dolar_pictureBox.TabIndex = 51;
            this.dolar_pictureBox.TabStop = false;
            // 
            // kredi_karti_pictureBox
            // 
            this.kredi_karti_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.kredi_karti_pictureBox.Image = global::MaterialSkinExample.resimlerim.credit_card;
            this.kredi_karti_pictureBox.Location = new System.Drawing.Point(591, 182);
            this.kredi_karti_pictureBox.Name = "kredi_karti_pictureBox";
            this.kredi_karti_pictureBox.Size = new System.Drawing.Size(42, 38);
            this.kredi_karti_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.kredi_karti_pictureBox.TabIndex = 52;
            this.kredi_karti_pictureBox.TabStop = false;
            // 
            // odenecekler_materialListView
            // 
            this.odenecekler_materialListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.odenecekler_materialListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.adi_columnHeader,
            this.miktar_columnHeader,
            this.birimfiyat_columnHeader,
            this.toplamfiyat_columnHeader});
            this.odenecekler_materialListView.Depth = 0;
            this.odenecekler_materialListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.odenecekler_materialListView.FullRowSelect = true;
            this.odenecekler_materialListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.odenecekler_materialListView.Location = new System.Drawing.Point(11, 73);
            this.odenecekler_materialListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.odenecekler_materialListView.MouseState = MaterialSkin.MouseState.OUT;
            this.odenecekler_materialListView.Name = "odenecekler_materialListView";
            this.odenecekler_materialListView.OwnerDraw = true;
            this.odenecekler_materialListView.Size = new System.Drawing.Size(571, 223);
            this.odenecekler_materialListView.TabIndex = 53;
            this.odenecekler_materialListView.UseCompatibleStateImageBehavior = false;
            this.odenecekler_materialListView.View = System.Windows.Forms.View.Details;
            // 
            // adi_columnHeader
            // 
            this.adi_columnHeader.Text = "Adı";
            this.adi_columnHeader.Width = 166;
            // 
            // miktar_columnHeader
            // 
            this.miktar_columnHeader.Text = "Miktar";
            this.miktar_columnHeader.Width = 133;
            // 
            // birimfiyat_columnHeader
            // 
            this.birimfiyat_columnHeader.Text = "Birim Fiyat";
            this.birimfiyat_columnHeader.Width = 138;
            // 
            // toplamfiyat_columnHeader
            // 
            this.toplamfiyat_columnHeader.Text = "Toplam Fiyat";
            this.toplamfiyat_columnHeader.Width = 119;
            // 
            // odeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 351);
            this.Controls.Add(this.odenecekler_materialListView);
            this.Controls.Add(this.kredi_karti_pictureBox);
            this.Controls.Add(this.dolar_pictureBox);
            this.Controls.Add(this.odemeyi_al_button);
            this.Controls.Add(this.kredi_karti_materialRadioButton);
            this.Controls.Add(this.nakit_materialRadioButton);
            this.Controls.Add(this.odenecektutar_label);
            this.Controls.Add(this.odenecek_toplam_tutar_label);
            this.Controls.Add(this.odeme_baslik_label);
            this.Name = "odeme";
            this.Text = "Ödeme Sayfası";
            this.Load += new System.EventHandler(this.odeme_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dolar_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kredi_karti_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label odeme_baslik_label;
        public System.Windows.Forms.Label odenecektutar_label;
        private System.Windows.Forms.Label odenecek_toplam_tutar_label;
        private MaterialSkin.Controls.MaterialRadioButton nakit_materialRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton kredi_karti_materialRadioButton;
        private MaterialSkin.Controls.MaterialRaisedButton odemeyi_al_button;
        private System.Windows.Forms.PictureBox dolar_pictureBox;
        private System.Windows.Forms.PictureBox kredi_karti_pictureBox;
        public MaterialSkin.Controls.MaterialListView odenecekler_materialListView;
        private System.Windows.Forms.ColumnHeader adi_columnHeader;
        private System.Windows.Forms.ColumnHeader miktar_columnHeader;
        private System.Windows.Forms.ColumnHeader birimfiyat_columnHeader;
        private System.Windows.Forms.ColumnHeader toplamfiyat_columnHeader;
    }
}