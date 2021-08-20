using System;
using System.Collections.Generic;

namespace Repositorio.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venda = new HashSet<Venda>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Inscricaoestadual { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }

        public string Estado { get; set; }
        public string Endereço { get; set; }
        public int? Pontos { get; set; }
        public Boolean? Situacao { get; set; }

        public string Telefone { get; set; }

        public string Telefone2 { get; set; }

        public virtual ICollection<Venda> Venda { get; set; }
    }
}
