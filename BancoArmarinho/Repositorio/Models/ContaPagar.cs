using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class ContaPagar
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public decimal? Valor { get; set; }
    }
}
