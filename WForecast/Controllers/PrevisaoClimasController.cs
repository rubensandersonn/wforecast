using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WForecast.Data;
using WForecast.Data.Repositories;
using WForecast.Data.Repositories.Interfaces;
using WForecast.Data.Structs;
using WForecast.Models;

namespace WForecast.Controllers
{
    public class PrevisaoClimasController : Controller
    {
        private readonly IPrevisaoClimaRepository _repository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IEstadoRepository _estadoRepository;

        public PrevisaoClimasController(
            Repository<PrevisaoClima, WContext> repository,
            Repository<Estado, WContext> estadoRepository,
            Repository<Cidade, WContext> cidadeRepository
            )
        {
            _repository = (IPrevisaoClimaRepository)repository;
            _cidadeRepository = (ICidadeRepository)cidadeRepository;
            _estadoRepository = (IEstadoRepository)estadoRepository;
        }

        // GET: PrevisaoClimas
        public ActionResult Index()
        {
            var cidades = _cidadeRepository.GetAll().ToList();
            return View(cidades);
        }

        // GET: CidadesMaisQuentes
        public ActionResult CidadesMaisQuentes()
        {
            var climas = _repository.BuscarTemperaturasMaximas();
            return PartialView(climas);
        }

        // GET: CidadesMaisFrias
        public ActionResult CidadesMaisFrias()
        {
            var climas = _repository.BuscarTemperaturasMinimas();
            return PartialView(climas);
        }

        // GET: PrevisaoProximosDias/1
        public ActionResult PrevisaoProximosDias(long? id)
        {
            var climas = _repository.BuscarPrevisaoProximosDias(id);
            return PartialView(climas);
        }

        // GET: view para criar os dados
        public async Task<ActionResult> CriarDadosPrevisao()
        {
            var Estados = new List<Estado>()
            {
                new Estado()
                {
                    Nome = "Ceará",
                    UF = "CE"
                },
                new Estado()
                {
                    Nome = "Paraná",
                    UF = "PR"
                }
            };
            foreach(var estado in Estados)
                await _estadoRepository.InsertAsync(estado);

            Estado ceara = await _estadoRepository.FindAsync(e => e.Nome == "Ceará");
            Estado parana = await _estadoRepository.FindAsync(e => e.Nome == "Paraná");


            var Cidades = new List<Cidade>()
            {
                new Cidade()
                    {
                        Nome = "Fortaleza",
                        EstadoId = ceara.Id
                    },
                    new Cidade()
                    {
                        Nome = "Curitiba",
                        EstadoId = parana.Id
                    },
            };
            foreach (var cidade in Cidades)
                await _cidadeRepository.InsertAsync(cidade);

            Cidade fortaleza = await _cidadeRepository.FindAsync(c => c.Nome == "Fortaleza");
            Cidade curitiba = await _cidadeRepository.FindAsync(c => c.Nome == "Curitiba");

            var PrevisoesClimas = new List<PrevisaoClima>();
            for (int i = 0; i < 7; i++)
            {
                PrevisoesClimas.Add(new PrevisaoClima()
                {
                    Data = DateTime.Today.AddDays(-i),
                    CidadeId = fortaleza.Id,
                    Clima = Climas.Sol.ToString(),
                    TemperaturaMaxima = 32 - i,
                    TemperaturaMinima = 28 - i,
                });

                PrevisoesClimas.Add(new PrevisaoClima()
                {
                    Data = DateTime.Today.AddDays(-i),
                    CidadeId = curitiba.Id,
                    Clima = Climas.Frio.ToString(),
                    TemperaturaMaxima = 18 - i,
                    TemperaturaMinima = 12 - i,
                });

                PrevisoesClimas.Add(new PrevisaoClima()
                {
                    Data = DateTime.Today.AddDays(1 + i),
                    CidadeId = fortaleza.Id,
                    Clima = Climas.Sol.ToString(),
                    TemperaturaMaxima = 32 - i,
                    TemperaturaMinima = 28 - i,
                });

                PrevisoesClimas.Add(new PrevisaoClima()
                {
                    Data = DateTime.Today.AddDays(1 + i),
                    CidadeId = curitiba.Id,
                    Clima = Climas.Frio.ToString(),
                    TemperaturaMaxima = 18 - i,
                    TemperaturaMinima = 12 - i,
                });
            }

            foreach (var prev in PrevisoesClimas)
                await _repository.InsertAsync(prev);

            return Redirect("Index");
        }
    }
}
