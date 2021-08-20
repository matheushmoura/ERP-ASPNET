using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class CompraModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Data")]
        public DateTime? Data { get; set; }
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
        [Display(Name = "Fornecedor")]
        public int? Fornecedor { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Status")]
        public string Stat { get; set; }

        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        public virtual FornecedorModel FornecedorNavigation { get; set; }
        public virtual ICollection<CompraitensModel> Compraitens { get; set; }
    }
}
