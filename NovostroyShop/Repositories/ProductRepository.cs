using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using NovostroyShop.Authentication;
using NovostroyShop.Models;

namespace NovostroyShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.ReviewDetails)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.ReviewDetails)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Filter(List<int> categoryIds, List<int> brandIds, int minPrice, int maxPrice)
        {
            // Получаем все продукты
            var products = await GetAll();

            // Фильтрация по выбранным категориям
            if (categoryIds != null && categoryIds.Any())
            {
                products = products.Where(p => categoryIds.Contains(p.Category.Id));
            }

            // Фильтрация по выбранным брендам
            if (brandIds != null && brandIds.Any())
            {
                products = products.Where(p => brandIds.Contains(p.Brand.id));
            }

            // Фильтрация по цене
            if (minPrice > 0)
            {
                products = products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice > 0)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }

            // Возвращаем отфильтрованные продукты
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> SearchByWord(string word)
        {
            var products = await GetAll();

            var sortedProducts = products.Where(p => p.Name.StartsWith(word)).ToList();

            return sortedProducts;
        }

        public async Task<IEnumerable<Product>> GetDiscountedProducts()
        {
            return await _context.Products
                .Where(p => p.Discount > 0 && p.Discount != null )
                .ToListAsync();
        }
    }
}
