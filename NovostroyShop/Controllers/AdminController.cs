using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovostroyShop.Filters;
using NovostroyShop.Models;
using NovostroyShop.Repositories;
using NovostroyShop.ViewModels;

namespace NovostroyShop.Controllers
{
    [CustomAuthorize]
    public class AdminController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IProductRepository _productRepository;

        public AdminController(IRepository<Category> categoryRepository, IRepository<Brand> brandRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryRepository.GetAll();
            ViewBag.Brands = await _brandRepository.GetAll();
            ViewBag.Products = await _productRepository.GetAll();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                await _categoryRepository.Add(category);
            }
            else
            {
                var existingCategory = await _categoryRepository.GetById(category.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    await _categoryRepository.Update(existingCategory);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SaveBrand(Brand brand)
        {
            if (brand.id == 0)
            {
                await _brandRepository.Add(brand);
            }
            else
            {
                var existingBrand = await _brandRepository.GetById(brand.id);
                if (existingBrand != null)
                {
                    existingBrand.Name = brand.Name;
                    await _brandRepository.Update(existingBrand);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _brandRepository.GetById(id);
            if (brand != null)
            {
                await _brandRepository.Delete(brand);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductViewModel product)
        {
            Product product1 = new Product();
            if (product.Id == 0)
            {
                product1.Category = await _categoryRepository.GetById(product.CategoryId);
                product1.Brand = await _brandRepository.GetById(product.BrandId);
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Discount = product.Discount;
                product1.ImageSrc = product.ImageSrc ?? "";
                product1.ImageSrc2 = product.ImageSrc2 ?? "";
                product1.ImageSrc3 = product.ImageSrc3 ?? "";
                product1.ImageSrc4 = product.ImageSrc4 ?? "";
                product1.ImageSrc5 = product.ImageSrc5 ?? "";
                product1.ReviewDetails = new List<ReviewDetail>();
                _productRepository.Add(product1);
            }
            else
            {
                var existingProduct = await _productRepository.GetById(product.Id);
                if (existingProduct != null)
                {
                    existingProduct.ImageSrc = product.ImageSrc ?? "";
                    existingProduct.ImageSrc2 = product.ImageSrc2 ?? "";
                    existingProduct.ImageSrc3 = product.ImageSrc3 ?? "";
                    existingProduct.ImageSrc4 = product.ImageSrc4 ?? "";
                    existingProduct.ImageSrc5 = product.ImageSrc5 ?? "";
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Discount = product.Discount;
                    existingProduct.Category = await _categoryRepository.GetById(product.CategoryId);
                    existingProduct.Brand = await _brandRepository.GetById(product.BrandId);
                    
                    _productRepository.Update(existingProduct);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                await _productRepository.Delete(product);
            }
            return RedirectToAction("Index");
        }



    }
}
