using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Compra = new HashSet<Compra>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Endereço { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int? Numero { get; set; }
        public Boolean? Situacao { get; set; }

        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public virtual ICollection<Compra> Compra { get; set; }
    }
}
