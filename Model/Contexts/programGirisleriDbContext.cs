using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class programGirisleriDbContext:DbContext
    {
        public DbSet<Entitiy.programGirisi> programGirisleri { get; set; }
    }
}
