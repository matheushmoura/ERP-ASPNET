using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class ContaPagarModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
        [Display(Name = "Data")]
        public string Data { get; set; }
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
        

    }
}
