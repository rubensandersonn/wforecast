using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WForecast.Models
{
    public class Estado : Entity
    {
        
        [Required(ErrorMessage = "O Nome do Estado é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O Nome do Estado deve ter pelo menos 3 letras")]
        [Display(Name = "Estado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O UF do Estado é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O UF do Estado deve ter 2 letras")]
        public string UF { get; set; }
    }
}