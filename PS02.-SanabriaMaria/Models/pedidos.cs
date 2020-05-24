using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PS02._SanabriaMaria.Models
{
    public class pedidos
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre cliente")]
        public string Client { get; set; }

        [Display(Name = "Fecha Pedido")]
        public DateTime GeneratedDate { get; set; }

        [Display(Name = "Nota Adicional")]
        public string Note { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public virtual productos productos { get; set; }
    }
}