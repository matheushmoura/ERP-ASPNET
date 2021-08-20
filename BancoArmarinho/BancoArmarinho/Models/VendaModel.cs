using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoArmarinho.Models
{
    public class VendaModel
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Cliente")]
        public int? Cliente { get; set; }
        [Display(Name = "Usuario")]
        public int? Usuario { get; set; }
        [Display(Name = "Data")]
        public DateTime? Data { get; set; }
        [Display(Name = "Itensvendidos")]
        public int? Itensvendidos { get; set; }
        [Display(Name = "Total")]
        public decimal? Total { get; set; }
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }
        [Display(Name = "Desconto")]
        public decimal? Desconto { get; set; }

        public virtual ClienteModel ClienteNavigation { get; set; }
        public virtual ICollection<ItensvendidosModel> ItensvendidosNavigation { get; set; }
    }
}
