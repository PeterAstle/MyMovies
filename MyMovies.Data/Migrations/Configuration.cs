namespace MyMovies.Data.Migrations
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CsvHelper.Configuration.Attributes;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<MyMovies.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyMovies.Data.ApplicationDbContext context)
        {
            using (var streamReader = new StreamReader(@"D:\ElevenFiftyProjects\Blue Badge\MyMovieApi\MyMovies\MovieSeed.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<ClassMap>();
                    var records = csvReader.GetRecords<MovieSeed>();
                    ListtoDataTable listtoDataTable = new ListtoDataTable();
                    DataTable dt = listtoDataTable.ToDataTable(records);
                }
                
                
                
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
            }
        }
        public class MovieClassMap : ClassMap<MovieSeed>
        {
            public MovieClassMap()
            {
                Map(m => m.Title).Name("Movie Title");
                Map(m => m.Genre).Name("Movie Genre");
                Map(m => m.Rating).Name("Movie Rating");
            }
        }
        public class MovieSeed
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public double Rating { get; set; }
        }
        public class ListToDataTable
        {
            public ListtoDataTable ToDataTable<T>(List<T> items)
            {
                ListtoDataTable dataTable = new DataTable(typeof(T).Name);
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
        }
       
    }
}
