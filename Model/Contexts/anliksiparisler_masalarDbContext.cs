using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class anliksiparisler_masalarDbContext:DbContext
    {
        public DbSet<Entitiy.anliksiparis_masa> anlik_siparisler_masalar{ get; set; }
    }
}
