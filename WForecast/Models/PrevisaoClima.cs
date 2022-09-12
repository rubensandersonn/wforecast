using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WForecast.Models
{
    public class PrevisaoClima : Entity
    {
        
        [Required(ErrorMessage = "Clima é obrigatório")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Clima deve ter pelo menos 3 letras")]
        public string Clima { get; set; }

        [Required(ErrorMessage = "A Temperatura Mínima é obrigatória")]
        [Display(Name = "Temperatura Mínima")]
        public decimal TemperaturaMinima { get; set; }

        [Required(ErrorMessage = "A Temperatura Máxima é obrigatória")]
        [Display(Name = "Temperatura Máxima")]
        public decimal TemperaturaMaxima { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O CidadeId não pode ser menor ou igual a 0")]
        public long CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

        [Required(ErrorMessage = "A Data é obrigatória")]
        public DateTime Data { get; set; }
    }
}