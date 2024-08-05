using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class anayemeklerDbContext:DbContext
    {
        public DbSet<Entitiy.anayemek> anayemekler { get; set; }
    }
}
