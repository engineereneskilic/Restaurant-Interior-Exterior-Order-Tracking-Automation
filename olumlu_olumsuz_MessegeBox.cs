using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialSkinExample
{
    public partial class olumlu_olumsuz_MessegeBox : MaterialForm
    {
        public olumlu_olumsuz_MessegeBox()
        {
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);
        }

        public string gelen_mesaj;
        public bool olumlumu;

        private void olumlu_olumsuzMessegeBox_Load(object sender, EventArgs e)
        {
            gelen_mesaj_label.Text = gelen_mesaj;

            if (olumlumu)
            {
                gelen_mesaj_label.ForeColor = Color.FromArgb(0, 192, 0);
                uyari_pictureBox.Image = resimlerim.tick;
            }
            else
            {
                gelen_mesaj_label.ForeColor = Color.FromArgb(229,40,38);
                uyari_pictureBox.Image = resimlerim.cancel;
            }
            
        }

        private void tamam_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
