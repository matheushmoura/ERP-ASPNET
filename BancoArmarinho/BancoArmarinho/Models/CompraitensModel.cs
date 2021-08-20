using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class CompraitensModel
    {
        [Display(Name = "Código")]
        public int Ccodigo { get; set; }
        [Display(Name = "Compra")]
        public int? Ccompra { get; set; }
        [Display(Name = "Quantidade")]
        public int? Cquant { get; set; }
        [Display(Name = "Produto")]
        public int? Prodcod { get; set; }

        public virtual CompraModel CcompraNavigation { get; set; }
        public virtual ProdutoModel ProdcodNavigation { get; set; }
    }
}
