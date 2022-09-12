using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WForecast.Models;

namespace WForecast.Data.Repositories.Interfaces
{
    public interface IPrevisaoClimaRepository : IRepository<PrevisaoClima>
    {
        List<PrevisaoClima> BuscarTemperaturasMaximas();
        List<PrevisaoClima> BuscarTemperaturasMinimas();
        List<PrevisaoClima>  BuscarPrevisaoProximosDias(long? CidadeId);
    }
}