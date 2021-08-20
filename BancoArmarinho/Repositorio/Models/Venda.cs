using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Venda
    {
        public Venda()
        {
            ItensvendidosNavigation = new HashSet<Itensvendidos>();
        }

        public int Codigo { get; set; }
        public int? Cliente { get; set; }
        public int? Usuario { get; set; }
        public DateTime? Data { get; set; }
        public int? Itensvendidos { get; set; }
        public decimal? Total { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Desconto { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual ICollection<Itensvendidos> ItensvendidosNavigation { get; set; }
    }
}
