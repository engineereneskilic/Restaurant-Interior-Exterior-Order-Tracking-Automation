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
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient; // sql kütüphanesini çağırıyoruz

namespace MaterialSkinExample
{
    public partial class menu_item_ekle : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public menu_item_ekle()
        {
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);

        }

        anasayfa anasayfa_formu = (anasayfa)Application.OpenForms["anasayfa"];
        ortak_degiskenler_classlar ortak_sinif = new ortak_degiskenler_classlar();

        private void menu_item_ekle_Load(object sender, EventArgs e)
        {
            string secilen_menugrubu = anasayfa_formu.menu_islemleri_secilen_menu_baslik_label.Text;

            

            this.Text = secilen_menugrubu;

            Bitmap kaynak = resimlerim.ResourceManager.GetObject(ortak_sinif.trtoeng(this.Text)) as Bitmap;
            gelen_menu_pictureBox.Image = kaynak;


            string temiz_secilen_menugrubu = ortak_sinif.cogulsuz(secilen_menugrubu);

            item_ismi_label.Text = temiz_secilen_menugrubu+" İsmi:";
            item_ismi_Textbox.Hint = temiz_secilen_menugrubu + " İsmi";
            item_fiyati_label.Text = temiz_secilen_menugrubu + " Fiyatı:";
            item_fiyat_Textbox.Hint = temiz_secilen_menugrubu + " Fiyatı";


        }

        

        private void menu_item_kaydet_button_Click(object sender, EventArgs e)
        {
            // Boş Kontrolü
            bool sorunvarmi = false;
            if (item_ismi_Textbox.Text == "") { sorunvarmi = true; ortak_sinif.olumlu_olumsuzMessageBox(false, item_ismi_Textbox.Hint + " boş bıraktınız !"); }
            else if (item_fiyat_Textbox.Text == "") { sorunvarmi = true; ortak_sinif.olumlu_olumsuzMessageBox(false, item_fiyat_Textbox.Hint + " boş bıraktınız !"); }

            ortak_degiskenler_classlar ortak_class = new ortak_degiskenler_classlar();
            if (!sorunvarmi) {
                switch (this.Text)
                {
                    case "Çorbalar":
                        using (var db = new Model.Contexts.corbalarDbContext())
                        {
                            Model.Entitiy.corba corba = Model.Entitiy.corba.getInstance();
                            corba.corbalar_isim = item_ismi_Textbox.Text.Trim(); ;
                            corba.corbalar_fiyat = float.Parse(item_fiyat_Textbox.Text.Trim());
                            db.corbalar.Add(corba);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true, "Çorba Başarıyla Eklendi..");
                        }
                        break;
                    case "Kebaplar":
                        using (var db = new Model.Contexts.kebaplarDbContext())
                        {
                            Model.Entitiy.kebap kebap = Model.Entitiy.kebap.getInstance();
                            kebap.kebap_isim = item_ismi_Textbox.Text.Trim();
                            kebap.kebap_fiyat = 5;
                            db.kebaplar.Add(kebap);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true, "Kebap Başarıyla Eklendi..");
                        }
                        break;
                    case "Anayemekler":
                        using (var db = new Model.Contexts.anayemeklerDbContext())
                        {
                            Model.Entitiy.anayemek anayemek = Model.Entitiy.anayemek.getInstance();
                            anayemek.anayemekler_isim = item_ismi_Textbox.Text.Trim();
                            anayemek.anayemekler_fiyat = float.Parse(item_fiyat_Textbox.Text.Trim());
                            db.anayemekler.Add(anayemek);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true, "Anayemek Başarıyla Eklendi..");
                        }
                        break;
                    case "Salatalar":
                        using (var db = new Model.Contexts.salatalarDbContext())
                        {
                            Model.Entitiy.salata salata = Model.Entitiy.salata.getInstance();
                            salata.salata_isim = item_ismi_Textbox.Text.Trim();
                            salata.salata_fiyat = float.Parse(item_fiyat_Textbox.Text.Trim());
                            db.salatalar.Add(salata);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true, "Salat Başarıyla Eklendi..");
                        }
                        break;
                    case "Tatlilar":
                        using (var db = new Model.Contexts.tatlilarDbContext())
                        {
                            Model.Entitiy.tatli tatli = Model.Entitiy.tatli.getInstance();
                            tatli.tatli_isim = item_ismi_Textbox.Text.Trim();
                            tatli.tatli_fiyat = float.Parse(item_fiyat_Textbox.Text.Trim());
                            db.tatlilar.Add(tatli);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true, "Tatlı Başarıyla Eklendi..");
                        }
                        break;
                    case "İçecekler":
                        using (var db = new Model.Contexts.iceceklerDbContext())
                        {
                            Model.Entitiy.icecek icecek = Model.Entitiy.icecek.getInstance();
                            icecek.icecek_isim = item_ismi_Textbox.Text.Trim();
                            icecek.icecek_fiyat = float.Parse(item_fiyat_Textbox.Text.Trim());
                            db.icecekler.Add(icecek);
                            db.SaveChanges();
                            ortak_class.olumlu_olumsuzMessageBox(true,"İçecek Başarıyla Eklendi..");
                        }
                        break;
                }

                item_ismi_Textbox.Text = "";
                item_fiyat_Textbox.Text = "";

            }
        }
    }
}
