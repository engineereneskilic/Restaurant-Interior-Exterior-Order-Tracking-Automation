using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class kebaplarDbContext:DbContext
    {
        public DbSet<Entitiy.kebap> kebaplar { get; set; }
    }
}
