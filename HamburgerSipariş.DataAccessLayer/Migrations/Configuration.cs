namespace HamburgerSipariş.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HamburgerSiparis.DataAccessLayer.Context.HamburgerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HamburgerSiparis.DataAccessLayer.Context.HamburgerContext";
        }

        protected override void Seed(HamburgerSiparis.DataAccessLayer.Context.HamburgerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
