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
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient; // sql kütüphanesini çağırıyoruz
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Resources;
using System.IO;

namespace MaterialSkinExample
{

    public partial class anasayfa : MaterialForm
    {
        public anasayfa()
        {
            InitializeComponent();
            // TEMA İLE İLGİLİ ÖZELLİKLER
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red100, Accent.Red100, TextShade.WHITE);


        }


        public Label menü_uyarisi_label = new Label();

        // masalar
        public PictureBox[] masa_pictureboxs = new PictureBox[16];
        public Label[] masa_labels = new Label[16];

        // menü tab grubu
        public Label menu_baslik_label = new Label();
        public MaterialRaisedButton siparis_tamamla_button = new MaterialRaisedButton();
        // menü grubu
        public PictureBox menusol_picturebox = new PictureBox();
        public ListView menu_listview = new ListView();
        PictureBox menusag_picturebox = new PictureBox();



        // telefonlar
        public PictureBox[] telefon_pictureboxs = new PictureBox[16];
        public Label[] telefon_labels = new Label[16];


        private void anasayfa_Load(object sender, EventArgs e)
        {

            this.Text = ortak_degiskenler_classlar.program_ismi;
            ic_siparis_kullanici_label.Text = ortak_degiskenler_classlar.Kullanici_ismi; // ortak classımıza gönderdiğimiz kullanıcı adını labelimiza atıyoruz.
            dis_siparis_kullanici_label.Text = ortak_degiskenler_classlar.Kullanici_ismi; // ortak classımıza gönderdiğimiz kullanıcı adını labelimiza atıyoruz.
            tarih_label.Text = DateTime.Now.ToShortDateString();// tarih labelimiza bugünkü tarihi kısa format şeklinde atıoyruz.

            MenuUyariYazisi(true, "Lütfen İlk Önce Masa Seçiniz..."); // sayfa yüklendiğinde daha hiç bir masa seçilmediği için menü tarafına uyarı yazimizi yazıyoruz masa seçmeden menüler görünmesin diye

            // sayfa yüklenirken bir kere rowlar belirlensin lokanta menümüzün
            menu_listview.Columns.Add("İsim", 150);
            menu_listview.Columns.Add("Fiyat", 150);
            // kurye comboboxs
            using (var db = new Model.Contexts.kullanicilarDbContext())
            {
                foreach (var eleman in db.kullanicilar)
                {

                    secilen_telefon_kurye_combobox.Items.Add(eleman.kullanici_adi);

                }
            }

            masalariYerlestir();
            telefonlariYerlestir();


            // MENU GÜNCELLEME TABI İŞLEMLERİ 1.kısım
            menu_islemleri_secilen_menu_baslik_label.Text = "Çorbalar";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, -1, null, null);
            //GARSON GÜNCELLEME TABI İŞLEMLERİ 2.kısım
            GarsonTumunuListele();

