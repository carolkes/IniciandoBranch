using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoBicicletas.Model
{
    public class BicicletasContext : DbContext
    {
        public DbSet<Bicicleta> Bicicletas { get; set; }
    }
}
