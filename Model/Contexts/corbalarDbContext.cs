using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkinExample.Model.Contexts
{
    class corbalarDbContext:DbContext
    {
        public DbSet<Entitiy.corba> corbalar { get; set; }
    }
}
