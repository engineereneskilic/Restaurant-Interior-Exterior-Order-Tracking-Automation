using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class icecek
    {
        [Key]
        public int icecek_id { get; set; }
        public string icecek_isim { get; set; }
        public float icecek_fiyat { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.iceceklerDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] icecekler_isim_varsayilanlar = new string[]
                {
                    "Meyve Suyu",
                    "Cola",
                    "Fanta",
                    "Sprite",
                    "Soda",
                    "Ayran"
                };
                float[] icecekler_fiyat_varsayilanlar = new float[]
                {
                   1.5f,1.5f,1.5f,1.5f,0.75f,0,5f
                };


                var tablo_bosmu = (from k in db.icecekler
                                   select k).Count();
                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < icecekler_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                            icecek icecek = new icecek();
                            icecek.icecek_isim = icecekler_isim_varsayilanlar[i];
                            icecek.icecek_fiyat = icecekler_fiyat_varsayilanlar[i];

                            db.icecekler.Add(icecek);
                            db.SaveChanges();
                    }
                }

            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static icecek instance;
        private static icecek Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new icecek();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static icecek getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
