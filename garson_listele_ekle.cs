using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialSkinExample
{
    public partial class garson_listele_ekle : MaterialForm
    {
        public garson_listele_ekle()
        {
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);
        }
        ortak_degiskenler_classlar ortak_class = new ortak_degiskenler_classlar();
        private int gelen_garson_id;

        public int Gelen_garson_id
        {
            get
            {
                return gelen_garson_id;
            }

            set
            {
                gelen_garson_id = value + 1; // id eksik geliyor textbox anlık güncelleme silme işlemi yüzüden anasayfa gerçekleşen onu tekrar düzeltelim(kapsülleme)
            }
        }

        anasayfa anasayfa_formu = new anasayfa();

        Bitmap gelen_resim;
        private void garson_bilgileri_Load(object sender, EventArgs e)
        {
            if (Gelen_garson_id != 0)
            {
              
                //id 0 deilse id gelmiş yani var olan bir kayıt ile ilgili yapılcaklar
                yeni_garson_ekle_button.Visible = false; // yeni garson eklemicez var olanı güncelliycez..
                secilenGarsonListele();
            }
            else // id gelmemiştir yani -1 gelmiştir bu demektirki bu bir yeni kayıt isteği
            {
                

                                 

                secilen_garson_sil_Button.Visible = false; // sil buttonu gitsin
                secilen_garson_guncelleButton.Visible = false; // guncelle buttonu gitsin
                yeni_garson_ekle_button.Location = new Point(526, 282); // onun yerine garson ekle buttonu gelsin
            }
        }
       
        bool ok_basildi = false;
        private void upluad_button_Click(object sender, MouseEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Resim Seç";
            fd.Filter = "Resim Dosyası(.jpg) |*.jpg;";
            fd.RestoreDirectory = true; // son kalan kaynağa bak
            if (fd.ShowDialog() == DialogResult.OK)
            {
                ok_basildi = true;
                
                gelen_resim = new Bitmap(fd.OpenFile());

              
              secilen_garson_pictureBox.Image = gelen_resim;

            }

        }
        public int guncelleme_sayisi = -1;
        private void resimSave()
        {
            
            if(ok_basildi)
            {
                guncelleme_sayisi++;

                string resimyolu = ortak_class.projeYolu() + @"Resources\" + ortak_class.trtoeng(kullanici_adi_Textbox.Text);
                
                if (!File.Exists(resimyolu + ".jpg"))
                {
                    gelen_resim.Save(resimyolu+".jpg", ImageFormat.Jpeg);
                   
                }
                else
            
                if (!File.Exists(resimyolu+guncelleme_sayisi+".jpg"))
                {

                    gelen_resim.Save(resimyolu+guncelleme_sayisi+".jpg", ImageFormat.Jpeg);
                }
                else
                {
                    gelen_resim.Save(resimyolu + (guncelleme_sayisi+1) + ".jpg", ImageFormat.Jpeg);
                }
               

                // gelen_resim.Save(resimyolu, ImageFormat.Jpeg);

                /*
                ResXResourceWriter RwX = new ResXResourceWriter(ortak_class.projeYolu() + "kullanicilar.resx");
              

                RwX.AddResource(new ResXDataNode(ortak_class.trtoeng(kullanici_adi_Textbox.Text), gelen_resim) { Comment = kullanici_adi_Textbox.Text});
                RwX.Generate();
                RwX.Close();
                */

            }
        }
        

        private void secilenGarsonListele()
        {
            using (var db = new Model.Contexts.kullanicilarDbContext())
            {
                var garson = db.kullanicilar.Find(gelen_garson_id);
                this.Text = garson.kullanici_adi;
                secilen_garson_baslik_label.Text = garson.kullanici_adi;


                string resimyolu = ortak_class.projeYolu() + @"Resources\" + ortak_class.trtoeng(garson.kullanici_adi);

                for (int guncelleme_sayisi = 10; guncelleme_sayisi >= 0; guncelleme_sayisi--) // en son güncellenen resmi göster
                {
                    if (File.Exists(resimyolu + guncelleme_sayisi + ".jpg"))
                    {

                        secilen_garson_pictureBox.Image = Image.FromFile(resimyolu + guncelleme_sayisi + ".jpg");
                       
                        break; // en son eklenen rsim bulundu döngüden çık
                    }
                    else

                    if (File.Exists(resimyolu + ".jpg"))
                    {
                        secilen_garson_pictureBox.Image = Image.FromFile(resimyolu + ".jpg");
                    }
                }



                // Garson Temel Bilgileri
                kullanici_adi_Textbox.Text = garson.kullanici_adi;
                sifre_textbox.Text = garson.kullanici_sifre;
                isimsoyisim_Textbox.Text = garson.kullanici_adi;
                if (garson.kullanici_cinsiyet == "Erkek") erkek_RadioButton.Checked = true; else kadin_RadioButton.Checked = true;
                if (garson.kullanici_medeni_durum == "Evli") evli_RadioButton.Checked = true; else bekar_RadioButton.Checked = true;

                //Garson Kişisel Bilgileri
                telno_Textbox.Text = garson.kullanici_telno;
                adres_Textbox.Text = garson.kullanici_adres;
                tckimlikno_Textbox.Text = garson.kullanici_tckimlik;
                dogum_tarihi_Textbox.Text = garson.kullanici_dogum_tarihi;
                dogum_yeri_TextBox.Text = garson.kullanici_dogumyeri;
            }
        }


        private void secilen_garson_guncelleButton_Click(object sender, EventArgs e)
        {
            if (!garsonBigileriFormKontrolleri())
            {
                using (var db = new Model.Contexts.kullanicilarDbContext())
                {
                    var garson = db.kullanicilar.Find(gelen_garson_id);




                    // Garson Temel Bilgileri
                    garson.kullanici_adi = kullanici_adi_Textbox.Text;
                    garson.kullanici_sifre = sifre_textbox.Text;
                    garson.kullanici_adi = isimsoyisim_Textbox.Text;
                    garson.kullanici_cinsiyet = cinsiyet;
                    garson.kullanici_medeni_durum = medeni_durumu;

                    //Garson Kişisel Bilgileri
                    garson.kullanici_telno = telno_Textbox.Text;
                    garson.kullanici_adres = adres_Textbox.Text;
                    garson.kullanici_tckimlik = tckimlikno_Textbox.Text;
                    garson.kullanici_dogum_tarihi = dogum_tarihi_Textbox.Text;
                    garson.kullanici_dogumyeri = dogum_yeri_TextBox.Text;

                    db.SaveChanges();


                    ortak_class.olumlu_olumsuzMessageBox(true, "Garson Başarıyla Güncellendi..");


                }
                resimSave();
                secilenGarsonListele();

            }
        }

        private void yeni_garson_ekle_button_Click(object sender, EventArgs e)
        {
            if (!garsonBigileriFormKontrolleri())
            {

                using (var db = new Model.Contexts.kullanicilarDbContext())
                {
                    var aynisindan_varmi = (from k in db.kullanicilar
                                           where k.kullanici_adi == kullanici_adi_Textbox.Text
                                           select k).Count();
                    if (aynisindan_varmi == 0)
                    {
                        Model.Entitiy.kullanici garson = new Model.Entitiy.kullanici();
                        // Garson Temel Bilgileri
                        garson.kullanici_adi = kullanici_adi_Textbox.Text;
                        garson.kullanici_sifre = sifre_textbox.Text;
                        garson.kullanici_adi = isimsoyisim_Textbox.Text;
                        garson.kullanici_cinsiyet = cinsiyet;
                        garson.kullanici_medeni_durum = medeni_durumu;

                        //Garson Kişisel Bilgileri
                        garson.kullanici_telno = telno_Textbox.Text;
                        garson.kullanici_adres = adres_Textbox.Text;
                        garson.kullanici_tckimlik = tckimlikno_Textbox.Text;
                        garson.kullanici_dogum_tarihi = dogum_tarihi_Textbox.Text;
                        garson.kullanici_dogumyeri = dogum_yeri_TextBox.Text;

                        db.kullanicilar.Add(garson);
                        db.SaveChanges();

                        ortak_class.olumlu_olumsuzMessageBox(true, "Yeni Garson Başarıyla Kaydedildi..");
                        resimSave();
                    }
                    else
                    {
                        ortak_class.olumlu_olumsuzMessageBox(false,"Bu Garson Zaten Kayıtlı !");
                    }
                }
                
            }
        }
        private void secilen_garson_sil_Button_Click(object sender, EventArgs e)
        {
            using (var db = new Model.Contexts.kullanicilarDbContext())
            {
                
                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                yesno_MessageBoxum.gelen_mesaj = "Bu garson silinsin mi?";
                yesno_MessageBoxum.secilen_menugrubu = ""; // bu menu değil garson ve bu yüzden uyari mesajı gelsin

                DialogResult dr = new DialogResult();
                dr = yesno_MessageBoxum.ShowDialog();



                if (dr == DialogResult.Yes)
                {
                    db.kullanicilar.Remove(db.kullanicilar.Find(gelen_garson_id));
                    db.SaveChanges();
                    this.Hide();
                }

            }
           
        }
        string cinsiyet="";
        private void erkek_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Erkek";
            ;
        }

        private void kadin_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Kadın";
           
        }
        string medeni_durumu="";
        private void evli_materialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            medeni_durumu = "Evli";
           
        }

        private void bekar_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            medeni_durumu = "Bekar";
           
        }

        private void isimsoyisim_Textbox_TextChanged(object sender, EventArgs e)
        {
            secilen_garson_baslik_label.Text = isimsoyisim_Textbox.Text; // seçin garsonun başlık ismiyle yeni isim soyisime eşit
        }


        private bool garsonBigileriFormKontrolleri()
        {
            bool hata = false;

            //MaterialSingleLineTextField form kontrolü aşağıda verdiğim boş kontrolü maalesef çalışmıyor..
            /*
            foreach (Control tb in this.Controls)
            {
                {
                    if (tb is TextBox && tb.Text == String.Empty)
                    {

                        MessageBox.Show(Convert.ToString(((TextBox)tb).Name + " BOŞ BIRAKILMIŞ!!!"));


                    }
                }
            }
            */
            // Mecburen teker teker bakcaz
            if (kullanici_adi_Textbox.Text == string.Empty)
            {
               ortak_class.olumlu_olumsuzMessageBox(false,"Lütfen Kullanıcı Adı Alanını Boş Bırakmayınız !");
                hata = true;
            }
            if (sifre_textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Şifre Alanaını Boş Bırakmayınız !");
                hata = true;
            }
            if (isimsoyisim_Textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen İsim Soyisim Alanaını Boş Bırakmayınız !");
                hata = true;
            }
            
            if (erkek_RadioButton.Checked!= true && kadin_RadioButton.Checked!=true) // erkek ve kadından biri işaretli değilse
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Cinsiyet Seçiniz !");
                hata = true;
            }
            if (evli_RadioButton.Checked != true && bekar_RadioButton.Checked != true) // erkek ve kadından biri işaretli değilse
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Medeni Durumu Seçiniz !");
                hata = true;
            }
            if (telno_Textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Telefon Numarası Alanaını Boş Bırakmayınız !");
                hata = true;
            }else
            if (telno_Textbox.Text.Length != 10 ||  Convert.ToInt32(telno_Textbox.Text.Substring(0, 1)) != 5) // 10 haneli değilse veya 1.karakter 5 değilse
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Telefon Numarasını Başında 0 olmadan 10 haneli olarak yazınız !");
                hata = true;
            }else
            if (!ortak_class.IsNumeric(telno_Textbox.Text))
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Telefon Numarasını doğru formatta giriniz !");
                hata = true;
            }
            if (adres_Textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Adres Alanaını Boş Bırakmayınız !");
                hata = true;
            }
            if (tckimlikno_Textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Tc Kimlik Numarası Alanaını Boş Bırakmayınız !");
                hata = true;
            }else
            if (tckimlikno_Textbox.Text.Length != 11)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Tc Kimlik Numarasını 11 haneli olarak giriniz !");
                hata = true;
            }else
            if (!ortak_class.IsNumeric(tckimlikno_Textbox.Text))
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Tc Kimlik Numarasını doğru formatta giriniz !");
                hata = true;
            }
            if (dogum_tarihi_Textbox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Doğum Tarihi Alanaını Boş Bırakmayınız !");
                hata = true;
            }else
            if (dogum_tarihi_Textbox.Text.Length != 10)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Doğum Tarihini 10 haneli olarak giriniz !");
                hata = true;
            }else
            if (dogum_tarihi_Textbox.Text.IndexOf('.')!=2 && dogum_tarihi_Textbox.Text.IndexOf('.') != 5) // . işareti hiç yoksa veya istenilen yerlerde yoksa
            {
                MessageBox.Show(dogum_tarihi_Textbox.Text.IndexOf('.').ToString());
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Doğum Tarihini Gün.Ay.Yıl şeklinde aralarına nokta işareti koyarak giriniz !");
                hata = true;
            }
            if (dogum_yeri_TextBox.Text == string.Empty)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Doğum Yeri Alanaını Boş Bırakmayınız !");
                hata = true;
            }else
            if (dogum_yeri_TextBox.Text.IndexOf('/') == -1) // / işareti yoksa
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Doğum Yerini İl/İlçe şeklinde aralarına / işareti koyarak giriniz !");
                hata = true;
            }

            if(secilen_garson_pictureBox.Image == MaterialSkinExample.resimlerim.profile)
            {
                ortak_class.olumlu_olumsuzMessageBox(false, "Lütfen Garsonun Profil Resmini Seçiniz !");
                hata = true;
            }

            return hata;
            
        }
    }
}
