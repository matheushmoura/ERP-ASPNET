using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class FornecedorModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Endereço")]
        public string Endereço { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Display(Name = "Numero")]
        public int? Numero { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Telefone")]
        public String Telefone2 { get; set; }
        [Display(Name = "Situacao")]
        public Boolean? Situacao { get; set; }

    }
}
