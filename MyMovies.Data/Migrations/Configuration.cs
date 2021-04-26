namespace MyMovies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyMovies.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyMovies.Data.ApplicationDbContext";
        }

        protected override void Seed(MyMovies.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // cs file should go here, then pass file through process method to array 
            string filepath = @"D:\Office\Excel\IMDb movies.csv";
            context.Movie.AddOrUpdate(m => m.MovieTitle, SeedHelperMethod.processMovie(filepath).ToArray());
        }
    }
}
