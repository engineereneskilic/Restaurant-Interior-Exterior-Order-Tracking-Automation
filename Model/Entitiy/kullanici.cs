using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class kullanici
    {
        [Key]
        public int kullanici_id { get; set; }
        public string kullanici_adi { get; set; }
        public string kullanici_sifre { get; set; }
        public string kullanici_cinsiyet { get; set; }
        public string kullanici_medeni_durum { get; set; }
        public string kullanici_tckimlik { get; set; }
        public string kullanici_dogum_tarihi { get; set; } 
        public string kullanici_dogumyeri { get; set; }
        public string kullanici_telno { get; set; }
        public string kullanici_adres { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.kullanicilarDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                object[,] kullanici_bilgileri= new object[6,9];
                kullanici_bilgileri[0, 0] = "Enes KILIÇ"; kullanici_bilgileri[0, 1] = "enes123"; kullanici_bilgileri[0, 2] = "Erkek"; kullanici_bilgileri[0, 3] = "Evli"; kullanici_bilgileri[0, 4] = "22509676953"; kullanici_bilgileri[0, 5] = "25.03.1998"; kullanici_bilgileri[0,6] = "Bakırköy/İstanbul";kullanici_bilgileri[0, 7] = "5434087551";kullanici_bilgileri[0, 8] = "Balat Mahallesi, Ayvansaray Cd. No:45, 34087 Fatih/İstanbul";
                kullanici_bilgileri[1, 0] = "Ahmet GURELİ";kullanici_bilgileri[1, 1] = "ahmet123"; kullanici_bilgileri[1, 2] = "Erkek"; kullanici_bilgileri[1, 3] = "Bekar"; kullanici_bilgileri[1, 4] ="22131656165"; kullanici_bilgileri[1, 5] = "10.06.1992"; kullanici_bilgileri[1, 6] = "Gelibolu/Çanakkale";kullanici_bilgileri[1, 7] = "5467801980";kullanici_bilgileri[1, 8] = "Ayazağa Mahallesi, 34398 Şişli/İstanbul";
                kullanici_bilgileri[2, 0] = "Nazlı KUNDURACI";kullanici_bilgileri[2, 1] = "nazli123"; kullanici_bilgileri[2, 2] = "Kadın"; kullanici_bilgileri[2, 3] = "Evli"; kullanici_bilgileri[2, 4] = "95123114662"; kullanici_bilgileri[2, 5] = "09.12.1990"; kullanici_bilgileri[2, 6] = "Demirköy/Kırklareli";kullanici_bilgileri[2, 7] = "5442313210";kullanici_bilgileri[2, 8] = "Beşyol Mahallesi, İnönü Cd. No:38, 34295 Küçükçekmece/İstanbul";
                kullanici_bilgileri[3, 0] = "Pelin DAĞCI";kullanici_bilgileri[3, 1] = "pelin123"; kullanici_bilgileri[3, 2] = "Kadın"; kullanici_bilgileri[3, 3] = "Evli"; kullanici_bilgileri[3, 4] ="15972468512"; kullanici_bilgileri[3, 5] = "15.07.1996"; kullanici_bilgileri[3, 6] = "Kartal/İstanbul";kullanici_bilgileri[3, 7] = "5468526943";kullanici_bilgileri[3, 8] = "Tepeören Mahallesi, 34959 Akfırat - Tuzla/İstanbul";
                kullanici_bilgileri[4, 0] = "Lale KİRAZLI";kullanici_bilgileri[4, 1] = "lale123"; kullanici_bilgileri[4, 2] = "Kadın"; kullanici_bilgileri[4, 3] = "Bekar"; kullanici_bilgileri[4, 4] = "54978213546"; kullanici_bilgileri[4, 5] = "02.05.1985"; kullanici_bilgileri[4, 6] = "Polatlı/Ankara";kullanici_bilgileri[4, 7] = "5352085978";kullanici_bilgileri[4, 8] = "Emniyettepe Mahallesi, Kazım Karabekir Cd. No: 2/13, 34060 İstanbul";
                kullanici_bilgileri[5, 0] = "Rasim KOCAYUREK";kullanici_bilgileri[5, 1] = "rasim123"; kullanici_bilgileri[5, 2] = "Erkek"; kullanici_bilgileri[5, 3] = "Bekar"; kullanici_bilgileri[5, 4] = "70165930148"; kullanici_bilgileri[5, 5] = "15.10.1966"; kullanici_bilgileri[5, 6] = "Çukurova/Adana";kullanici_bilgileri[5, 7] = "5439062016";kullanici_bilgileri[5, 8] = "Yıldız Mh., Çırağan Caddesi, Osmanpaşa Mektebi Sokak 4-6, 34349 Beşiktaş/İstanbul";

                var tablo_bosmu = (from k in db.kullanicilar
                                   select k).Count();

                if (tablo_bosmu == 0) // tablo boşsa
                {
                    for (int i = 0; i < kullanici_bilgileri.Length; i++) // dizi bitene kadar döngü
                    {
                            kullanici kullanici = new kullanici();
                            kullanici.kullanici_adi = kullanici_bilgileri[i, 0].ToString();
                            kullanici.kullanici_sifre = kullanici_bilgileri[i,1].ToString();
                            kullanici.kullanici_cinsiyet = kullanici_bilgileri[i, 2].ToString();
                            kullanici.kullanici_medeni_durum = kullanici_bilgileri[i, 3].ToString();
                            kullanici.kullanici_tckimlik = kullanici_bilgileri[i,4].ToString();
                            kullanici.kullanici_dogum_tarihi= kullanici_bilgileri[i, 5].ToString();
                            kullanici.kullanici_dogumyeri= kullanici_bilgileri[i, 6].ToString();
                            kullanici.kullanici_telno= kullanici_bilgileri[i, 7].ToString();
                            kullanici.kullanici_adres = kullanici_bilgileri[i, 8].ToString();

                            db.kullanicilar.Add(kullanici);
                            db.SaveChanges();
                    }
                    
                }

            }
        }
    }
}

