using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PS02._SanabriaMaria.Models
{
    public class productos
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Descripción")]

        public string Description { get; set; }
        [Display(Name = "Cantidad")]

        public int Availability { get; set; }
        [Display(Name = "Precio Unitario")]
        public SqlMoney Price { get; set; }
        
    }
}