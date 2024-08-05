using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class corba
    {
        [Key]
        public int corbalar_id { get; set; }
        public string corbalar_isim { get; set; }
        public float corbalar_fiyat { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.corbalarDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] corbalar_isim_varsayilanlar = new string[]
                {
                    "İşkembe Çorbası",
                    "Mercimek Çorbası",
                    "Ezo Gelin Çorbasi",
                    "Tavuksuyu Çorbası",
                    "Yayla Çorbası",
                    "Kellepaça Çorbası",
                    "Ayak Paça"
                };
                float[] corbalar_fiyat_varsayilanlar = new float[]
                {
                   7,5,5,6,5,10,7
                };



                var tablo_bosmu = (from k in db.corbalar
                                select k).Count();

                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < corbalar_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                        var tmp = corbalar_isim_varsayilanlar[i]; // object dönüşümü



                        corba corba = new corba();
                        corba.corbalar_isim = corbalar_isim_varsayilanlar[i];
                        corba.corbalar_fiyat = corbalar_fiyat_varsayilanlar[i];

                        db.corbalar.Add(corba);
                        db.SaveChanges();
                    }
                }

            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static corba instance;
        private static corba Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new corba();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static corba getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
