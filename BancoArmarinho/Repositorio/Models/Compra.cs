using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Compra
    {
        public Compra(){   Compraitens = new HashSet<Compraitens>();   }

        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public int? Fornecedor { get; set; }
        public string Observacao { get; set; }
        public string Stat { get; set; }
        public int Tipo { get; set; }

        public virtual Fornecedor FornecedorNavigation { get; set; }
        public virtual ICollection<Compraitens> Compraitens { get; set; }
    }
}
