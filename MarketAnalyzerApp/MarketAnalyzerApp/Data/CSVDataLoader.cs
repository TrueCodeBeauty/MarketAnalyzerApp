using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalyzerApp.Data
{
    public static class CSVDataLoader
    {
        private static string datasetPath = Path.Combine(Application.StartupPath, "Data\\amazon_small_dataset.csv");
        private const int dataLimit = 100000;

        public static List<Product> LoadData()
        {
            using (var reader = new StreamReader(datasetPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ProductMap>();

                List<Product> products = csv.GetRecords<Product>().Take(dataLimit).ToList();

                return products;
            }
        }

    }
}
