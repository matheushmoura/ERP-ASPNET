using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class CategoriaModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "ERRO.. Informe o nome")]
        public string Nome { get; set; }
    }
}
