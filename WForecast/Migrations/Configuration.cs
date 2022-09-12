namespace WForecast.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WForecast.Data;
    using WForecast.Data.Structs;
    using WForecast.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WContext context)
        {
            // nao usado
        }
    }
}
