using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class tatli
    {
        [Key]
        public int tatli_id { get; set; }
        public string tatli_isim { get; set; }
        public float tatli_fiyat { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.tatlilarDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] tatlilar_isim_varsayilanlar = new string[]
                {
                   "Fırın Sütlaç",
                   "Tel Kadayıf",
                   "Kemalpaşa",
                   "Kabak Tatlısı",
                   "Kayısı Komposto",
                   "Cacık",
                   "Özel Çömlek Yoğurdu"
                };
                float[] tatlilar_fiyat_varsayilanlar = new float[]
                {
                   7,7,7,7,5,7,7
                };


                var tablo_bosmu = (from k in db.tatlilar
                                   select k).Count();
                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < tatlilar_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                            tatli tatli = new tatli();
                            tatli.tatli_isim = tatlilar_isim_varsayilanlar[i];
                            tatli.tatli_fiyat = tatlilar_fiyat_varsayilanlar[i];

                            db.tatlilar.Add(tatli);
                            db.SaveChanges();
                    }
                }

            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static tatli instance;
        private static tatli Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new tatli();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static tatli getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
