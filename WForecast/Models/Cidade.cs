using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WForecast.Models
{
    public class Cidade : Entity
    {
        
        [Required(ErrorMessage = "O Nome da Cidade é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O Nome da Cidade deve ter pelo menos 3 letras")]
        [Display(Name = "Cidade")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O EstadoId não pode ser menor ou igual a 0")]
        public long EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
    }
}