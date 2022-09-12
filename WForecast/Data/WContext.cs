using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WForecast.Models;

namespace WForecast.Data
{
    public class WContext : DbContext
    {
        public WContext() : base("name=WContext")
        {
        }

        public WContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<PrevisaoClima> PrevisaoClimas { get; set; }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }
    }
}
