using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WForecast.Data;
using WForecast.Data.Repositories;
using WForecast.Models;

namespace WForecast
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterFilterProvider();

            builder.RegisterSource(new ViewRegistrationSource());

            // adicionar repositorios aqui
            var ctx = new WContext("WContext");
            builder.RegisterModule(new RepositoryModule<Estado>(new EstadoRepository(ctx)));
            builder.RegisterModule(new RepositoryModule<Cidade>(new CidadeRepository(ctx)));
            builder.RegisterModule(new RepositoryModule<PrevisaoClima>(new PrevisaoClimaRepository(ctx)));
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
