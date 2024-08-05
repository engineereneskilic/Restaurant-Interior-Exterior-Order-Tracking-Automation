using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Entitiy
{
    class masa
    {
        [Key]
        public int masa_no { get; set; }
        public bool masa_durum { get; set; }



        public void defaultVeriler()
        {
            using (var db = new Model.Contexts.masalarDbContext())
            {
                var tek_sefer_sorgusu = (from k in db.masalar
                                         where k.masa_durum == false
                                         select k).Count();
                
                if (tek_sefer_sorgusu == 0)
                {
                    for (int i = 1; i <= 15; i++)
                    {
                        masa masa = new masa();
                        masa.masa_durum = false;
                        db.masalar.Add(masa);
                        db.SaveChanges();
                    }
                }
            }
        }

      


    }
}
