using NovostroyShop.Models;

namespace NovostroyShop.Helpers
{
    public static class ProductsHelper
    {
        public static int CountStars(int scores, int users)
        {
            return scores == 0 || users == 0 ? 0 : scores / users;
        }

        public static IEnumerable<Product> GetBestProducts(IEnumerable<Product> products)
        {
            var bestProducts = products.OrderByDescending(x => CountStars(x.Score, x.CountPersonScores)).Take(3);
            return bestProducts;
        }

        public static decimal CalculateDiscountedPrice(int originalPrice, decimal discountPercentage)
        {
            decimal discount = originalPrice * (discountPercentage / 100);
            decimal discountedPrice = originalPrice - discount;
            return discountedPrice;
        }
    }
}
