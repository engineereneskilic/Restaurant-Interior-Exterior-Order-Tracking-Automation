using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient; // sql kütüphanesini çağırıyoruz

namespace MaterialSkinExample
{
    public class ortak_degiskenler_classlar
    {

        public static string program_ismi = "KILIÇ LOKANTASI SİPARİŞ TAKİP PROGRAMI";
        private static string kullanici_ismi;
        private static string sifre;
        public static string Kullanici_ismi // kapsülleme yapıyoruz güvenlik için
        {
            get { return kullanici_ismi; }
            set { kullanici_ismi = value; }
        }

        public static string Sifre // kapsülleme yapıyoruz güvenlik için
        {
            get { return sifre; }
            set { sifre = value; }
        }


        private string fiyat;

        public string Fiyat // kapsülleme yapıyoruz
        {
            get { return fiyat; }
            set { fiyat = Convert.ToDouble(value).ToString("C");}// para birimine dönüştürdük
           
        }

        
        public string projeYolu()
        {
            string uzunyol = System.Windows.Forms.Application.StartupPath;
            string[] stringSeparators = new string[] { @"bin\Debug" };
            string[] cogulDizisi = uzunyol.Split(stringSeparators, StringSplitOptions.None);

            return cogulDizisi[0];
        }


        public bool ilkAcilis()
        {
            DateTime simdiki_zaman = DateTime.Now;
            string tarih = simdiki_zaman.ToShortDateString();

            using (var db = new Model.Contexts.programGirisleriDbContext())
            {
                var ilk_acilis_mi = from k in db.programGirisleri
                                    where k.giris_tarih== tarih
                                    select k;

                if (ilk_acilis_mi == null) // bugünnün tarihini program girişlerinde bulamadıysa bugün bu programa hiçbir kullanıcı girmemiştir dolayısıyla bir nevi lokantamız kapalıdır tabi masalarda durumları kapalıdır
                {
                    return true; // doğru ilk açılış lokanta otomasyonumuzu bugün kimse kullanmamış
                }
                else
                {
                    return false; // yanlış ilk açılış değil lokanta otomasyonumuzu daha önceden biri kullanmış
                }

            }
        }

        public string trtoeng(string gelen_yazi)
        {
            gelen_yazi = gelen_yazi.ToLower();
            gelen_yazi = gelen_yazi.Replace('ç', 'c');
            gelen_yazi = gelen_yazi.Replace('ö', 'o');
            gelen_yazi = gelen_yazi.Replace('ü', 'u');
            gelen_yazi = gelen_yazi.Replace('ğ', 'g');
            gelen_yazi = gelen_yazi.Replace('ş', 's');
            gelen_yazi = gelen_yazi.Replace('ı', 'i');
            gelen_yazi = gelen_yazi.Replace(' ', '_');

            return gelen_yazi;
        }

        public void olumlu_olumsuzMessageBox(bool olumlumu,string gelen_mesaj)
        {
            olumlu_olumsuz_MessegeBox olumluMessageBox = new olumlu_olumsuz_MessegeBox();
            olumluMessageBox.olumlumu = olumlumu;
            olumluMessageBox.gelen_mesaj = gelen_mesaj;
            olumluMessageBox.ShowDialog();
        }
        public string cogulsuz(string gelen_cogullu)
        {
            string cogullar = gelen_cogullu;
            string[] stringSeparators = new string[] { "lar", "ler","/" };
            string[] cogulDizisi = cogullar.Split(stringSeparators, StringSplitOptions.None);

            return cogulDizisi[0];
        }


        public bool IsNumeric(string value)
        {
            double oReturn = 0;
            return double.TryParse(value, out oReturn);
        }


    }

  
}
