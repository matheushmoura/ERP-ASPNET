using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class ProdutoModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Fornecedor")]
        public int? Fornecedor { get; set; }

        [Display(Name = "Categoria")]
        public int? Categoria { get; set; }

        [Display(Name = "Quantidade")]
        public int? Quantidade { get; set; }

        [Display(Name = "Preço")]
        public decimal? Preço { get; set; }
        [Display(Name = "Estoque 1")]
        public int? Estoque1 { get; set; }
        [Display(Name = "Estoque 2")]
        public int? Estoque2 { get; set; }

    }
}
