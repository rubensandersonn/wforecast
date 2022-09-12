using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WForecast.Models;

namespace WForecast.Data.Repositories
{
    public class RepositoryModule<T> : Module
        where T : Entity
    {
        protected readonly Repository<T, WContext> repository;

        public RepositoryModule(Repository<T, WContext> _repository)
        {
            repository = _repository;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => repository).InstancePerRequest();
            base.Load(builder);
        }
    }
}