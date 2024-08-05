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
    public partial class odeme :MaterialForm
    {
        public odeme()
        {
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);
        }
        ortak_degiskenler_classlar ortak_class = new ortak_degiskenler_classlar();
        private void odemeyi_al_button_Click(object sender, EventArgs e)
        {
            if (odeme_sekli != null)
            {
                fatura_olustur fatura_olustur_formu = new fatura_olustur();
                fatura_olustur_formu.ShowDialog();
            }
            else
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen bir ödeme şekli seçin !");
            }
        }

        private void odeme_Load_1(object sender, EventArgs e)
        {
          

            ortak_degiskenler_classlar ortak_formu = new ortak_degiskenler_classlar();

            anasayfa anasayfa_formu = (anasayfa)Application.OpenForms["anasayfa"];

            

            if (anasayfa_formu.anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {
                this.odenecektutar_label.Text = anasayfa_formu.ic_siparis_tutar_label.Text;

                for (int i = 0; i <= anasayfa_formu.ic_siparisler_materialListView.Items.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = anasayfa_formu.ic_siparisler_materialListView.Items[i].Text;
                    item.SubItems.Add(anasayfa_formu.ic_siparisler_materialListView.Items[i].SubItems[1].Text);
                    item.SubItems.Add(anasayfa_formu.ic_siparisler_materialListView.Items[i].SubItems[2].Text);
                    ortak_formu.Fiyat = Convert.ToString(anasayfa_formu.ic_siparisler_materialListView.Items[i].SubItems[3].Text); ;
                    item.SubItems.Add(ortak_formu.Fiyat.ToString());
                    odenecekler_materialListView.Items.Add(item);

                }
                

            }
            else if (anasayfa_formu.anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                this.odenecektutar_label.Text = anasayfa_formu.dis_siparis_tutar_label.Text;

                for (int i = 0; i <= anasayfa_formu.dis_siparisler_materialListView.Items.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = anasayfa_formu.dis_siparisler_materialListView.Items[i].Text;
                    item.SubItems.Add(anasayfa_formu.dis_siparisler_materialListView.Items[i].SubItems[1].Text);
                    item.SubItems.Add(anasayfa_formu.dis_siparisler_materialListView.Items[i].SubItems[2].Text);
                    ortak_formu.Fiyat = Convert.ToString(anasayfa_formu.dis_siparisler_materialListView.Items[i].SubItems[3].Text); ;
                    item.SubItems.Add(ortak_formu.Fiyat.ToString());
                    odenecekler_materialListView.Items.Add(item);

                }
               
            }
        }
        public string odeme_sekli;

        private void nakit_materialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            odeme_sekli = "Nakit";
        }

        private void kredi_karti_materialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            odeme_sekli = "Kredi Kartı";
        }
    }
}
