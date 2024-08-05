using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class kebap
    {
        [Key]
        public int kebap_id { get; set; }
        public string kebap_isim { get; set; }
        public float kebap_fiyat { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.kebaplarDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] kebaplar_isim_varsayilanlar = new string[]
                {
                    "Adana Kebap",
                    "Urfa Kebap",
                    "Beyti Kebap",
                    "Yoğurtlu Kebap",
                    "Karışık Sofra",
                    "Çöp Şiş",
                    "Tavuk Şiş",
                    "Tereyağlı İskender",
                    "Lahmacun",
                    "Peynirli Pide",
                    "Kıymalı Pide",
                    "Kavurmalı Pide",
                    "Karışık Pide",
                    "Kuşbaşılı Pide"

                };
                float[] kebaplar_fiyat_varsayilanlar = new float[]
                {
                   16,16,20,20,40,20,15,20,4,14,18,20,22,19
                };


                var tablo_bosmu = (from k in db.kebaplar
                                   select k).Count();

                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < kebaplar_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                            kebap kebap = new kebap();
                            kebap.kebap_isim = kebaplar_isim_varsayilanlar[i];
                            kebap.kebap_fiyat = kebaplar_fiyat_varsayilanlar[i];

                            db.kebaplar.Add(kebap);
                            db.SaveChanges();
                    }
                }

            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static kebap instance;
        private static kebap Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new kebap();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static kebap getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