            /* REZERVASYON İŞEMLERİ */
            rezervasyonListele();

        }

        private void siparis_listeleri_yenile(string gelen_anliksiparis_masatelno)
        {
            //if (gelen_anliksiparis_masatelno.IndexOf("Masa") > 0) MessageBox.Show("bu bir masa"); else MessageBox.Show("bu telefon");
            //MessageBox.Show(gelen_anliksiparis_masatelno.ToString());

            if (gelen_anliksiparis_masatelno.IndexOf("Masa") != -1) // gelen sipariş masadan gelmişse
            {
                ic_siparisler_materialListView.Items.Clear(); // eski itemler silinir
                //MessageBox.Show("Yenilenen masa: "+gelen_anliksiparis_masatelno);
                using (var db = new Model.Contexts.anliksiparisler_masalarDbContext())
                {
                    var secilen_masa_listesi = from k in db.anlik_siparisler_masalar
                                               where k.anliksiparis_masa_adi == gelen_anliksiparis_masatelno
                                               select k;
                    foreach (var eleman in secilen_masa_listesi)
                    {

                        var eklenmismi = ic_siparisler_materialListView.FindItemWithText(eleman.anliksiparis_adi);
                        if (eklenmismi == null)
                        {
                            ListViewItem item = new ListViewItem(eleman.anliksiparis_adi); // bir listwiev itemi oluşturuyoruz ismini giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_miktar.ToString());// itemin miktarını giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_fiyat);// itemin fiyatını giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_toplam_fiyat);// itemin miktarını giriyoruz
                            ic_siparisler_materialListView.Items.Add(item);// ve menü listemize ekliyoruzs
                        }
                    }
                    ToplamTutarHesapla();
                }
            } else
            {
                dis_siparisler_materialListView.Items.Clear();
                secilen_telefon_telno_textBox.Text = "";
                secilen_telefon_adres_textBox.Text = "";

                using (var db = new Model.Contexts.anliksiparisler_telefonlarDbContext())
                {
                    var secilen_telefon_listesi = from k in db.anlik_siparisler_telefonlar
                                                  where k.anliksiparis_telefon_adi == gelen_anliksiparis_masatelno
                                                  select k;
                    foreach (var eleman in secilen_telefon_listesi)
                    {

                        var eklenmismi = dis_siparisler_materialListView.FindItemWithText(eleman.anliksiparis_adi);
                        if (eklenmismi == null)
                        {
                            // telefon sipariş bilgileri güncelle
                            secilen_telefon_telno_textBox.Text = eleman.anliksiparis_telefon_no.ToString();
                          
                                secilen_telefon_kurye_combobox.Text = eleman.anliksiparis_kurye;
                          
                            secilen_telefon_adres_textBox.Text = eleman.anliksiparis_adres;

                            ListViewItem item = new ListViewItem(eleman.anliksiparis_adi); // bir listwiev itemi oluşturuyoruz ismini giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_miktar.ToString());// itemin miktarını giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_fiyat);// itemin fiyatını giriyoruz
                            item.SubItems.Add(eleman.anliksiparis_toplam_fiyat);// itemin miktarını giriyoruz
                            dis_siparisler_materialListView.Items.Add(item);// ve menü listemize ekliyoruzs

                            ToplamTutarHesapla();
                        }
                    }

                }
            }
        }

        private void anamenu_tablarClick(object sender, TabControlCancelEventArgs e) // tüm menü tablarına tıklandığında bu methot tetikleniyor
        {
            if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                MenuUyariYazisi(true, "Lütfen İlk Önce Masa Seçiniz..."); // dış siparişlere basıldığında daha hiç bir telefon seçilmediği için menü tarafına uyarı yazimizi yazıyoruz telefon seçmeden menüler görünmesin diye

            }
        }
        private void masalariYerlestir()
        {
            // Masalarımızı yerleştiriyoruz lokantamıza
            Model.Entitiy.masa masam = new Model.Entitiy.masa();
            masam.defaultVeriler();// lokanta otomasyonunu ilk açtığımız bilgisayarda masalar eklendisn

            using (var db = new Model.Contexts.masalarDbContext())
            {


                string masa_resmi = "";// masa resmi ilk başta boş oluyor
                int resim_x = -81, resim_y = 6;// masa resmi başlangıc koordinatları
                int masa_sayaci = 0; // masa sayacımızı belirliyoruz.


                foreach (var eleman in db.masalar)
                {
                    masa_sayaci++;
                    if (eleman.masa_durum) masa_resmi = "dolumasa"; else masa_resmi = "bosmasa"; // masa_resmi adını burda belirliyoruz veritabanından gelen masadurumu true ise dolumasa false ise boş masa resmi atansın

                    //MASA RESMİ OLUŞTUR
                    PictureBox masa_picturebox = new PictureBox(); // bir masa pictureboxı
                    masa_pictureboxs[masa_sayaci] = masa_picturebox; // programın başında tanımladığım masa picturebox grubuma eleman ekliyorum yani picturebox
                    resim_x += 87;// masa resmi x koordinatında sağa doğru belirli aralıklarla ekliyorum
                    if (eleman.masa_no % 4 == 0) resim_y += 70; // yine aynı şekilde aşağı doğru ekliyorum.
                    Point picturebox_konum = new Point(resim_x, resim_y); // eklemelerimi point yani nokta konumunu belirliyorum
                    masa_pictureboxs[masa_sayaci].Location = picturebox_konum;// bu nokta konumunun bulunmasını istediğim yere atıyorum
                    masa_pictureboxs[masa_sayaci].Cursor = Cursors.Hand;// fare imlecimi el şekline dönüştürüyorum üzerine geldiğinde olsun die
                    masa_pictureboxs[masa_sayaci].Name = "Masa " + eleman.masa_no + "_picturebox_" + masa_resmi; // Masa namemimi belirliyorum belirlerken daha sonradan rahat ulaşayım ve aynı zamanda veri de taşımış oluyorum masa resmi dolu mu boşmu
                                                                                                                 // masa_pictureboxs[masa_sayaci].ImageLocation = @"C:\Users\Enes\Desktop\lokanta_siparis_takip_programi\lokanta_siparis_takip_programi\img\" + masa_resmi + ".png";
                    masa_pictureboxs[masa_sayaci].Width = 78; // masa resmimin genişliğini belirliyorum
                    masa_pictureboxs[masa_sayaci].Height = 61;// masa resmimin yüksekliğini belirliyorum
                    masa_pictureboxs[masa_sayaci].SizeMode = PictureBoxSizeMode.Zoom;// masa resmimin sizemodunu zoom yapıyorum ki büyük olmasın picturebox kutusundan dışarı çıkmasın
                                                                                     // picturebox1.BackColor = Color.Red;
                    masa_pictureboxs[masa_sayaci].MouseClick += Masalar_Click; // tüm masalarıma tıklancağı zaman tetiklencek olayı belirliyorum
                    masalar_tableLayoutPanel.Controls.Add(masa_pictureboxs[masa_sayaci]);// masam artık hazır tablelayoutpanelime ekliyorum




                    // Şimdi de görüntülenen resmimizin üstüne numarasını basıyoruz
                    Bitmap goruntulenen_resim = resimlerim.ResourceManager.GetObject(masa_resmi) as Bitmap;// bir bitmap tanımlıyoruz masa ile aynı görsele sahip aracı aslında bu ve masa resmine göre resimi seçiyoruz boş dolu şeklinde
                    Graphics masa_yaz = Graphics.FromImage(goruntulenen_resim); // bir graphics oluşturuyoruz tanımladığımız bpm üzerine ve sonra üzerine başlıyoruz çizmeye
                    Font Font = new Font("Arial", 110);// çizçeğimiz firçanın fontunu belirliyoruz

                    masa_yaz.DrawString(masa_sayaci.ToString(), Font, new SolidBrush(Color.Red), -10, -10);// masa_sayacımızı belirlediğimiz fontta renkde ve konumda çiziyoruz
                    masa_pictureboxs[masa_sayaci].Image = goruntulenen_resim;// bu çizdiğimiz bitmapı tekrar image geri atıyoruz ve alın size çizilmiş resim..


                }
            }
        }
        public void telefonlariYerlestir()
        {
            // Telefonlarımızı yerleştiriyoruz lokantamıza
            Model.Entitiy.telefon telefonum = new Model.Entitiy.telefon();
            telefonum.defaultVeriler();// lokanta otomasyonunu ilk açtığımız bilgisayarda telefonlar eklendisn

            using (var db = new Model.Contexts.telefonlarDbContext())
            {


                string telefon_resmi = "";// telefon resmi ilk başta boş oluyor
                int resim_x = -81, resim_y = 6;// telefon resmi başlangıc koordinatları
                int telefon_sayaci = 0; // telefon sayacımızı belirliyoruz.


                foreach (var eleman in db.telefonlar)
                {
                    telefon_sayaci++;
                    if (eleman.telefon_durum) telefon_resmi = "dolutelefon"; else telefon_resmi = "bostelefon"; // telefon_resmi adını burda belirliyoruz veritabanından gelen telefondurumu true ise dolutelefon false ise boş telefon resmi atansın

                    //TELEFON RESMİ OLUŞTUR
                    PictureBox telefon_picturebox = new PictureBox(); // bir telefon pictureboxı
                    telefon_pictureboxs[telefon_sayaci] = telefon_picturebox; // programın başında tanımladığım telefon picturebox grubuma eleman ekliyorum yani picturebox
                    resim_x += 87;// telefon resmi x koordinatında sağa doğru belirli aralıklarla ekliyorum
                    if (eleman.telefon_no % 4 == 0) resim_y += 70; // yine aynı şekilde aşağı doğru ekliyorum.
                    Point picturebox_konum = new Point(resim_x, resim_y); // eklemelerimi point yani nokta konumunu belirliyorum
                    telefon_pictureboxs[telefon_sayaci].Location = picturebox_konum;// bu nokta konumunun bulunmasını istediğim yere atıyorum
                    telefon_pictureboxs[telefon_sayaci].Cursor = Cursors.Hand;// fare imlecimi el şekline dönüştürüyorum üzerine geldiğinde olsun die
                    telefon_pictureboxs[telefon_sayaci].Name = "Telefon " + eleman.telefon_no + "_picturebox_" + telefon_resmi; // telefon namemimi belirliyorum belirlerken daha sonradan rahat ulaşayım ve aynı zamanda veri de taşımış oluyorum masa resmi dolu mu boşmu
                                                                                                                                // telefon_pictureboxs[telefon_sayaci].ImageLocation = @"C:\Users\Enes\Desktop\lokanta_siparis_takip_programi\lokanta_siparis_takip_programi\img\" + masa_resmi + ".png";
                    telefon_pictureboxs[telefon_sayaci].Width = 78; // telefon resmimin genişliğini belirliyorum
                    telefon_pictureboxs[telefon_sayaci].Height = 61;// telefon resmimin yüksekliğini belirliyorum
                    telefon_pictureboxs[telefon_sayaci].SizeMode = PictureBoxSizeMode.Zoom;// telefon resmimin sizemodunu zoom yapıyorum ki büyük olmasın picturebox kutusundan dışarı çıkmasın
                    telefon_pictureboxs[telefon_sayaci].MouseClick += Telefonlar_Click; // tüm telefonlarıma tıklancağı zaman tetiklencek olayı belirliyorum
                    telefon_tableLayoutPanel.Controls.Add(telefon_pictureboxs[telefon_sayaci]);// telefon artık hazır tablelayoutpanelime ekliyorum




                    // Şimdi de görüntülenen resmimizin üstüne numarasını basıyoruz
                    Bitmap goruntulenen_resim = resimlerim.ResourceManager.GetObject(telefon_resmi) as Bitmap;// bir bitmap tanımlıyoruz telefon ile aynı görsele sahip aracı aslında bu ve telefon resmine göre resimi seçiyoruz boş dolu şeklinde
                    Graphics telefon_yaz = Graphics.FromImage(goruntulenen_resim); // bir graphics oluşturuyoruz tanımladığımız bpm üzerine ve sonra üzerine başlıyoruz çizmeye
                    Font Font = new Font("Arial", 62);// çizçeğimiz firçanın fontunu belirliyoruz

                    telefon_yaz.DrawString(telefon_sayaci.ToString(), Font, new SolidBrush(Color.Red), -16, -10);// telefon_sayacımızı belirlediğimiz fontta renkde ve konumda çiziyoruz
                    telefon_pictureboxs[telefon_sayaci].Image = goruntulenen_resim;// bu çizdiğimiz bitmapı tekrar image geri atıyoruz ve alın size çizilmiş resim..


                }
            }
        }
        private void Masalar_Click(object sender, MouseEventArgs e) // Tüm masalar için ortak event
        {



            PictureBox secilen_masa = (PictureBox)sender; // seçilen pictureboxumuzu alıyoruz

            string[] secilen_masa_name = secilen_masa.Name.Split('_'); // yukarda pictureboxın namesini oluştururken içie veride yazdım ki yani dolu mu boş masa mı ve bide masa nosunu yazmıştım temize çekiyorum bunları 

            Bitmap secilen_masa_resmi = resimlerim.ResourceManager.GetObject(secilen_masa_name[2]) as Bitmap;
            secilen_masa_pictureBox.Image = secilen_masa_resmi;
            secilen_masa_pictureBox.Name = "secilen_" + secilen_masa_name[2]; // secilen_dolu/bos


            secilen_masa_label.Visible = true;
            if (secilen_masa_name[2] == "bosmasa") secilen_masa_label.BackColor = Color.SaddleBrown; else secilen_masa_label.BackColor = Color.Green; // bos_masa ise seçilen masanın labelini yani masa nosunu arkaplan rengini kahve tonu yapıyorum deilse yeşil yapıyorum.
            secilen_masa_label.Name = "secilen_" + secilen_masa_name[0];// yine aldığım veriyle name atıyorum masa nosunu..
            secilen_masa_label.Text = secilen_masa_name[0];// masa nosu

            siparis_listeleri_yenile(secilen_masa_label.Text); // secilen masanın sipariş listesi yenilensin

            if (secilen_masa_name[2] == "bosmasa") // secilen masa boşsa menü gözükmesin uyarı yazisi gözüksün
            {
                menu_olustur(false);
                MenuUyariYazisi(true, "Lütfen Önce Masa Açınız...");
            }
            else {// dolu ise uyarı yazisi gözükmesin ve boş gitsin
                MenuUyariYazisi(false, "");
                menu_olustur(true);// menü gözüksün
            }
            // comboxbaxa eşitle
            // masalar_comboBox.inde = "masa2";// yeni değeri atıyoruz
        }
        private void Telefonlar_Click(object sender, MouseEventArgs e) // Tüm telefonlar için ortak event
        {


            PictureBox secilen_telefon = (PictureBox)sender; // seçilen pictureboxumuzu alıyoruz

            string[] secilen_telefon_name = secilen_telefon.Name.Split('_'); // yukarda pictureboxın namesini oluştururken içie veride yazdım ki yani dolu mu boş telefon mı ve bide telefon nosunu yazmıştım temize çekiyorum bunları 

            Bitmap secilen_telefon_resmi = resimlerim.ResourceManager.GetObject(secilen_telefon_name[2]) as Bitmap;


            secilen_telefon_pictureBox.Image = secilen_telefon_resmi;
            secilen_telefon_pictureBox.Name = "secilen_" + secilen_telefon_name[2]; // secilen_dolu/bos


            secilen_telefon_label.Visible = true;
            if (secilen_telefon_name[2] == "bostelefon") secilen_telefon_label.BackColor = Color.SaddleBrown; else secilen_telefon_label.BackColor = Color.Green; // bos_telefon ise seçilen telefonun labelini yani masa nosunu arkaplan rengini kahve tonu yapıyorum deilse yeşil yapıyorum.
            secilen_telefon_label.Name = "secilen_" + secilen_telefon_name[0];// yine aldığım veriyle name atıyorum telefon nosunu..
            secilen_telefon_label.Text = secilen_telefon_name[0];// telefon nosu

            siparis_listeleri_yenile(secilen_telefon_label.Text);// secilen masa boşsa menü gözükmesin uyarı yazisi gözüksün

            if (secilen_telefon_name[2] == "bostelefon") // secilen telefon boşsa menü gözükmesin uyarı yazisi gözüksün
            {
                menu_olustur(false);
                MenuUyariYazisi(true, "Lütfen Önce Telefon Açınız...");
                SiparisBilgileriEnabled(false); // sipariş bilgileri gurubu pasif olsun içine bişey yazılmasın
            }
            else
            {// dolu ise uyarı yazisi gözükmesin ve boş gitsin
                MenuUyariYazisi(false, "");
                menu_olustur(true);// menü gözüksün
                SiparisBilgileriEnabled(true); // sipariş bilgileri gurubu aktif olsun içine bişey yazılsın
            }
        }
        int birkere = 0; // Menü uyari yazısı bir kere oluşsun ve değer atamaları çokça kez değiştirilebilsin..
        public void MenuUyariYazisi(bool gorunurluk, string yazi)
        {
            birkere++;
            if (birkere == 1)
            {
                Point menü_uyarisi_label_konum = new Point(245, 77); // hangi noktada oluşsun
                menü_uyarisi_label.Location = menü_uyarisi_label_konum; // bu noktayı locatiyona atama
                menü_uyarisi_label.Name = "menu_uyari_yazisi_label"; // name atama
                menü_uyarisi_label.Font = new Font("Monotype Corsiva", 20, FontStyle.Italic); // font yazı tipi büyükliği ve stilini belirledim
                menü_uyarisi_label.ForeColor = Color.Gray; // arkaplan rengi
                menü_uyarisi_label.AutoSize = true;// otomatik boyutlandırma aktif
                menü_uyarisi_label.Text = yazi;// gelen uyari metnini texte atadım
                menü_uyarisi_label.Visible = gorunurluk;// gelen görünürlük izninye göre visibilite ayarı
            }
            else
            {
                menü_uyarisi_label.Text = yazi; // yazi değiştiği için bir kere içinde olamamlı
                menü_uyarisi_label.Visible = gorunurluk;// aynı şekilde bu öle

            }

            /*
            if (!gorunurluk) // menu gurubunu görünmez yapalım...
            {
                siparis_tamamla_button.Visible = false;
                menu_baslik_label.Visible = false;
                menusol_picturebox.Visible = false;
                menu_listview.Visible = false;
                menusag_picturebox.Visible = false;
            }
            */
            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {
                ic_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menü_uyarisi_label); // masa uyarısı menüler aktif tabının içinde olmalı
            } else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                dis_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menü_uyarisi_label);
            }
        }
        public void menu_olustur(bool aktif_pasif) // menü oluşturduğum metod
        {
            if (aktif_pasif) // menü  gözüksünmü yoksa gözükmesinmi 
            {
                // Menü başlığı oluştur
                Point menu_baslik_label_konum = new Point(250, 4);
                menu_baslik_label.Location = menu_baslik_label_konum;

                menu_baslik_label.Font = new Font("Monotype Corsiva", 20, FontStyle.Italic);

                menu_baslik_label.ForeColor = Color.FromArgb(230, 41, 39);//(R, G, B)


                string[] secilen_menu_tab_ismi = new string[2];// splitlerken 2 ye bölmüş oluyoruz
                if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
                {
                    secilen_menu_tab_ismi = ic_siparis_menuler_materialTabControl.SelectedTab.Name.Split('_'); // aktif menünün tab ismini alıyoruz örneiğin içeçekler
                    menu_baslik_label.Text = ic_siparis_menuler_materialTabControl.SelectedTab.Text;
                }
                else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
                {

                    secilen_menu_tab_ismi = dis_siparis_menuler_materialTabControl.SelectedTab.Name.Split('_');
                    menu_baslik_label.Text = dis_siparis_menuler_materialTabControl.SelectedTab.Text;
                }

                /* ***** Not: aynı şeyleri bir daha yazmiyim yine kodla form elemanı oluşturuyorum */
                menu_baslik_label.Name = secilen_menu_tab_ismi[0] + "_label";
                menu_baslik_label.AutoSize = true;
                menu_baslik_label.Visible = true;



                // 1.RESİM OLUŞTUR
                Point menusol_picturebox_konum = new Point(21, 6);
                menusol_picturebox.Location = menusol_picturebox_konum;

                menusol_picturebox.Name = secilen_menu_tab_ismi[0].ToString() + "_picturebox1";
                Bitmap menusol_picturebox_kaynak = resimlerim.ResourceManager.GetObject(secilen_menu_tab_ismi[0]) as Bitmap;
                menusol_picturebox.Image = menusol_picturebox_kaynak;
                menusol_picturebox.Width = 214;
                menusol_picturebox.Height = 195;
                menusol_picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                // picturebox1.BackColor = Color.Red;
                menusol_picturebox.Visible = true;




                // MessageBox.Show(picturebox1.ImageLocation);

                // LİSTE OLUŞTUR
                Point listview_konum = new Point(256, 45);
                menu_listview.Location = listview_konum;
                menu_listview.CheckBoxes = true; // listwievin çoklu checkbox özelliğini aktif hale getiriyoruz..
                menu_listview.MultiSelect = true;// ..ve çoklu seçime izin veriyoruz
                menu_listview.Name = secilen_menu_tab_ismi[0] + "_listview"; // tabi ismini verirken tablo ismine yani menü ismine dikkat ediyoruz örneğin çorbalar içeçekler
                menu_listview.View = View.Details; // lisview görünüm şeklini değiştiriyoruz
                menu_listview.Width = 327;
                menu_listview.Height = 150;
                menu_listview.Font = new Font("Monotype Corsiva", 12, FontStyle.Italic);
                menu_listview.MouseClick += menu_listview_Click_MouseClick; // mouse ile tıkladığımızda listwiev elemanlarından birine tetiklencek event
                menu_listview.ItemChecked += menu_listview__ItemChecked; // 
                menu_listview.Items.Clear(); // eski tabdan kalan verileri siliyoruz
                menu_listview.Visible = true;


                // iç sipariş aktif ise içe eklesin deilde dış sipariş aktif ise ona eklesin hem masa siparişleri hemde telefon siparişleri ayni menüden sipariş verlceği için sorun yok
                if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
                {
                    ic_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menu_baslik_label);
                    ic_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menusol_picturebox);
                    ic_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menusag_picturebox);
                    ic_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menu_listview); // menülerden akif olana ekliyoruz..

                } else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
                {
                    dis_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menu_baslik_label);
                    dis_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menusol_picturebox);
                    dis_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menusag_picturebox);
                    dis_siparis_menuler_materialTabControl.SelectedTab.Controls.Add(menu_listview);
                }



                switch (secilen_menu_tab_ismi[0])
                {
                    case "anayemekler":

                        Model.Entitiy.anayemek anayemek = Model.Entitiy.anayemek.getInstance();
                        anayemek.defaultVeriler();
                        using (var db = new Model.Contexts.anayemeklerDbContext())
                        {
                            foreach (var eleman in db.anayemekler)
                            {
                                menuTablosunaEkle(eleman.anayemekler_isim, eleman.anayemekler_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                    case "corbalar":
                        Model.Entitiy.corba corba = Model.Entitiy.corba.getInstance();
                        corba.defaultVeriler();
                        using (var db = new Model.Contexts.corbalarDbContext())
                        {
                            foreach (var eleman in db.corbalar)
                            {
                                menuTablosunaEkle(eleman.corbalar_isim, eleman.corbalar_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                    case "icecekler":
                        Model.Entitiy.icecek icecek = Model.Entitiy.icecek.getInstance();
                        icecek.defaultVeriler();
                        using (var db = new Model.Contexts.iceceklerDbContext())
                        {
                            foreach (var eleman in db.icecekler)
                            {
                                menuTablosunaEkle(eleman.icecek_isim, eleman.icecek_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                    case "kebaplar":
                        Model.Entitiy.kebap kebap = Model.Entitiy.kebap.getInstance();
                        kebap.defaultVeriler();
                        using (var db = new Model.Contexts.kebaplarDbContext())
                        {
                            foreach (var eleman in db.kebaplar)
                            {
                                menuTablosunaEkle(eleman.kebap_isim, eleman.kebap_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                    case "salatalar":
                        Model.Entitiy.salata salata = Model.Entitiy.salata.getInstance();
                        salata.defaultVeriler();
                        using (var db = new Model.Contexts.salatalarDbContext())
                        {
                            foreach (var eleman in db.salatalar)
                            {
                                menuTablosunaEkle(eleman.salata_isim, eleman.salata_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                    case "tatlilar":
                        Model.Entitiy.tatli tatli = Model.Entitiy.tatli.getInstance();
                        tatli.defaultVeriler();
                        using (var db = new Model.Contexts.tatlilarDbContext())
                        {
                            foreach (var eleman in db.tatlilar)
                            {
                                menuTablosunaEkle(eleman.tatli_isim, eleman.tatli_fiyat); // menü tablosuna verilerimizi giriyoruz
                            }
                        }
                        break;
                }

            } else
            {
                // bütün menü elemanlarını görünmez yapıyoruz..
                menusol_picturebox.Visible = false;
                menu_listview.Visible = false;
                menu_baslik_label.Visible = false;
                siparis_tamamla_button.Visible = false;
                menusag_picturebox.Visible = false;

                // bütün grubu görünmez yap
            }

        }

        private void menuTablosunaEkle(string menu_isim, float menu_fiyat)
        {
            ortak_degiskenler_classlar ortak_degiskenler = new ortak_degiskenler_classlar();
            ortak_degiskenler.Fiyat = Convert.ToString(menu_fiyat); // ortak classımızdan fiyatı kapsüllü bir şekilde çağırıyoruz kapsüllü olmasının sebebi fiyatı TL cinsinden göstermesi


            ListViewItem item = new ListViewItem(menu_isim); // bir listwiev itemi oluşturuyoruz ismini giriyoruz
            item.SubItems.Add(ortak_degiskenler.Fiyat.ToString());// itemin fiyatını giriyoruz
            menu_listview.Items.Add(item);// ve menü listemize ekliyoruz
        }


        private void menu_listview_Click_MouseClick(object sender, MouseEventArgs e) // menu listwiev elemanlarına tıklandığı zaman tetiklencek metot
        {
            if (e.Button == MouseButtons.Right) // Ters tıklanırsa
            {

                if (menu_listview.FocusedItem.Bounds.Contains(e.Location) == true && menu_listview.FocusedItem.Checked == true) // focuslanan item ile moouse lokasyonu çakışıyormu ve item işartlimi
                {
                    miktar_materialContextMenuStrip.Show(Cursor.Position);// çakışıyorsa tam bu çakışan noktada contextmenustripti yani normak ters tıkta açıldığı gibi menü gelsin

                    //MessageBox.Show("odaklandı");
                }
            }
        }
        private void ic_siparisler_materialListView_Click_MouseClick(object sender, MouseEventArgs e) // menu listwiev elemanlarına tıklandığı zaman tetiklencek metot
        {

            if (e.Button == MouseButtons.Right) // Ters tıklanırsa
            {
                if (ic_siparisler_materialListView.FocusedItem.Bounds.Contains(e.Location) == true) // focuslanan item ile moouse lokasyonu çakışıyormu ve item işartlimi
                {
                    miktar_materialContextMenuStrip.Show(Cursor.Position);// çakışıyorsa tam bu çakışan noktada contextmenustripti yani normak ters tıkta açıldığı gibi menü gelsin

                    //MessageBox.Show("odaklandı");
                }
            }
        }
        private void dis_siparisler_materialListView_Click_MouseClick(object sender, MouseEventArgs e) // menu listwiev elemanlarına tıklandığı zaman tetiklencek metot
        {

            if (e.Button == MouseButtons.Right) // Ters tıklanırsa
            {
                if (dis_siparisler_materialListView.FocusedItem.Bounds.Contains(e.Location) == true) // focuslanan item ile moouse lokasyonu çakışıyormu ve item işartlimi
                {
                    miktar_materialContextMenuStrip.Show(Cursor.Position);// çakışıyorsa tam bu çakışan noktada contextmenustripti yani normak ters tıkta açıldığı gibi menü gelsin

                    //MessageBox.Show("odaklandı");
                }
            }
        }
        private void menu_listview__ItemChecked(object sender, ItemCheckedEventArgs e) // listview itemi işaretlendiği zaman çalişcak metot
        {
            // Burda gelen item listwievden işaretlenen değer örnek: çorbalardan işkembe checked yaptı

            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {
                ListViewItem item = e.Item as ListViewItem;  // seçilen itemi tekrar item olarak atıyoruzki özelliklerini rahat kullanabilelelim
                if (item != null) // item boş deilse
                {


                    if (item.Checked) // item seçiliyse
                    {
                        // MessageBox.Show(item.SubItems[1].Text);

                        ListViewItem menu_secilen = new ListViewItem(); // gelen itemimizi daha rahat atamak için bir listview item daha tanımlıyoruz.
                        menu_secilen.Text = item.Text; // itemin textini atıyoruz
                        menu_secilen.SubItems.Add(1.ToString());// bu kısma ise ilk gelcek değer 1 dir çünkü en az 1 adet sipariş gelir
                        menu_secilen.SubItems.Add(item.SubItems[1].Text);//burasıda fiyat kısmı gelen itemimizin fiyatını alıyoruz ve menu secilen iteme atıyoruz
                        menu_secilen.SubItems.Add(Convert.ToString(Convert.ToInt32(menu_secilen.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(item.SubItems[1].Text))));//adet x birim_Fiyat=toplam fiyat atamasınıda yapıyoruz

                        //itemimiz hazır peki iç siparişe mi yoksa dış siparişe mi eklencek bunun kararını aktif olan taba göre bakıyoruz yani anamenümüz diş sipariş mi iç siparişmi


                        // şöle bir sıkıntı var listwievler çok olduğu için öncekilerşe karışıyor ve ayni yemeği bir daha ekliyor mesela kebab ikini tabda olduğu için 2 kere ekliyor bazen 3 kere aynı yemeği eklemesin diye aynısı varsa ekleme if kullandım
                        var eklenmismi = ic_siparisler_materialListView.FindItemWithText(menu_secilen.Text);

                        if (eklenmismi == null) // aynısı yoksa
                        {

                            ic_siparisler_materialListView.Items.Add(menu_secilen); // ekle

                            using (var db = new Model.Contexts.anliksiparisler_masalarDbContext())
                            {
                                // burda single pattern kullamamın amacı sürekli item işaretlendiği için sürekli işaretlendiği için yeniden new class çağırmassın program aksamasın
                                Model.Entitiy.anliksiparis_masa anliksiparis = Model.Entitiy.anliksiparis_masa.getInstance();
                                anliksiparis.anliksiparis_masa_adi = secilen_masa_label.Text;
                                anliksiparis.anliksiparis_adi = item.Text.ToString();
                                anliksiparis.anliksiparis_miktar = 1;
                                anliksiparis.anliksiparis_fiyat = item.SubItems[1].Text.ToString();
                                anliksiparis.anliksiparis_toplam_fiyat = Convert.ToString(Convert.ToInt32(menu_secilen.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(item.SubItems[1].Text)));
                                db.anlik_siparisler_masalar.Add(anliksiparis);
                                db.SaveChanges();


                            }

                            ToplamTutarHesapla(); // şimdiye kadar bu masanın sipariş listesi toplamı getiriyor ve toplam hesaba yazıyors


                        }

                    }

                    else
                    {

                        siparis_listeleri_yenile(secilen_masa_label.Text);
                        ToplamTutarHesapla();// şimdiye kadar bu masanın sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
                    }
                }
            } else
            if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                ListViewItem item = e.Item as ListViewItem;  // seçilen itemi tekrar item olarak atıyoruzki özelliklerini rahat kullanabilelelim
                if (item != null) // item boş deilse
                {


                    if (item.Checked) // item seçiliyse
                    {

                        // MessageBox.Show(item.SubItems[1].Text);

                        ListViewItem menu_secilen = new ListViewItem(); // gelen itemimizi daha rahat atamak için bir listview item daha tanımlıyoruz.
                        menu_secilen.Text = item.Text; // itemin textini atıyoruz
                        menu_secilen.SubItems.Add(1.ToString());// bu kısma ise ilk gelcek değer 1 dir çünkü en az 1 adet sipariş gelir
                        menu_secilen.SubItems.Add(item.SubItems[1].Text);//burasıda fiyat kısmı gelen itemimizin fiyatını alıyoruz ve menu secilen iteme atıyoruz
                        menu_secilen.SubItems.Add(Convert.ToString(Convert.ToInt32(menu_secilen.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(item.SubItems[1].Text))));//adet x birim_Fiyat=toplam fiyat atamasınıda yapıyoruz

                        //itemimiz hazır peki iç siparişe mi yoksa dış siparişe mi eklencek bunun kararını aktif olan taba göre bakıyoruz yani anamenümüz diş sipariş mi iç siparişmi


                        // şöle bir sıkıntı var listwievler çok olduğu için öncekilerşe karışıyor ve ayni yemeği bir daha ekliyor mesela kebab ikini tabda olduğu için 2 kere ekliyor bazen 3 kere aynı yemeği eklemesin diye aynısı varsa ekleme if kullandım
                        var eklenmismi = dis_siparisler_materialListView.FindItemWithText(menu_secilen.Text);

                        if (eklenmismi == null) // aynısı yoksa
                        {
                            dis_siparisler_materialListView.Items.Add(menu_secilen); // ekle
                            ToplamTutarHesapla(); // şimdiye kadar bu masanın sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
                            using (var db = new Model.Contexts.anliksiparisler_telefonlarDbContext())
                            {
                                // burda single pattern kullamamın amacı sürekli item işaretlendiği için sürekli işaretlendiği için yeniden new class çağırmassın program aksamasın
                                Model.Entitiy.anliksiparis_telefon anliksiparis = Model.Entitiy.anliksiparis_telefon.getInstance();
                                anliksiparis.anliksiparis_telefon_adi = secilen_telefon_label.Text;
                                anliksiparis.anliksiparis_adi = item.Text.ToString();
                                anliksiparis.anliksiparis_miktar = 1;
                                anliksiparis.anliksiparis_fiyat = item.SubItems[1].Text.ToString();
                                anliksiparis.anliksiparis_toplam_fiyat = Convert.ToString(Convert.ToInt32(menu_secilen.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(item.SubItems[1].Text)));
                                anliksiparis.anliksiparis_telefon_no = Convert.ToInt64(secilen_telefon_telno_textBox.Text);
                                anliksiparis.anliksiparis_kurye = secilen_telefon_kurye_combobox.Text;
                                anliksiparis.anliksiparis_adres = secilen_telefon_adres_textBox.Text.ToString();
                                db.anlik_siparisler_telefonlar.Add(anliksiparis);
                                db.SaveChanges();


                            }

                        }




                    } // else unchecked yapılabilirdi güzel olurdu fakat unchecked sanıldığı gibi çalışmıyor

                    else
                    {

                        // eğer unchecked olursa o ürün listeden çıkarılsın
                        var bulunan_item = dis_siparisler_materialListView.FindItemWithText(item.Text); // listeden unchecked olan ürünü bul idsini öğrenmek için
                        //dis_siparisler_materialListView.Items[bulunan_item.Index].Remove();// bulunan id ile bu ürünü siş
                        /*
                        //veritabanından da sil
                        using (var db = new Model.Contexts.anliksiparisl_denemesi_DbContext())
                        {
                            db.anlik_siparisler_denemesi.Remove(db.anlik_siparisler_denemesi.Find(bulunan_item.Index));
                            db.SaveChanges();
                        }
                        */
                        ToplamTutarHesapla();// şimdiye kadar bu masanın sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
                    }
                }
            }

        }



        private void menu_tum_tablarClick(object sender, TabControlCancelEventArgs e) // tüm menü tablarına tıklandığında bu methot tetikleniyor
        {
            if (secilen_masa_pictureBox.Name.ToString().IndexOf("logo") >= 0 || secilen_telefon_pictureBox.Name.ToString().IndexOf("logo") >= 0) // secilen masa_pictureboxun logo varsa hiç masa seçilmemiştir
            {
                MenuUyariYazisi(true, "Lütfen İlk Önce Masa Seçiniz..."); // menü uyarı yazımız çalışsın
            }
            else if (secilen_masa_pictureBox.Name.ToString().IndexOf("bosmasa") >= 0 || secilen_telefon_pictureBox.Name.ToString().IndexOf("bostelefon") >= 0) // ecilen masa_pictureboxun bosmasa varsa maça açmamışlardır açsınsınlar
            {
                menu_olustur(false);
                MenuUyariYazisi(true, "Lütfen İlk Önce Masa Açınız..."); // menü uyarı yazımız çalışsın
            }
            else if (secilen_masa_pictureBox.Name.ToString().IndexOf("dolumasa") >= 0 || secilen_telefon_pictureBox.Name.ToString().IndexOf("dolutelefon") >= 0)// masa doluysa artık menü oluşturulabilir yani siparişler alınabilir
            {
                menu_olustur(true);
                MenuUyariYazisi(false, ""); // menü uyarı yazımız çalışsın
            }



        }


        private void masaIslemi(bool masa) // seçilen masaımızı kapatıp açacağımız yer buttonlara göre karar vermesi için bool masa oluşturuyoruz
        {
            string masa_resmi;
            if (masa) { masa_resmi = "dolumasa"; } else { masa_resmi = "bosmasa"; } // masa açılsın buttonuna basıldı ise ona göre değerlerimizi atıyoruz
            string masa_no;
            if (secilen_masa_label.Text.Length == 6) masa_no = secilen_masa_label.Text.Substring(5, 1); else masa_no = secilen_masa_label.Text.Substring(5, 2); // seçilen masaının nosu eğer iki basamaklıysa ona göre ata eğer tek basamaklıysa ona göre atas


            using (var db = new Model.Contexts.masalarDbContext())
            {
                var degiscek_masa = db.masalar.Find(Convert.ToInt32(masa_no)); // direk primary key araması olduğu için linqya gerek yok
                if (masa) degiscek_masa.masa_durum = true; else degiscek_masa.masa_durum = false;// masa resmine göre dolu masa ise masa durumumuz true açık olsun değilse kapalı olsun

                db.SaveChanges();
            }



            // değişen masamızın değerlerini yeniden atıyoruz
            Bitmap degisen_masa_kaynak = resimlerim.ResourceManager.GetObject(masa_resmi) as Bitmap;

            Graphics masa_yaz = Graphics.FromImage(degisen_masa_kaynak);// resmin üstüne yazı yazmak için graphics oluşturuyoruz
            Font Font = new Font("Arial", 100); // fırçamıza font belirliyoruz

            masa_yaz.DrawString(masa_no, Font, new SolidBrush(Color.Red), 10, 20); // masanosunu yazcağımız fırçanın özelliklerini atıyoruz
            masa_pictureboxs[Convert.ToInt32(masa_no)].Image = degisen_masa_kaynak;// çizilen masanousunu geri pictureboxa atıyoruz

            Bitmap secilen_masaresmi = resimlerim.ResourceManager.GetObject(masa_resmi) as Bitmap;// buna bağlı olarak secilen masanın yani programın solunda büyük resminde pictureboxını değiştiroyurz
            secilen_masa_pictureBox.Image = secilen_masaresmi;
            masa_pictureboxs[Convert.ToInt32(masa_no)].Name = "Masa " + masa_no + "_picturebox_" + masa_resmi;// masa pictureboxları gurubundan seçilen masanona ayit pictureboxun name ataması
            secilen_masa_label.Visible = true;
            if (!masa) secilen_masa_label.BackColor = Color.SaddleBrown; else secilen_masa_label.BackColor = Color.Green; // masa kapalı olarak buttona basıldıysa seçilen masını labelida kahve olcak çünkü arkadaki resimde kahve uyumlu olsundiye değilse resim yeşildir labelde yeşil olsun
            secilen_masa_label.Name = "secilen_" + masa_no;// seçilen masa namesini atadığımız masanousu göre değiitiriyoruz
            secilen_masa_label.Text = "Masa " + masa_no; // bu masa nosunu texte atıyoruz

        }
        private void telefonIslemi(bool telefon) // seçilen telefon kapatıp açacağımız yer buttonlara göre karar vermesi için bool telefon oluşturuyoruz
        {
            string telefon_resmi;
            if (telefon) { telefon_resmi = "dolutelefon"; } else { telefon_resmi = "bostelefon"; } // telefon açılsın buttonuna basıldı ise ona göre değerlerimizi atıyoruz
            string telefon_no;
            if (secilen_telefon_label.Text.Length == 9) telefon_no = secilen_telefon_label.Text.Substring(8, 1); else telefon_no = secilen_telefon_label.Text.Substring(8, 2); // seçilen telefonun nosu eğer iki basamaklıysa ona göre ata eğer tek basamaklıysa ona göre atas


            using (var db = new Model.Contexts.telefonlarDbContext())
            {
                var degiscek_telefon = db.telefonlar.Find(Convert.ToInt32(telefon_no)); // direk primary key araması olduğu için linqya gerek yok
                if (telefon) degiscek_telefon.telefon_durum = true; else degiscek_telefon.telefon_durum = false;// telefon resmine göre dolu telefon ise telefon durumumuz true açık olsun değilse kapalı olsun

                db.SaveChanges();
            }



            // değişen telefonumuzun değerlerini yeniden atıyoruz
            Bitmap degisen_telefon_kaynak = resimlerim.ResourceManager.GetObject(telefon_resmi) as Bitmap;

            Graphics telefon_yaz = Graphics.FromImage(degisen_telefon_kaynak);// resmin üstüne yazı yazmak için graphics oluşturuyoruz
            Font Font = new Font("Arial", 62); // fırçamıza font belirliyoruz

            telefon_yaz.DrawString(telefon_no, Font, new SolidBrush(Color.Red), -16, 10); // telefon nosunu yazcağımız fırçanın özelliklerini atıyoruz
            telefon_pictureboxs[Convert.ToInt32(telefon_no)].Image = degisen_telefon_kaynak;// çizilen telefon nousunu geri pictureboxa atıyoruz

            Bitmap secilen_telefon_resmi = resimlerim.ResourceManager.GetObject(telefon_resmi) as Bitmap;// buna bağlı olarak secilen telefonun yani programın solunda büyük resminde pictureboxını değiştiroyurz
            secilen_telefon_pictureBox.Image = secilen_telefon_resmi;
            telefon_pictureboxs[Convert.ToInt32(telefon_no)].Name = "Telefon " + telefon_no + "_picturebox_" + telefon_resmi;// telefon pictureboxları gurubundan seçilen telefonnona ayit pictureboxun name ataması
            secilen_telefon_label.Visible = true;
            if (!telefon) secilen_telefon_label.BackColor = Color.SaddleBrown; else secilen_telefon_label.BackColor = Color.Green; // telefon kapalı olarak buttona basıldıysa seçilen masını labelida kahve olcak çünkü arkadaki resimde kahve uyumlu olsundiye değilse resim yeşildir labelde yeşil olsun
            secilen_telefon_label.Name = "secilen_" + telefon_no;// seçilen telefon namesini atadığımız telefon nousu göre değiitiriyoruz
            secilen_telefon_label.Text = "Telefon " + telefon_no; // bu telefon nosunu texte atıyoruz

        }
        private void masa_ac_button_Click(object sender, EventArgs e)
        {
            menu_olustur(true); // menü oluşturulsun
            masaIslemi(true);// masa işlemi açık olsun
            MenuUyariYazisi(false, "");// uyari yazısı olmasın
            secilen_masa_pictureBox.Name = "secilen_dolumasa"; // secilen_dolu/bos

        }

        private void masa_kapat_button_Click(object sender, EventArgs e)
        {
            masaIslemi(false); // masa işlemi kapalı olsun
            menu_olustur(false);// menü gösterilmesin
            MenuUyariYazisi(true, "Lütfen Önce Masa Açınız..."); // masa kapalı olcağı için açınız uyarısı gözüksün
            ic_siparisler_materialListView.Items.Clear();// masa kapatıldığına göre siparişler listesi boşaltılsın
            menuVeritabanindanSil(null);
            siparis_listeleri_yenile(secilen_masa_label.Text);
            ic_siparis_tutar_label.Text = "0 TL";// varsayılan tutar gözüksün
            secilen_masa_pictureBox.Name = "secilen_bosmasa"; // secilen_dolu/bos
        }


        private void arttir_ToolStripMenuItem_Click(object sender, EventArgs e) // listwiev üstünde çalışan terst tık butttonlarından arttir isimli butona basılınca çalışan metot
        {

            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {

                if (ic_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    var arttirilcak_siparis = ic_siparisler_materialListView.FindItemWithText(ic_siparisler_materialListView.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    arttirilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) + 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                    arttirilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(arttirilcak_siparis.SubItems[2].Text)));
                    arttirAzaltIslemi(arttirilcak_siparis.SubItems[1].Text, ic_siparisler_materialListView.FocusedItem.Text);

                }
                else if (menu_listview.FocusedItem != null)
                {
                    var arttirilcak_siparis = ic_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    arttirilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) + 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                    arttirilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(arttirilcak_siparis.SubItems[2].Text)));
                    arttirAzaltIslemi(arttirilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem.Text);
                }

                siparis_listeleri_yenile(secilen_masa_label.Text);

            }
            else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                if (dis_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    var arttirilcak_siparis = dis_siparisler_materialListView.FindItemWithText(dis_siparisler_materialListView.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    arttirilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) + 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                    arttirilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(arttirilcak_siparis.SubItems[2].Text)));
                    arttirAzaltIslemi(arttirilcak_siparis.SubItems[1].Text, dis_siparisler_materialListView.FocusedItem.Text);

                }
                else
                {
                    var arttirilcak_siparis = dis_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    arttirilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) + 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                    arttirilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(arttirilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(arttirilcak_siparis.SubItems[2].Text)));
                    arttirAzaltIslemi(arttirilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem.Text);
                }
                siparis_listeleri_yenile(secilen_telefon_label.Text);
            }

            ToplamTutarHesapla();// şimdiye kadar bu masanın/telefonun sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
        }

        private void arttirAzaltIslemi(string arttirilcak_azaltilcak_miktar, string arttirilcak_azaltilcak_item)
        {
            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {
                using (var db = new Model.Contexts.anliksiparisler_masalarDbContext())
                {
                    var arttilcak_siparis_guncelle_sorgusu = from k in db.anlik_siparisler_masalar
                                                             where k.anliksiparis_masa_adi == secilen_masa_label.Text && k.anliksiparis_adi == arttirilcak_azaltilcak_item
                                                             select k;
                    foreach (var eleman in arttilcak_siparis_guncelle_sorgusu)
                    {
                        eleman.anliksiparis_miktar = Convert.ToInt32(arttirilcak_azaltilcak_miktar);
                    }

                    db.SaveChanges();
                }
            } else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                using (var db = new Model.Contexts.anliksiparisler_telefonlarDbContext())
                {
                    var arttilcak_siparis_guncelle_sorgusu = from k in db.anlik_siparisler_telefonlar
                                                             where k.anliksiparis_telefon_adi == secilen_telefon_label.Text && k.anliksiparis_adi == arttirilcak_azaltilcak_item
                                                             select k;
                    foreach (var eleman in arttilcak_siparis_guncelle_sorgusu)
                    {
                        eleman.anliksiparis_miktar = Convert.ToInt32(arttirilcak_azaltilcak_miktar);
                    }

                    db.SaveChanges();
                }
            }
        }

        private void azalt_ToolStripMenuItem_Click(object sender, EventArgs e)// listwiev üstünde çalışan terst tık butttonlarından azalt isimli butona basılınca çalışan metot
        {

            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {

                if (ic_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    var azaltilcak_siparis = ic_siparisler_materialListView.FindItemWithText(ic_siparisler_materialListView.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    if (Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) > 1)// 1 den az sipariş olmaz !
                    {
                        azaltilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) - 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                        azaltilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(azaltilcak_siparis.SubItems[2].Text)));
                        arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, ic_siparisler_materialListView.FocusedItem.Text);
                    }


                }
                else
                {
                    var azaltilcak_siparis = ic_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    if (Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) > 1)// 1 den az sipariş olmaz !
                    {
                        azaltilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) - 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                        azaltilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(azaltilcak_siparis.SubItems[2].Text)));
                        arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem.Text);
                    }
                }


                //arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem);
                siparis_listeleri_yenile(secilen_masa_label.Text);
            }
            else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                if (dis_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    var azaltilcak_siparis = dis_siparisler_materialListView.FindItemWithText(dis_siparisler_materialListView.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    if (Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) > 1)// 1 den az sipariş olmaz !
                    {
                        azaltilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) - 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                        azaltilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(azaltilcak_siparis.SubItems[2].Text)));
                        arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, dis_siparisler_materialListView.FocusedItem.Text);
                    }


                }
                else
                {
                    var azaltilcak_siparis = dis_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text); // arttirilcak siparişi sipariş listesinden bulmam lazım menü üstünde focuslanan itemin textini siparişlerde ara ve getir
                    if (Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) > 1)// 1 den az sipariş olmaz !
                    {
                        azaltilcak_siparis.SubItems[1].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) - 1); // bulunan siparişin değerini 1 arttir yani bir adet daha müşteri istiyor
                        azaltilcak_siparis.SubItems[3].Text = Convert.ToString(Convert.ToInt32(azaltilcak_siparis.SubItems[1].Text) * Convert.ToDouble(TemizFiyat(azaltilcak_siparis.SubItems[2].Text)));
                        arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem.Text);
                    }
                }
                //arttirAzaltIslemi(azaltilcak_siparis.SubItems[1].Text, menu_listview.FocusedItem);
                siparis_listeleri_yenile(secilen_telefon_label.Text);
            }
            ToplamTutarHesapla();// şimdiye kadar bu masanın/telefonun sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
        }

        private void menuVeritabanindanSil(string gelen_anliksparis_adi)
        {

            //veritabanından da sil
            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage") // gelen masaysa
            {
                using (var db = new Model.Contexts.anliksiparisler_masalarDbContext())
                {
                    if (gelen_anliksparis_adi != null)
                    {

                        var secilen_itemi_veritabanina_sor = from k in db.anlik_siparisler_masalar
                                                             where k.anliksiparis_masa_adi == secilen_masa_label.Text && k.anliksiparis_adi == gelen_anliksparis_adi
                                                             select k;

                        foreach (var eleman in secilen_itemi_veritabanina_sor)
                        {
                            db.anlik_siparisler_masalar.Remove(db.anlik_siparisler_masalar.Find(eleman.anliksiparis_id)); // idden ancak silebiliyoruz linq sorgusu yapıp idsini aldım
                        }
                    }
                    else
                    {
                        // secilen masa ağit tüm kayıtlar gitsin
                        var secilen_itemi_veritabanina_sor = from k in db.anlik_siparisler_masalar
                                                             where k.anliksiparis_masa_adi == secilen_masa_label.Text
                                                             select k;

                        foreach (var eleman in secilen_itemi_veritabanina_sor)
                        {
                            db.anlik_siparisler_masalar.Remove(db.anlik_siparisler_masalar.Find(eleman.anliksiparis_id)); // idden ancak silebiliyoruz linq sorgusu yapıp idsini aldım
                        }
                    }
                    db.SaveChanges();
                }
            }
            else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                using (var db = new Model.Contexts.anliksiparisler_telefonlarDbContext())
                {
                    if (gelen_anliksparis_adi != null)
                    {

                        var secilen_itemi_veritabanina_sor = from k in db.anlik_siparisler_telefonlar
                                                             where k.anliksiparis_telefon_adi == secilen_telefon_label.Text && k.anliksiparis_adi == gelen_anliksparis_adi
                                                             select k;

                        foreach (var eleman in secilen_itemi_veritabanina_sor)
                        {
                            db.anlik_siparisler_telefonlar.Remove(db.anlik_siparisler_telefonlar.Find(eleman.anliksiparis_id)); // idden ancak silebiliyoruz linq sorgusu yapıp idsini aldım
                        }
                    }
                    else
                    {
                        // secilen telefona ağit tüm kayıtlar gitsin
                        var secilen_itemi_veritabanina_sor = from k in db.anlik_siparisler_telefonlar
                                                             where k.anliksiparis_telefon_adi == secilen_telefon_label.Text
                                                             select k;

                        foreach (var eleman in secilen_itemi_veritabanina_sor)
                        {
                            db.anlik_siparisler_telefonlar.Remove(db.anlik_siparisler_telefonlar.Find(eleman.anliksiparis_id)); // idden ancak silebiliyoruz linq sorgusu yapıp idsini aldım
                        }
                    }
                    db.SaveChanges();
                }

            }
        }

        private void cikartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {

                if (ic_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    menuVeritabanindanSil(ic_siparisler_materialListView.Items[ic_siparisler_materialListView.FocusedItem.Index].Text);
                    ic_siparisler_materialListView.Items[ic_siparisler_materialListView.FocusedItem.Index].Remove(); // focuslanan itemi sil

                }
                else
                {
                    var ic_siparisten_bul = ic_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text);
                    ic_siparisler_materialListView.Items[ic_siparisten_bul.Index].Remove(); // focuslanan itemi sil
                    menuVeritabanindanSil(menu_listview.FocusedItem.Text);

                }

                siparis_listeleri_yenile(secilen_masa_label.Text);
            }
            else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {

                if (dis_siparisler_materialListView.FocusedItem != null)
                { // iç sipariş listesinden focuslanmışsa

                    menuVeritabanindanSil(dis_siparisler_materialListView.Items[dis_siparisler_materialListView.FocusedItem.Index].Text);
                    dis_siparisler_materialListView.Items[dis_siparisler_materialListView.FocusedItem.Index].Remove(); // focuslanan itemi sil

                }
                else
                {
                    var dis_siparisten_bul = dis_siparisler_materialListView.FindItemWithText(menu_listview.FocusedItem.Text);
                    dis_siparisler_materialListView.Items[dis_siparisten_bul.Index].Remove(); // focuslanan itemi sil
                    menuVeritabanindanSil(menu_listview.FocusedItem.Text);

                }
                siparis_listeleri_yenile(secilen_telefon_label.Text);
            }

            ToplamTutarHesapla();// şimdiye kadar bu masanın/telefonun sipariş listesi toplamı getiriyor ve toplam hesaba yazıyor
        }

        private void ToplamTutarHesapla()// şimdiye kadar bu masanın sipariş listesi toplamı getiren ve toplam hesaba yazan metod
        {
            double toplam_fiyat = 0;
            string fiyat;
            int adet;
            if (anamenu_materialTabControl.SelectedTab.Name == "ic_siparisler_tabpage")
            {
                for (int i = 0; i < ic_siparisler_materialListView.Items.Count; i++)
                {
                    fiyat = ic_siparisler_materialListView.Items[i].SubItems[2].Text; // sipariş listesinden fiyatlarını çekimi
                    adet = Convert.ToInt32(ic_siparisler_materialListView.Items[i].SubItems[1].Text);// sipariş listesinden adetlerin çekimi
                    toplam_fiyat += TemizFiyat(fiyat) * adet;// temiz fiyatların adetleri ile çarpımı mesela 3 işkembe çorbası
                }

                ic_siparis_tutar_label.Text = toplam_fiyat.ToString("C"); // .. ve toplam fiyatın tutara yazılması
            }
            else if (anamenu_materialTabControl.SelectedTab.Name == "dis_siparisler_tabpage")
            {
                for (int i = 0; i < dis_siparisler_materialListView.Items.Count; i++)
                {
                    fiyat = dis_siparisler_materialListView.Items[i].SubItems[2].Text; // sipariş listesinden fiyatlarını çekimi
                    adet = Convert.ToInt32(dis_siparisler_materialListView.Items[i].SubItems[1].Text);// sipariş listesinden adetlerin çekimi
                    toplam_fiyat += TemizFiyat(fiyat) * adet;// temiz fiyatların adetleri ile çarpımı mesela 3 işkembe çorbası
                }
                dis_siparis_tutar_label.Text = toplam_fiyat.ToString("C"); // .. ve toplam fiyatın tutara yazılması
            }


        }
        private double TemizFiyat(string gelen_fiyat)
        {
            string[] tlsiz_fiyat;
            double temiz_fiyat = 0;
            tlsiz_fiyat = gelen_fiyat.Split(' ');// tlsi alınış fiyat
			temiz_fiyat = Convert.ToDouble(tlsiz_fiyat[0].TrimStart('£'));// örneğin 5,50

			return temiz_fiyat;
        }

        private void hesabi_al_buttonlari_Click(object sender, EventArgs e)
        {
          
            odeme odeme_formu = new odeme();
            odeme_formu.Show();
        }

        private void telefon_siparis_al_materialRaisedButton_Click(object sender, EventArgs e)
        {
            menu_olustur(true); // menü oluşturulsun
            telefonIslemi(true);// telefon işlemi açık olsun
            MenuUyariYazisi(false, "");// uyari yazısı olmasın
            SiparisBilgileriEnabled(true); // sipariş bilgileri gurubu aktif olsun
            secilen_telefon_pictureBox.Name = "secilen_dolutelefon"; // secilen_dolu/bos
        }

        private void telefon_siparis_tamamla_materialRaisedButton1_Click(object sender, EventArgs e)
        {
            telefonIslemi(false); // telefon işlemi kapalı olsun
            menu_olustur(false);// menü gösterilmesin
            MenuUyariYazisi(true, "Lütfen Önce Telefon Açınız..."); // telefon kapalı olcağı için açınız uyarısı gözüksün
            ic_siparisler_materialListView.Items.Clear();// telefon kapatıldığına göre siparişler listesi boşaltılsın
            menuVeritabanindanSil(null);
            siparis_listeleri_yenile(secilen_telefon_label.Text);
            SiparisBilgileriEnabled(false);
            ic_siparis_tutar_label.Text = "0 TL";// varsayılan tutar gözüksün
            secilen_telefon_pictureBox.Name = "secilen_bostelefon"; // secilen_dolu/bos
        }

        private void SiparisBilgileriEnabled(bool aktif_pasif)
        {
            if (!aktif_pasif)
            {
                secilen_telefon_telno_textBox.Text = "";
                secilen_telefon_kurye_combobox.Text = "";
                secilen_telefon_adres_textBox.Text = "";
            }
            secilen_telefon_telno_textBox.Enabled = aktif_pasif;
            secilen_telefon_kurye_combobox.Enabled = aktif_pasif;
            secilen_telefon_adres_textBox.Enabled = aktif_pasif;
        }

        private void secilen_telefon_telno_textBox_Text_KeyUp(object sender, KeyEventArgs e)
        {

            telefonSiparisBilgileriGuncelle(); // secilen telefon telnosu kutusu değiştiğinde veritabanıda deişsin

        }

        private void telefonSiparisBilgileriGuncelle()
        {
            using (var db = new Model.Contexts.anliksiparisler_telefonlarDbContext())
            {
                var siparis_bilgileri = from k in db.anlik_siparisler_telefonlar
                                        where k.anliksiparis_telefon_adi == secilen_telefon_label.Text
                                        select k; // secilen telefona ağit tüm sipariş sipariş bilgilerini almış olyuroz
                foreach (var eleman in siparis_bilgileri)
                {
                    if (secilen_telefon_telno_textBox.Text != "")
                    {
                        eleman.anliksiparis_telefon_no = Convert.ToInt64(secilen_telefon_telno_textBox.Text); // bulduğum telefona ağit bütün sipariş telefon nolarını text changede göre değiştiriyoruz
                    }

                    // kurye combobaxına aynı kuryeyi üst üste atıyor bazen yani Enes KILIÇEnes KILIÇ oluyor bunu engelleyelim 1 den azsa 
                    if (secilen_telefon_kurye_combobox.Items[secilen_telefon_kurye_combobox.SelectedIndex].ToString() != null)// secilen text boş değilse
                    {
                        eleman.anliksiparis_kurye =  Convert.ToString(secilen_telefon_kurye_combobox.Items[secilen_telefon_kurye_combobox.SelectedIndex]);
                    }
                    if (secilen_telefon_adres_textBox.Text != "")
                    {
                        eleman.anliksiparis_adres = secilen_telefon_adres_textBox.Text.ToString();
                    }


                }
                db.SaveChanges();
            }

        }

        private void secilen_telefon_kurye_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            telefonSiparisBilgileriGuncelle(); // secilen_telefon_kurye_combobox secilen index değiştiğinde veritabanıda deişsin
        }

        private void secilen_telefon_adres_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            telefonSiparisBilgileriGuncelle(); // secilen telefon adres kutusu değiştiğinde veritabanıda deişsin


        }
        /* MENU/GARSON İŞEMLERİ 1.KISIM */
        /********************************************************************************************************************************************************************************************/


        TextBox[] secilen_menu_items;
        TextBox[] secilen_menu_fiyats;

        MaterialRaisedButton[] secilen_menu_sil_button;
        
        public void secilenMenuGuncelle(string gelen_secilen_menu,int gelen_secilen_degiscek_menu_id,string gelen_secilen_degiscek_menu_isim,string gelen_secilen_degiscek_menu_fiyat)
        {
            secilen_menu_items = new
                   TextBox[100];
            secilen_menu_fiyats = new
                    TextBox[100];
            secilen_menu_sil_button = new
                   MaterialRaisedButton[100];

            ortak_degiskenler_classlar ortak_class = new ortak_degiskenler_classlar();


            if (gelen_secilen_menu == null) gelen_secilen_menu = "Çorbalar";

            switch (gelen_secilen_menu)
            {
                case "Çorbalar":
                    using (var db = new Model.Contexts.corbalarDbContext())
                    {
                      
                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                         if (gelen_secilen_degiscek_menu_isim != "") { // boş deilse

                                db.corbalar.Find(gelen_secilen_degiscek_menu_id).corbalar_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();
                               
                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu "+ ortak_class.cogulsuz(gelen_secilen_menu)+" silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();

                                
                               
                                if (dr==DialogResult.Yes)
                                {
                                    db.corbalar.Remove(db.corbalar.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }
                           

                        }
                        else if(gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat!="")
                        {
                            db.corbalar.Find(gelen_secilen_degiscek_menu_id).corbalar_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if(gelen_secilen_degiscek_menu_id!=-1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim==null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.corbalar.Remove(db.corbalar.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();
                          
                            foreach (var eleman in db.corbalar)
                            {

                                secilenMenuTextboxOlustur(eleman.corbalar_id, eleman.corbalar_isim);
                                secilenMenuFiyatOlustur(eleman.corbalar_id,eleman.corbalar_fiyat);
                                secilenMenuSilButtonOlustur(eleman.corbalar_id);
                            }
                        }                       
                    }
                   break;
                case "Kebaplar":
                    using (var db = new Model.Contexts.kebaplarDbContext())
                    {


                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                            if (gelen_secilen_degiscek_menu_isim != "")
                            { // boş deilse

                                db.kebaplar.Find(gelen_secilen_degiscek_menu_id).kebap_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();

                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();



                                if (dr == DialogResult.Yes)
                                {
                                    db.kebaplar.Remove(db.kebaplar.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }


                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat != "")
                        {
                            db.kebaplar.Find(gelen_secilen_degiscek_menu_id).kebap_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim == null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.kebaplar.Remove(db.kebaplar.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();

                            foreach (var eleman in db.kebaplar)
                            {

                                secilenMenuTextboxOlustur(eleman.kebap_id, eleman.kebap_isim);
                                secilenMenuFiyatOlustur(eleman.kebap_id, eleman.kebap_fiyat);
                                secilenMenuSilButtonOlustur(eleman.kebap_id);
                            }
                        }


                    }
                    break;
                case "Anayemekler":
                    using (var db = new Model.Contexts.anayemeklerDbContext())
                    {
                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                            if (gelen_secilen_degiscek_menu_isim != "")
                            { // boş deilse

                                db.anayemekler.Find(gelen_secilen_degiscek_menu_id).anayemekler_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();

                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();



                                if (dr == DialogResult.Yes)
                                {
                                    db.anayemekler.Remove(db.anayemekler.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }


                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat != "")
                        {
                            db.anayemekler.Find(gelen_secilen_degiscek_menu_id).anayemekler_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim == null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.anayemekler.Remove(db.anayemekler.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();

                            foreach (var eleman in db.anayemekler)
                            {

                                secilenMenuTextboxOlustur(eleman.anayemekler_id, eleman.anayemekler_isim);
                                secilenMenuFiyatOlustur(eleman.anayemekler_id, eleman.anayemekler_fiyat);
                                secilenMenuSilButtonOlustur(eleman.anayemekler_id);
                            }
                        }


                    }
                    break;
                case "Salatalar":
                    using (var db = new Model.Contexts.salatalarDbContext())
                    {

                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                            if (gelen_secilen_degiscek_menu_isim != "")
                            { // boş deilse

                                db.salatalar.Find(gelen_secilen_degiscek_menu_id).salata_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();

                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();



                                if (dr == DialogResult.Yes)
                                {
                                    db.salatalar.Remove(db.salatalar.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }


                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat != "")
                        {
                            db.salatalar.Find(gelen_secilen_degiscek_menu_id).salata_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim == null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.salatalar.Remove(db.salatalar.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();

                            foreach (var eleman in db.salatalar)
                            {

                                secilenMenuTextboxOlustur(eleman.salata_id, eleman.salata_isim);
                                secilenMenuFiyatOlustur(eleman.salata_id, eleman.salata_fiyat);
                                secilenMenuSilButtonOlustur(eleman.salata_id);
                            }
                        }
                    }
                    break;
                case "Tatlılar":
                    using (var db = new Model.Contexts.tatlilarDbContext())
                    {

                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                            if (gelen_secilen_degiscek_menu_isim != "")
                            { // boş deilse

                                db.tatlilar.Find(gelen_secilen_degiscek_menu_id).tatli_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();

                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();



                                if (dr == DialogResult.Yes)
                                {
                                    db.tatlilar.Remove(db.tatlilar.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }


                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat != "")
                        {
                            db.tatlilar.Find(gelen_secilen_degiscek_menu_id).tatli_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim == null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.tatlilar.Remove(db.tatlilar.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();

                            foreach (var eleman in db.tatlilar)
                            {

                                secilenMenuTextboxOlustur(eleman.tatli_id, eleman.tatli_isim);
                                secilenMenuFiyatOlustur(eleman.tatli_id, eleman.tatli_fiyat);
                                secilenMenuSilButtonOlustur(eleman.tatli_id);
                            }
                        }
                    }
                    break;
                case "İçecekler":
                    using (var db = new Model.Contexts.iceceklerDbContext())
                    {
                        // 0 gelince bir arttırırsak 1.index değişiyor ama diğer elemanlar normal
                        gelen_secilen_degiscek_menu_id++; // id bir arttıyoruz textboxtları listelerken azaltmıştık
                        if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_isim != null)
                        {


                            if (gelen_secilen_degiscek_menu_isim != "")
                            { // boş deilse

                                db.icecekler.Find(gelen_secilen_degiscek_menu_id).icecek_isim = gelen_secilen_degiscek_menu_isim;
                                db.SaveChanges();

                            }
                            else // boş gelirse silinsinmi uyarısı
                            {
                                yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                                yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                                yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                                DialogResult dr = new DialogResult();
                                dr = yesno_MessageBoxum.ShowDialog();



                                if (dr == DialogResult.Yes)
                                {
                                    db.icecekler.Remove(db.icecekler.Find(gelen_secilen_degiscek_menu_id));
                                    db.SaveChanges();
                                }
                                // burdasss
                            }


                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_fiyat != null && gelen_secilen_degiscek_menu_fiyat != "")
                        {
                            db.icecekler.Find(gelen_secilen_degiscek_menu_id).icecek_fiyat = float.Parse(gelen_secilen_degiscek_menu_fiyat);
                            db.SaveChanges();
                        }
                        else if (gelen_secilen_degiscek_menu_id != -1 && gelen_secilen_degiscek_menu_id != 0 && gelen_secilen_degiscek_menu_isim == null && gelen_secilen_degiscek_menu_fiyat == null)
                        {
                            yesno_Messagebox yesno_MessageBoxum = new yesno_Messagebox();
                            yesno_MessageBoxum.gelen_mesaj = "Bu " + ortak_class.cogulsuz(gelen_secilen_menu) + " silinsin mi?";
                            yesno_MessageBoxum.secilen_menugrubu = gelen_secilen_menu;

                            DialogResult dr = new DialogResult();
                            dr = yesno_MessageBoxum.ShowDialog();



                            if (dr == DialogResult.Yes)
                            {
                                db.icecekler.Remove(db.icecekler.Find(gelen_secilen_degiscek_menu_id));
                                db.SaveChanges();
                            }
                        }
                        else
                        { // hiç biri değilse listele
                            menuler_tableLayoutPanel.Controls.Clear();

                            foreach (var eleman in db.icecekler)
                            {

                                secilenMenuTextboxOlustur(eleman.icecek_id, eleman.icecek_isim);
                                secilenMenuFiyatOlustur(eleman.icecek_id, eleman.icecek_fiyat);
                                secilenMenuSilButtonOlustur(eleman.icecek_id);
                            }
                        }

                    }
                    break;

            }

                    
        
        
        }

       
        private void secilenMenuTextboxOlustur(int gelen_eleman_id, string gelen_eleman_isim)
        {
            
            gelen_eleman_id -= 1; // gelen eleman 0 dan başlasın çünkü textbox dizisi 0 dan başlıyor ama id 1den başlıyo bunları eşitlemek için idyi düşürelim 
            
            secilen_menu_items[gelen_eleman_id] = new TextBox();
            secilen_menu_items[gelen_eleman_id].Name = gelen_eleman_id.ToString();
            secilen_menu_items[gelen_eleman_id].Font= new Font("Monotype Corsiva", 15, FontStyle.Italic);
            secilen_menu_items[gelen_eleman_id].Text = gelen_eleman_isim;
            secilen_menu_items[gelen_eleman_id].Location = new Point(0, 0);
            secilen_menu_items[gelen_eleman_id].Size = new Size(170, 20);
            secilen_menu_items[gelen_eleman_id].KeyUp += new KeyEventHandler(secilen_menu_items_KeyPress);
            menuler_tableLayoutPanel.Controls.Add(secilen_menu_items[gelen_eleman_id]);
        }
        private void secilenMenuFiyatOlustur(int gelen_eleman_id, double gelen_eleman_isim)
        {
            gelen_eleman_id -= 1; // gelen eleman 0 dan başlasın çünkü textbox dizisi 0 dan başlıyor ama id 1den başlıyo bunları eşitlemek için idyi düşürelim 

            secilen_menu_fiyats[gelen_eleman_id] = new TextBox();
            secilen_menu_fiyats[gelen_eleman_id].Name = gelen_eleman_id.ToString();
            secilen_menu_fiyats[gelen_eleman_id].Font = new Font("Monotype Corsiva", 15, FontStyle.Italic);
            secilen_menu_fiyats[gelen_eleman_id].Text = gelen_eleman_isim.ToString();
            secilen_menu_fiyats[gelen_eleman_id].Location = new Point(0, 0);
            secilen_menu_fiyats[gelen_eleman_id].Size = new Size(50, 20);
            secilen_menu_fiyats[gelen_eleman_id].KeyUp += new KeyEventHandler(secilen_menu_items_Fiyat_KeyPress);
            menuler_tableLayoutPanel.Controls.Add(secilen_menu_fiyats[gelen_eleman_id]);
        }


       

        private void secilen_menu_items_KeyPress(object sender, KeyEventArgs e)
        {
            TextBox secilen_menu_TextBox = (TextBox)sender;

              
           secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text,Convert.ToInt32(secilen_menu_TextBox.Name),secilen_menu_TextBox.Text,null); // üzerinde değişklik yapılan textboxu güncelle
        }
        private void secilen_menu_items_Fiyat_KeyPress(object sender, KeyEventArgs e)
        {
            TextBox secilen_menu_TextBox = (TextBox)sender;

            if (secilen_menu_TextBox.Text != "")
            {
                secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, Convert.ToInt32(secilen_menu_TextBox.Name), null, secilen_menu_TextBox.Text); // üzerinde değişklik yapılan textboxu güncelle
            }

        }
        private void secilenMenuSilButtonOlustur(int gelen_eleman_id)
        {
            gelen_eleman_id -= 1; // gelen eleman 0 dan başlasın çünkü textbox dizisi 0 dan başlıyor ama id 1den başlıyo bunları eşitlemek için idyi düşürelim 
            secilen_menu_sil_button[gelen_eleman_id] = new MaterialRaisedButton();
            secilen_menu_sil_button[gelen_eleman_id].Name = gelen_eleman_id.ToString();
            secilen_menu_sil_button[gelen_eleman_id].Text = "SİL";
            secilen_menu_sil_button[gelen_eleman_id].Icon = resimlerim.cancel;
            secilen_menu_sil_button[gelen_eleman_id].Location = new Point(0, 0);
            secilen_menu_sil_button[gelen_eleman_id].Anchor = AnchorStyles.Top;
            secilen_menu_sil_button[gelen_eleman_id].AutoSize = true;
            secilen_menu_sil_button[gelen_eleman_id].MouseClick += new MouseEventHandler(secilen_menu_sil_button_Click);
            menuler_tableLayoutPanel.Controls.Add(secilen_menu_sil_button[gelen_eleman_id]);

        }
        private void secilen_menu_sil_button_Click(object sender, MouseEventArgs e)
        {
            MaterialRaisedButton secilen_sil_button = (MaterialRaisedButton)sender;
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, Convert.ToInt32(secilen_sil_button.Name), null, null);
        }



        private void corbalar_guncelle_button_Click(object sender, EventArgs e)
        {

            menu_islemleri_secilen_menu_baslik_label.Text = "Çorbalar";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, -1, null,null);

        }

        private void kebaplar_guncelle_button_Click(object sender, EventArgs e)
        {
            menu_islemleri_secilen_menu_baslik_label.Text = "Kebaplar";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, -1,null,null);
            
            

        }

        private void anayemekler_guncelle_button_Click(object sender, EventArgs e)
        {
            menu_islemleri_secilen_menu_baslik_label.Text = "Anayemekler";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text,-1,null,null);
            
            
        }

        private void salatalar_guncelle_button_Click(object sender, EventArgs e)
        {
            menu_islemleri_secilen_menu_baslik_label.Text = "Salatalar";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text,-1,null,null);
        }

        private void tatlilar_guncelle_button_Click(object sender, EventArgs e)
        {
            menu_islemleri_secilen_menu_baslik_label.Text = "Tatlılar";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text,-1,null,null);
            
        }

        private void icecekler_guncelle_button_Click(object sender, EventArgs e)
        {
            menu_islemleri_secilen_menu_baslik_label.Text = "İçecekler";
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, -1,null,null);
            
        }

        private void menu_ekle_button_Click(object sender, EventArgs e)
        {
            menu_item_ekle menu_item_ekle_formu = new menu_item_ekle();
            menu_item_ekle_formu.Show();
        }
        private void menu_yenile_button_Click(object sender, EventArgs e)
        {
            secilenMenuGuncelle(menu_islemleri_secilen_menu_baslik_label.Text, -1, null, null);
        }


        /* MENU/GARSON İŞEMLERİ 2.KISIM */
        /********************************************************************************************************************************************************************************************/
        ortak_degiskenler_classlar ortak_sinif = new ortak_degiskenler_classlar();
        PictureBox[] garson_resims;
        MaterialRaisedButton[] garson_bilgileri_buttons;
        public void GarsonTumunuListele() // her yerden erişmeliyim
        {
            garsonlar_tableLayoutPanel.Controls.Clear();
            garson_resims=new PictureBox[10000]; // veritabanında idler silindiği zaman çok yüksek atama yapıyor bizde burda çok yüksek bir değer verelim
            garson_bilgileri_buttons = new MaterialRaisedButton[10000];//veritabanında idler silindiği zaman çok yüksek atama yapıyor bizde burda çok yüksek bir değer verelim
            using (var db=new Model.Contexts.kullanicilarDbContext())
            {
                foreach(var eleman in db.kullanicilar)
                {
                  
                   GarsonOlustur(eleman.kullanici_id,eleman.kullanici_adi);                 
                }
            }
            /*
            garsonlar_tableLayoutPanel.Controls.Add(corbalar_pictureBox, 0, 0);
            garsonlar_tableLayoutPanel.Controls.Add(corbalar_guncelle_button, 0, 1);

            garsonlar_tableLayoutPanel.Controls.Add(kebaplar_pictureBox, 1, 0);
            garsonlar_tableLayoutPanel.Controls.Add(kebaplar_guncelle_button, 1, 1);


            garsonlar_tableLayoutPanel.Controls.Add(anayemekler_pictureBox, 2, 0);
            garsonlar_tableLayoutPanel.Controls.Add(anayemekler_guncelle_button, 2, 1);
            


            garsonlar_tableLayoutPanel.Controls.Add(salatalar_pictureBox, 0, 2);
            garsonlar_tableLayoutPanel.Controls.Add(salatalar_guncelle_button, 0, 3);


            garsonlar_tableLayoutPanel.Controls.Add(tatlilar_pictureBox, 1, 2);
            garsonlar_tableLayoutPanel.Controls.Add(tatlilar_guncelle_button, 1, 3);

            garsonlar_tableLayoutPanel.Controls.Add(icecekler_pictureBox, 2, 2);
            garsonlar_tableLayoutPanel.Controls.Add(icecekler_guncelle_button, 2, 3);
            */
        }


        int resim_col = -1;
        int resim_row = 0;

        int button_col = -1;
        int button_row = 1;

        int defa = 0;

        private void varsayilangarsontablodegerleri()
        {
            resim_col = -1;
            resim_row = 0;

            button_col = -1;
            button_row = 1;

            defa = 0;
        }

       

        
        private void GarsonOlustur(int gelen_garson_id,string gelen_garson_ismi)
        {
            resim_col++;
            button_col++;

            if (resim_col > 2) resim_col = 0;
            if (button_col > 2) button_col = 0;

            defa++;

           

            if (defa==4 || defa==7 || defa==10 || defa==13 || defa==16) { resim_row = button_row + 1;button_row=resim_row+1;}


            //if ((defa / 7) == 0) defa = 0;

            // GARSON RESMİ(İSME GÖRE)
            gelen_garson_id -= 1; // gelen eleman 0 dan başlasın çünkü picturebox dizisi 0 dan başlıyor ama id 1den başlıyo bunları eşitlemek için idyi düşürelim 
            garson_resims[gelen_garson_id] = new PictureBox();
            Point garson_resim_yer = new Point(0, 0);
            garson_resims[gelen_garson_id].Location = garson_resim_yer;
            garson_resims[gelen_garson_id].Name = gelen_garson_id.ToString();
            garson_listele_ekle garson_formu = new garson_listele_ekle();
            string resimyolu= ortak_sinif.projeYolu() + @"Resources\" + ortak_sinif.trtoeng(gelen_garson_ismi);


            for (int guncelleme_sayisi = 10; guncelleme_sayisi >= 0; guncelleme_sayisi--) // en son güncellenen resmi göster
            {
                if (File.Exists(resimyolu + guncelleme_sayisi + ".jpg"))
                {
                    garson_resims[gelen_garson_id].Image = Image.FromFile(resimyolu + guncelleme_sayisi + ".jpg");
                    break;
                }
                else

                if (File.Exists(resimyolu + ".jpg"))
                {
                    garson_resims[gelen_garson_id].Image = Image.FromFile(resimyolu + ".jpg");
                    
                }
            }

                garson_resims[gelen_garson_id].Size = new Size(160, 140);
            //garson_resims[gelen_garson_id].Height = 195;
            garson_resims[gelen_garson_id].SizeMode = PictureBoxSizeMode.Zoom;
            // picturebox1.BackColor = Color.Red;
            garson_resims[gelen_garson_id].Visible = true;

                
                garsonlar_tableLayoutPanel.Controls.Add(garson_resims[gelen_garson_id],resim_col,resim_row);


            // GARSON BİLGİLER GÖRME VE GÜNCELLEME BUTTONU

            garson_bilgileri_buttons[gelen_garson_id] = new MaterialRaisedButton();
            garson_bilgileri_buttons[gelen_garson_id].Name = gelen_garson_id.ToString();
            garson_bilgileri_buttons[gelen_garson_id].Text = gelen_garson_ismi;
            garson_bilgileri_buttons[gelen_garson_id].Icon = resimlerim.profile;
            garson_bilgileri_buttons[gelen_garson_id].Location = new Point(0, 0);
            garson_bilgileri_buttons[gelen_garson_id].Size = new Size(55, 36);
            garson_bilgileri_buttons[gelen_garson_id].Anchor = AnchorStyles.Top;
            garson_bilgileri_buttons[gelen_garson_id].AutoSize = true;
            garson_bilgileri_buttons[gelen_garson_id].MouseClick += new MouseEventHandler(garson_bilgileri_buttons_Click);


                garsonlar_tableLayoutPanel.Controls.Add(garson_bilgileri_buttons[gelen_garson_id],button_col,button_row);
          
        }

        private void garson_bilgileri_buttons_Click(object sender, MouseEventArgs e)
        {
            MaterialRaisedButton secilen_garson = (MaterialRaisedButton)sender;

            garson_listele_ekle garson = new garson_listele_ekle();
            garson.Gelen_garson_id = Convert.ToInt32(secilen_garson.Name);
            garson.ShowDialog();

            

        }

        private void garson_ekle_button_Click(object sender, EventArgs e)
        {
            garson_listele_ekle garson = new garson_listele_ekle();
            garson.Gelen_garson_id = -1;
            garson.ShowDialog();
        }

        private void yenile_button_Click(object sender, EventArgs e)
        {
            varsayilangarsontablodegerleri();
            GarsonTumunuListele();
        }


        /* REZERVASYON İŞEMLERİ */
        /********************************************************************************************************************************************************************************************/
        string kaydetorguncelle = "kaydet";
        int rez_no;
        private void rez_kaydet_guncelle_Button_Click(object sender, EventArgs e)
        {
            if (kaydetorguncelle == "kaydet")
            {
                rezervasyonKaydet();
            }
            else
            {
               

                rezervasyonGuncelle();
            }
        }
        private void rezervasyonListele()
        {
            rezervasyon_materialListView.Items.Clear();// eski itemler gitsin
            using (var db = new Model.Contexts.rezervasyonlarDbContext())
            {
                foreach (var eleman in db.rezervasyonlar)
                {
                    ListViewItem item = new ListViewItem(eleman.Rezervasyonlar_id.ToString());/*sıfırıncı eleman*/
                    item.SubItems.Add(eleman.Rezervasyonlar_tarih.ToShortDateString());
                    item.SubItems.Add(eleman.Rezervasyonlar_saat.ToString());
                    item.SubItems.Add(eleman.rezervasyonlar_Adsoyad.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_telno.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_masano.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_kisisayisi.ToString());
                    rezervasyon_materialListView.Items.Add(item);
                }
            }
        }
        private void rezervasyonKaydet()
        {
            using (var db = new Model.Contexts.rezervasyonlarDbContext())
            {

                Model.Entitiy.rezervasyon rezervasyon_ekle = Model.Entitiy.rezervasyon.getInstance();

                rezervasyon_ekle.rezervasyonlar_Adsoyad = rez_AdSoyad_TextBox.Text;
                rezervasyon_ekle.Rezervasyonlar_telno = Convert.ToInt64(rez_Telno_Textbox.Text);

                //saat/dakika/saniye(00) şeklinde saat comboboxundan secilen item,dakika comboboxundan seçilen item,0 saniye
                TimeSpan zaman = new TimeSpan(Convert.ToInt32(rez_saat_comboBox.Text), Convert.ToInt32(rez_dakika_comboBox.Text), 0);
                rezervasyon_ekle.Rezervasyonlar_saat = zaman;
                rez_dateTimePicker.Format = DateTimePickerFormat.Custom;// formatı değiştirilmesi serbest yap
                rez_dateTimePicker.CustomFormat = "yyyy-MM-dd"; // yıl-ay-gün olarak değiştiriyoruz
                rezervasyon_ekle.Rezervasyonlar_tarih = Convert.ToDateTime(rez_dateTimePicker.Text);

                rezervasyon_ekle.Rezervasyonlar_masano = Convert.ToInt32(rez_masa_comboBox.Text);
                rezervasyon_ekle.Rezervasyonlar_kisisayisi = Convert.ToInt32(rez_kisisayisi_comboBox.Text);
                rezervasyon_ekle.Rezervasyonlar_aciklama = rez_aciklama_textBox.Text;
                db.rezervasyonlar.Add(rezervasyon_ekle);
                db.SaveChanges();
                ortak_sinif.olumlu_olumsuzMessageBox(true, "Rezervasyon Başarıyla Kaydedildi..");
            }
        }
        private void rezervasyonGuncelle()
        {
            using (var db = new Model.Contexts.rezervasyonlarDbContext())
            {
                    var secilen_item = db.rezervasyonlar.Find(rez_no);
              
                    secilen_item.rezervasyonlar_Adsoyad = rez_AdSoyad_TextBox.Text;
                    secilen_item.Rezervasyonlar_telno = Convert.ToInt64(rez_Telno_Textbox.Text);

                    //saat/dakika/saniye(00) şeklinde saat comboboxundan secilen item,dakika comboboxundan seçilen item,0 saniye
                    TimeSpan zaman = new TimeSpan(Convert.ToInt32(rez_saat_comboBox.Text), Convert.ToInt32(rez_dakika_comboBox.Text), 0);
                    secilen_item.Rezervasyonlar_saat = zaman;
                    rez_dateTimePicker.Format = DateTimePickerFormat.Custom;// formatı değiştirilmesi serbest yap
                    rez_dateTimePicker.CustomFormat = "yyyy-MM-dd"; // yıl-ay-gün olarak değiştiriyoruz
                    secilen_item.Rezervasyonlar_tarih = Convert.ToDateTime(rez_dateTimePicker.Text);

                    secilen_item.Rezervasyonlar_masano = Convert.ToInt32(rez_masa_comboBox.Text);
                    secilen_item.Rezervasyonlar_kisisayisi = Convert.ToInt32(rez_kisisayisi_comboBox.Text);
                    secilen_item.Rezervasyonlar_aciklama = rez_aciklama_textBox.Text;
                    db.SaveChanges();
                    ortak_sinif.olumlu_olumsuzMessageBox(true, "Rezervasyon Başarıyla Güncellendi..");
                    rezervasyonListele();
                
            }
        }

        private void rez_yenile_Button_Click(object sender, EventArgs e)
        {
            rezervasyonListele();
        }

        private void rezervasyon_materialListView_SelectedIndexChanged(object sender, EventArgs e)/* üzerinden bir iteme tıklandığı zaman*/
        {
            kaydetorguncelle = "guncelle";
            rez_kaydet_guncelle_Button.Text = "Güncelle";
            rez_kaydet_guncelle_Button.Icon = resimlerim.update;

            rez_no = Convert.ToInt32(rezervasyon_materialListView.SelectedItems[0].SubItems[0].Text);

            using (var db = new Model.Contexts.rezervasyonlarDbContext())
            {


                var secilen_listele = from k in db.rezervasyonlar
                                      where k.Rezervasyonlar_id == rez_no
                                      select k;
                foreach (var eleman in secilen_listele)
                {
                    rez_AdSoyad_TextBox.Text = eleman.rezervasyonlar_Adsoyad;
                    rez_Telno_Textbox.Text = eleman.Rezervasyonlar_telno.ToString();
                    rez_dateTimePicker.Text = eleman.Rezervasyonlar_tarih.ToString();
                    rez_saat_comboBox.Text = eleman.Rezervasyonlar_saat.ToString().Substring(0, 2);
                    rez_dakika_comboBox.Text = eleman.Rezervasyonlar_saat.ToString().Substring(3, 2);
                    rez_masa_comboBox.Text = eleman.Rezervasyonlar_masano.ToString();
                    rez_kisisayisi_comboBox.Text = eleman.Rezervasyonlar_kisisayisi.ToString();
                    rez_aciklama_textBox.Text = eleman.Rezervasyonlar_aciklama;

                }
            }

        }

        private void rez_ara_button_Click(object sender, EventArgs e)
        {
            rezervasyon_materialListView.Items.Clear();
            using (var db = new Model.Contexts.rezervasyonlarDbContext())
            {
                long telno=0;
                if (rezara_Telno_TextBox.Text != "") telno = Convert.ToInt64(rezara_Telno_TextBox.Text); else telno = 565656565;

                var secilen_listele = from k in db.rezervasyonlar
                                      where k.rezervasyonlar_Adsoyad == rezara_AdSoad_TextBox.Text || k.Rezervasyonlar_telno == telno
                                      select k;
                foreach (var eleman in secilen_listele)
                {
                    ListViewItem item = new ListViewItem(eleman.Rezervasyonlar_id.ToString());/*sıfırıncı eleman*/
                    item.SubItems.Add(eleman.Rezervasyonlar_tarih.ToShortDateString());
                    item.SubItems.Add(eleman.Rezervasyonlar_saat.ToString());
                    item.SubItems.Add(eleman.rezervasyonlar_Adsoyad.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_telno.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_masano.ToString());
                    item.SubItems.Add(eleman.Rezervasyonlar_kisisayisi.ToString());
                    rezervasyon_materialListView.Items.Add(item);

                }
            }
        }

    }
}
