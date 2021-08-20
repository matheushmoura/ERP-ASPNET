using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Compraitens
    {
        public int Ccodigo { get; set; }
        public int? Ccompra { get; set; }
        public int? Cquant { get; set; }
        public int? Prodcod { get; set; }

        public virtual Compra CcompraNavigation { get; set; }
        public virtual Produto ProdcodNavigation { get; set; }
    }
}
