using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAnalyzerApp.Data
{
    public enum SortType { Increase, Decrease }
    public static class Calculations
    {
        public static Dictionary<string, decimal> CalculateBrandsPriceChange(List<Product> products, SortType sortType)
        {
            var brands = new Dictionary<string, List<decimal>>();

            foreach (var product in products)
            {
                decimal? firstPrice = GetFirstNonNullPrice(product);
                decimal? lastPrice = GetLastNonNullPrice(product);

                decimal priceChangePercentage = CalculateChangeInPercentages(firstPrice, lastPrice);

                if (!brands.ContainsKey(product.Brand))
                {
                    brands[product.Brand] = new List<decimal>();
                }

                brands[product.Brand].Add(priceChangePercentage);
            }

            var averagePriceChangesByBrand = brands
                .Select(b => new KeyValuePair<string, decimal>(b.Key, Math.Round(b.Value.Average(), 1)))
                .ToList();

            if (sortType == SortType.Increase)
            {
                averagePriceChangesByBrand = averagePriceChangesByBrand.OrderByDescending(pair => pair.Value).ToList();
            }
            else if (sortType == SortType.Decrease)
            {
                averagePriceChangesByBrand = averagePriceChangesByBrand.OrderBy(pair => pair.Value).ToList();
            }

            return averagePriceChangesByBrand.Take(10).ToList().ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public static decimal? ConvertToDecimal(string priceString)
        {
            if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                return price;
            return null;
        }
        public static decimal? GetLastNonNullPrice(Product product)
        {
            return ConvertToDecimal(product.Oct2022Price) ?? ConvertToDecimal(product.Sep2022Price) ?? ConvertToDecimal(product.Jul2022Price) ?? ConvertToDecimal(product.May2022Price) ?? ConvertToDecimal(product.Dec2021Price);
        }
        public static decimal? GetFirstNonNullPrice(Product product)
        {
            return ConvertToDecimal(product.Dec2021Price) ?? ConvertToDecimal(product.May2022Price) ?? ConvertToDecimal(product.Jul2022Price) ?? ConvertToDecimal(product.Sep2022Price) ?? ConvertToDecimal(product.Oct2022Price);

        }
        public static decimal CalculateChangeInPercentages(decimal? firstPrice, decimal? lastPrice)
        {
            // because we shouldn't divide by zero
            if (firstPrice.HasValue && lastPrice.HasValue && firstPrice != 0)
            {
                decimal percentageChange = (lastPrice.Value - firstPrice.Value) / firstPrice.Value * 100;
                return percentageChange;
            }
            return 0;
        }
        public static string CalculateChangeInPrice(List<Product> selectedProducts)
        {
            decimal totalFirstPrice = 0;
            decimal totalLastPrice = 0;

            foreach (Product product in selectedProducts)
            {
                decimal? firstPrice = GetFirstNonNullPrice(product);
                decimal? lastPrice = GetLastNonNullPrice(product);

                if (firstPrice.HasValue && lastPrice.HasValue)
                {
                    totalFirstPrice += firstPrice.Value;
                    totalLastPrice += lastPrice.Value;
                }
            }

            decimal percentageChange = CalculateChangeInPercentages(totalFirstPrice, totalLastPrice);

            if (percentageChange > 0)
                return "Price increased for " + percentageChange.ToString("0.0") + "%.";
            else if (percentageChange < 0)
                return "Price dropped for " + percentageChange.ToString("0.0") + "%.";
            else
                return "Price did not change";

        }
    }
}
