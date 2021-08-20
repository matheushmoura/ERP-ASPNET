using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class UsuarioModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario1 { get; set; }
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        [Display(Name = "Permissão")]
        public int? Permissao { get; set; }

    }
}
