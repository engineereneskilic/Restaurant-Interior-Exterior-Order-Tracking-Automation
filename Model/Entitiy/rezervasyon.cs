using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class rezervasyon
    {
        private int rezervasyonlar_id;
        [Key]
        public int Rezervasyonlar_id
        {
            get
            {
                return rezervasyonlar_id;
            }

            set
            {
                rezervasyonlar_id = value;
            }
        }
        private string rezervasyonlar_adsoyad;
        public string rezervasyonlar_Adsoyad
        {
            get
            {
                return rezervasyonlar_adsoyad;
            }

            set
            {
                rezervasyonlar_adsoyad = value;
            }
        }
        private long rezervasyonlar_telno;
        public long Rezervasyonlar_telno
        {
            get
            {
                return rezervasyonlar_telno;
            }

            set
            {
                rezervasyonlar_telno = value;
            }
        }
        private DateTime rezervasyonlar_tarih;
        public DateTime Rezervasyonlar_tarih
        {
            get
            {
                return rezervasyonlar_tarih;
            }

            set
            {
                rezervasyonlar_tarih = value;
            }
        }
       
        private TimeSpan rezervasyonlar_saat;
        [Column(TypeName = "time")] // veritabani veritipi time sadece zaman
        public TimeSpan Rezervasyonlar_saat
        {
            get
            {
                return rezervasyonlar_saat;
            }

            set
            {
                rezervasyonlar_saat = value;
            }
        }
        private int rezervasyonlar_masano;
        public int Rezervasyonlar_masano
        {
            get
            {
                return rezervasyonlar_masano;
            }

            set
            {
                rezervasyonlar_masano = value;
            }
        }
        private int rezervasyonlar_kisisayisi;
        public int Rezervasyonlar_kisisayisi
        {
            get
            {
                return rezervasyonlar_kisisayisi;
            }

            set
            {
                rezervasyonlar_kisisayisi = value;
            }
        }
        private string rezervasyonlar_aciklama;
        public string Rezervasyonlar_aciklama
        {
            get
            {
                return rezervasyonlar_aciklama;
            }

            set
            {
                rezervasyonlar_aciklama = value;
            }
        }
        /*Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz */
        private static rezervasyon instance;
        private static rezervasyon Instance
        {
            get
            {
                /*Buradaki asıl amaç manuel olarak instance oluşturulmasını engellemek. Bu amaçla yola çıkarak şuanki class’ımızın default constructor’unu private yapıyoruz 
                 ve ikinci bir instance oluşturulmasını engelliyoruz. Oluşturacağımız nesne sadece sınıf içerisinden oluşturulacağı için tek bir instance oluşturulmasını garantilemiş olacağız*/
                if (instance == null)
                {
                    instance = new rezervasyon();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static rezervasyon getInstance()// Instancemızın static olduğunu ve her yerden erişebileciğimizi ve ınstancemizi çağıran sınıf
        {
            return Instance;
        }

    }
}
