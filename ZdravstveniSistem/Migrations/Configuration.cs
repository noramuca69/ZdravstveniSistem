namespace ZdravstveniSistem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZdravstveniSistem.Data.ZdravstveniSistemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ZdravstveniSistem.Data.ZdravstveniSistemContext";
        }

        protected override void Seed(ZdravstveniSistem.Data.ZdravstveniSistemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
