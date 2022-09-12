using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WForecast.Data.Repositories.Interfaces;
using WForecast.Models;

namespace WForecast.Data.Repositories
{
    public class EstadoRepository : Repository<Estado, WContext>, IEstadoRepository
    {
        public EstadoRepository(WContext ctx)
           : base(ctx)
        { }
    }
}