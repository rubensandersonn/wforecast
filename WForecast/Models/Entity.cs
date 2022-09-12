using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WForecast.Models
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
        public DateTimeOffset ModifiedDate { get; protected set; } = DateTimeOffset.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}