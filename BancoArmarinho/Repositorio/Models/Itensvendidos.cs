using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Itensvendidos
    {
        public int Codigo { get; set; }
        public int? Produto { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Valor { get; set; }
        public int? VendaCodigo { get; set; }

        public virtual Produto ProdutoNavigation { get; set; }
        public virtual Venda VendaCodigoNavigation { get; set; }
    }
}
