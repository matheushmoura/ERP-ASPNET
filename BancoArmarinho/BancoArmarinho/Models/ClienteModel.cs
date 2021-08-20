using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class ClienteModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string Inscricaoestadual { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Endereço")]
        public string Endereço { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Numero")]
        public int? Numero { get; set; }

        [Display(Name = "Situação")]
        public Boolean? Situacao { get; set; }

        [Display(Name = "Pontos")]
        public int? Pontos { get; set; }

        [Display(Name = "Telefone")]
        public String Telefone { get; set; }


        [Display(Name = "Telefone")]
        public String Telefone2 { get; set; }
    }
}
