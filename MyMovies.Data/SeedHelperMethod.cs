using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Data
{
    public static class SeedHelperMethod
    {
        public static List<Movie> processMovie(string path)
        {
            File.ReadAllLines(path).Skip(1).Where(l => l.Length > 1)
                .Select(Movie.ParseFromCSV).ToList();
        }
    }
}
