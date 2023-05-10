using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalyzerApp.Data
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap() {
            Map(p => p.Title).Name("title");
            Map(p => p.Brand).Name("brand");
            Map(p => p.Dec2021Price).Name("dec-2021-price");
            Map(p => p.May2022Price).Name("may-2022-price");
            Map(p => p.Jul2022Price).Name("jul-2022-price");
            Map(p => p.Sep2022Price).Name("sep-2022-price");
            Map(p => p.Oct2022Price).Name("oct-2022-price");
        }
    }
}
