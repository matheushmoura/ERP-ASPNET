using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BancoArmarinho.Models
{
    public class ItensvendidosModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Produto")]
        public int? Produto { get; set; }
        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
        [Display(Name = "Venda Codigo")]
        public int? VendaCodigo { get; set; }


        public virtual ProdutoModel ProdutoNavigation { get; set; }
        public virtual VendaModel VendaCodigoNavigation { get; set; }
    }
}
