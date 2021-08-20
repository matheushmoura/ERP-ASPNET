using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Compraitens = new HashSet<Compraitens>();
            Itensvendidos = new HashSet<Itensvendidos>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int? Fornecedor { get; set; }
        public int? Categoria { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Preço { get; set; }
        public int? Estoque1 { get; set; }
        public int? Estoque2 { get; set; }

        public virtual ICollection<Compraitens> Compraitens { get; set; }
        public virtual ICollection<Itensvendidos> Itensvendidos { get; set; }
    }
}
