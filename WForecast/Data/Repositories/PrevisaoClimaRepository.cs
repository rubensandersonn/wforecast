using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WForecast.Data.Repositories.Interfaces;
using WForecast.Models;
using System.Data.Entity;


namespace WForecast.Data.Repositories
{
    public class PrevisaoClimaRepository : Repository<PrevisaoClima, WContext>, IPrevisaoClimaRepository
    {
        public PrevisaoClimaRepository(WContext ctx)
           : base(ctx)
        { }

        public List<PrevisaoClima> BuscarPrevisaoProximosDias(long? CidadeId)
        {
            if (CidadeId == null) return new List<PrevisaoClima>();

            var climas = _currentSet
                .Where(c => c.CidadeId == CidadeId.Value && c.Data >= DateTime.Today )
                .OrderBy(c => c.Data)
                .Take(7)
                .Include("Cidade")
                .ToList();

            return climas;
        }

        public List<PrevisaoClima> BuscarTemperaturasMaximas()
        {
            var climas = _currentSet
                .Where(e => e.IsActive && e.Data == DateTime.Today)
                .OrderByDescending(a => a.TemperaturaMaxima)
                .Take(3)
                .Include("Cidade")
                .ToList();

            return climas;
        }

        public List<PrevisaoClima> BuscarTemperaturasMinimas()
        {
            var climas = _currentSet
                .Where(e => e.IsActive && e.Data == DateTime.Today)
                .OrderBy(a => a.TemperaturaMinima)
                .Take(3)
                .Include("Cidade")
                .ToList();

            return climas;
        }
    }
}