using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class telefon // masadan kalıtım denedim bu sefer dbo.masalar tablosuna telefon değişkenleride geliyor öle olsun isteymiyorum yani iki tablo birleşiyor
    {
        [Key]
        public int telefon_no { get; set; }
        public bool telefon_durum { get; set; }


        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.telefonlarDbContext())
            {

                var tek_sefer_sorgusu = (from k in db.telefonlar
                                        where k.telefon_durum == false
                                        select k).Count();
                if (tek_sefer_sorgusu==0)
                {
                    for (int i = 1; i <= 15; i++)
                    {
                        telefon telefon = new telefon();
                        telefon.telefon_durum = false;
                        db.telefonlar.Add(telefon);
                        db.SaveChanges();
                    }
                }
            }
            
        }
    }
}
