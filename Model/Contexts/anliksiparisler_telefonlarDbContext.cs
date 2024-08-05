using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class anliksiparisler_telefonlarDbContext:DbContext
    {
        public DbSet<Entitiy.anliksiparis_telefon> anlik_siparisler_telefonlar { get; set; }
    }
}
