namespace EM.Web.DataContexts.AlphaVantageMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EM.Web.DataContexts.AlphaVantageDb>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\AlphaVantageMigration";
        }

        protected override void Seed(EM.Web.DataContexts.AlphaVantageDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
