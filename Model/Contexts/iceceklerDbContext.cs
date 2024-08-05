using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class iceceklerDbContext:DbContext
    {
        public DbSet<Entitiy.icecek> icecekler { get; set; }
    }
}
