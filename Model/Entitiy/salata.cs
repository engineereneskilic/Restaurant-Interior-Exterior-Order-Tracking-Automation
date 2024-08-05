using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class salata
    {
        [Key]
        public int salata_id { get; set; }
        public string salata_isim { get; set; }
        public float salata_fiyat { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.salatalarDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] salatalar_isim_varsayilanlar = new string[]
                {
                   "Çoban Salata",
                   "Yeşil Salata",
                   "Söğüş Salata",
                   "Göbek Salata"
                };
                float[] salatalar_fiyat_varsayilanlar = new float[]
                {
                   5,5,5,5,5
                };


                var tablo_bosmu = (from k in db.salatalar
                                   select k).Count();
                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < salatalar_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                            salata salata = new salata();
                            salata.salata_isim = salatalar_isim_varsayilanlar[i];
                            salata.salata_fiyat = salatalar_fiyat_varsayilanlar[i];

                            db.salatalar.Add(salata);
                            db.SaveChanges();
                    }
                }
            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static salata instance;
        private static salata Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new salata();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static salata getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
