using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class anayemek
    {
        [Key]
        public int anayemekler_id { get; set; }
        public string anayemekler_isim { get; set; }
        public float anayemekler_fiyat { get; set; }

        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.anayemeklerDbContext())
            {

                // veritabanına varsayılan olarak eklenecek verileri dizileri
                string[] anayemekler_isim_varsayilanlar = new string[] 
                {
                    "Kuzu Kaburga",
                    "Kuzu Haşlama",
                    "İncik Haşlama",
                    "Kuzu Anakra Tava",
                    "Kavurma",
                    "Et Sote",
                    "Tas Kebabı",
                    "Patlican Kebabı",
                    "Orman Kebabı",
                    "Salçalı Biftek",
                    "Dana Haşlama",
                    "Güveç",
                    "Sebzeli Kebap",
                    "Beykoz Kebap",
                    "Yufka Kebap",
                    "Kayık Kebabı",
                    "Etli Mantar Sote",
                    "Etli Türlü",
                    "Etli Bambya",
                    "Etli Lahana Sarması",
                    "Etli Karışık Dolma",
                    "Etli Kuru Fasulye",
                    "Yumurtalı Yoğurtlu Ispanak",
                    "Tavuk Sote",
                    "Mantarlı Tavuk Sote",
                    "Tavuk İncik",
                    "Fırında Tavuk But",
                    "İzmir Köfte",
                    "Fırın Köfte",
                    "İslim Köfte",
                    "Dalyan Köfte",
                    "Hasan Paşa Köfte",
                    "Pirinç Pilavı",
                    "Bulgur Pilavı",
                    "Fırın Makarna",
                    "Arnavut Ciğeri"
                };
                float[] anayemekler_fiyat_varsayilanlar = new float[]
                {
                    20,18,20,19,19,19,19,16,16,17,18,17,16,17,17,17,17,17,15,17,17,10,10,15,16,15,15,17,17,17,17,17,6,6,8,17
                };



                var tablo_bosmu = (from k in db.anayemekler
                                   select k).Count();

                if (tablo_bosmu == 0)
                {
                    for (int i = 0; i < anayemekler_isim_varsayilanlar.Length; i++) // dizi bitene kadar döngü
                    {
                        var tmp = anayemekler_isim_varsayilanlar[i]; // object dönüşümü



                        anayemek anayemek = new anayemek();
                        anayemek.anayemekler_isim = anayemekler_isim_varsayilanlar[i];
                        anayemek.anayemekler_fiyat = anayemekler_fiyat_varsayilanlar[i];

                        db.anayemekler.Add(anayemek);
                        db.SaveChanges();
                    }
                }

            }
        }


        private static anayemek instance;
        private static anayemek Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new anayemek();
                }
                return instance;

            }
            set
            {
                instance = value;
            }

        }
        public static anayemek getInstance()
        {
            return Instance;
        }

    }
}
