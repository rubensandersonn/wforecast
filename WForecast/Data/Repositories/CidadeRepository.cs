using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WForecast.Data.Repositories.Interfaces;
using WForecast.Models;

namespace WForecast.Data.Repositories
{
    public class CidadeRepository : Repository<Cidade, WContext>, ICidadeRepository
    {
        public CidadeRepository(WContext ctx)
           : base(ctx)
        { }
    }
}