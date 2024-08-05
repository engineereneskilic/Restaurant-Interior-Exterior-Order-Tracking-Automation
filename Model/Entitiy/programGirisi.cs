using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class programGirisi
    {
        [Key]
        public int giris_id { get; set; }
        public string giris_tarih { get; set; }

        public string giris_zaman { get; set; }
        public string giris_kullanici { get; set; }


        public void programGirisiEkle()
        {
            using (var db = new Model.Contexts.programGirisleriDbContext())
            {
                DateTime simdiki_zaman = DateTime.Now;
                programGirisi programgirisi = new programGirisi();
                programgirisi.giris_tarih = simdiki_zaman.ToShortDateString();// sadece tarih
                programgirisi.giris_zaman = simdiki_zaman.ToLongTimeString();// sadece saat (saniyesi ile birlikte)
                programgirisi.giris_kullanici = ortak_degiskenler_classlar.Kullanici_ismi;

                db.programGirisleri.Add(programgirisi);
                db.SaveChanges();

            }
        }

     
    }


}
