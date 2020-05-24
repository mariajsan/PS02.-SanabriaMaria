using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PS02._SanabriaMaria.Models
{
    public class pedidosdbcontext:DbContext
    {
        public pedidosdbcontext() : base("MyConnection")
        {
        }
        public DbSet<pedidos> Pedidos { get; set; }

        public System.Data.Entity.DbSet<PS02._SanabriaMaria.Models.productos> productos { get; set; }
    }
}