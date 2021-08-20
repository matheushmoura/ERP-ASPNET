using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Usuario
    {
        public int Codigo { get; set; }
        public string Usuario1 { get; set; }
        public string Senha { get; set; }
        public int? Permissao { get; set; }
    }
}
