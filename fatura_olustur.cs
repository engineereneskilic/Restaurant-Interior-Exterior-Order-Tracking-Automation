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
    public partial class fatura_olustur : Form
    {
        public fatura_olustur()
        {
            InitializeComponent();
        }

        private void fatura_olustur_Load(object sender, EventArgs e)
        {
        
        }

        public int SatirSayisi = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ffff)
        {
            odeme odeme_formu = (odeme)Application.OpenForms["odeme"];

           
                //ÇİZİM BAŞLANGICI
                Font font = new Font("Calibri", 7); //font oluşturduk
                SolidBrush sbrush = new SolidBrush(Color.Black);//fırça oluşturduk
                Pen myPen = new Pen(Color.Black); //kalem oluşturduk

                ffff.Graphics.DrawString("Düzenlenme Tarihi: " + DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToLongTimeString(), font, sbrush, 50, 23);
                ffff.Graphics.DrawLine(myPen, 50, 43, 770, 43); // Çizgi çizdik... 1. Kalem, 2. X, 3. Y Koordinatı, 4. Uzunluk, 5. BitişX 

                // LOKANTA LOGOSU
                Bitmap logo_bitmap = resimlerim.kucuk_logo;

                ffff.Graphics.DrawImage(logo_bitmap, 40, 45);

                // MASA BİLGİLERİ VE GARSON
                /*
                myFont = new Font("Calibri",12,FontStyle.Regular);
                ffff.Graphics.DrawString("Masa No");
                */

                font = new Font("Calibri", 15, FontStyle.Bold);//Fatura başlığı yazacağımız için fontu kalın yaptık ve puntoyu büyütüp 15 yaptık.
                ffff.Graphics.DrawString("Ürün Listesi", font, sbrush, 350, 120);
                ffff.Graphics.DrawLine(myPen, 50, 150, 770, 150); //çizgi çizdik.

                font = new Font("Calibri", 10, FontStyle.Bold); //Detay başlığını yazacağımız için fontu kalın yapıp puntoyu 10 yaptık.
                ffff.Graphics.DrawString("Ürün Adı", font, sbrush, 50, 170); //Detay başlığı
                ffff.Graphics.DrawString("Ürün Adedi", font, sbrush, 190, 170); //Detay başlığı
                ffff.Graphics.DrawString("Garson", font, sbrush, 300, 170); //Detay başlığı
                ffff.Graphics.DrawString("Birim Fiyatı", font, sbrush, 550, 170); //Detay başlığı
                ffff.Graphics.DrawString("Toplam Fiyat", font, sbrush, 680, 170); //Detay başlığı
                ffff.Graphics.DrawLine(myPen, 50, 190, 770, 190); //Çizgi çizdik.

               


                int y = 195; //y koordinatının yerini belirledik.(Verilerin yazılmaya başlanacağı yer)

                font = new Font("Calibri", 10); //fontu 10 yaptık.


                int i = 0;//satır sayısı için değişken tanımladık.

                
                while (i < odeme_formu.odenecekler_materialListView.Items.Count)//döngüyü son satırda sonlandıracağız.
                {
                    ffff.Graphics.DrawString(odeme_formu.odenecekler_materialListView.Items[i].Text, font, sbrush, 50, y);//1.sütun
                    ffff.Graphics.DrawString(odeme_formu.odenecekler_materialListView.Items[i].SubItems[1].Text, font, sbrush, 220, y);//2.sütun
                    ffff.Graphics.DrawString(ortak_degiskenler_classlar.Kullanici_ismi, font, sbrush, 300, y);//3.sütun
                    ffff.Graphics.DrawString(odeme_formu.odenecekler_materialListView.Items[i].SubItems[2].Text, font, sbrush, 560, y);//5.sütun
                    ffff.Graphics.DrawString(odeme_formu.odenecekler_materialListView.Items[i].SubItems[2].Text, font, sbrush, 690, y);//6.sütun
                    y += 20; //y koordinatını arttırdık.
                    i += 1; //satır sayısını arttırdık

                   
                    //yeni sayfaya geçme kontrolü
                    if (y > 1000)
                    {
                        ffff.Graphics.DrawString("(Devamı -->)", font, sbrush, 700, y + 50);
                        y = 50;
                        break; //burada yazdırma sınırına ulaştığımız için while döngüsünden çıkıyoruz
                        //çıktığımızda while baştan başlıyor i değişkeni değer almaya devam ediyor
                        //yazdırma yeni sayfada başlamış oluyor
                    }

                    if (i == odeme_formu.odenecekler_materialListView.Items.Count)
                    {
                        font = new Font("Calibri", 11,FontStyle.Bold); //tekrardan kalın yaptık ve puntoyuda büyüttük

                        ffff.Graphics.DrawLine(myPen, 50, y, 770, y); //çizgi çizdik.
                        ffff.Graphics.DrawString("ÖDEME ŞEKLİ:", font, sbrush, 470, y);
                        ffff.Graphics.DrawString(odeme_formu.odeme_sekli, font, sbrush, 690, y);
                        ffff.Graphics.DrawString("GENEL TOPLAM FİYAT:", font, sbrush, 470, y+20);
                        ffff.Graphics.DrawString(odeme_formu.odenecektutar_label.Text, font, sbrush, 690, y+20);
                    }
                }




                //çoklu sayfa kontrolü
                if (i < SatirSayisi)
                {
                    ffff.HasMorePages = true;
                }
                else
                {
                    ffff.HasMorePages = false;
                    i = 0;
                }
                StringFormat myStringFormat = new StringFormat();
                myStringFormat.Alignment = StringAlignment.Far;

                
             
           
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

    }
}
