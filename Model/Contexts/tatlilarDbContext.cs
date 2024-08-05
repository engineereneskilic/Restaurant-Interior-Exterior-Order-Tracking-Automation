using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class tatlilarDbContext: DbContext
    {
        public DbSet<Entitiy.tatli> tatlilar { get; set; }
    }
}
