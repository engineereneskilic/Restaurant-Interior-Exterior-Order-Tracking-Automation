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
 

    public partial class yesno_Messagebox : MaterialForm
    {
      

        private MaterialSkinManager materialSkinManager;

        public yesno_Messagebox()
        { 
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);
        }

        public string gelen_mesaj;
        public string secilen_menugrubu;

        private void yesno_Messagebox_Load(object sender, EventArgs e)
        {

            gelen_mesaj_label.Text = gelen_mesaj;

            if (secilen_menugrubu != "") this.Text = secilen_menugrubu; else this.Text = "UYARI";
            ortak_degiskenler_classlar ortak_sinif = new ortak_degiskenler_classlar();

        }

        private void kapat_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




        private void evet_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void hayir_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
           this.Close();
        }
    }
}
