using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class anliksiparis_telefon
    {
        [Key]
        public int anliksiparis_id { get; set; }
        public string anliksiparis_telefon_adi { get; set; }
        public string anliksiparis_adi { get; set; }
        public int anliksiparis_miktar { get; set; }
        public string anliksiparis_fiyat { get; set; }
        public string anliksiparis_toplam_fiyat { get; set; }
        public long anliksiparis_telefon_no { get; set; } // uzun sayı
        public string anliksiparis_kurye { get; set; }
        public string anliksiparis_adres { get; set; }

        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static anliksiparis_telefon instance;
        private static anliksiparis_telefon Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new anliksiparis_telefon();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static anliksiparis_telefon getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }
    }
}
