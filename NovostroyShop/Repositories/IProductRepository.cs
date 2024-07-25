using NovostroyShop.Models;

namespace NovostroyShop.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product entity);
        Task Update(Product entity);
        Task Delete(Product entity);
        Task<IEnumerable<Product>> SearchByWord(string word);
        Task<IEnumerable<Product>> Filter(List<int> categoryIds, List<int> brandIds, int minPrice, int maxPrice);
        Task<IEnumerable<Product>> GetDiscountedProducts();
    }
}
