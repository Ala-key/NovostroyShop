using Microsoft.AspNetCore.Mvc;
using NovostroyShop.Models;
using NovostroyShop.Repositories;
using NovostroyShop.ViewModels;

namespace NovostroyShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _Repository;
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<Brand> _BrandRepository;
        private readonly IRepository<ReviewDetail> _ReviewRepository;
        private readonly IProductRepository productRepository;

        public ProductsController(IRepository<Product> Repository, IProductRepository productRepository, IRepository<Category> categoryRepository, IRepository<Brand> brandRepository, IRepository<ReviewDetail> reviewRepository)
        {
            _Repository = Repository;
            this.productRepository = productRepository;
            _CategoryRepository = categoryRepository;
            _BrandRepository = brandRepository;
            _ReviewRepository = reviewRepository;
        }

        private async Task FillViewBags()
        {
            ViewBag.Categories = await _CategoryRepository.GetAll();
            ViewBag.Brands = await _BrandRepository.GetAll();
            ViewBag.Products = await _Repository.GetAll();
            ViewBag.DiscountedProducts = await productRepository.GetDiscountedProducts();
        }

        public async Task<IActionResult> Index()
        {
            await FillViewBags();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            await FillViewBags();
            var products = await _Repository.GetAll();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(ProductFilterViewModel filter)
        {
            // Получаем выбранные категории и бренды, а также минимальную и максимальную цену
            var selectedCategoryIds = filter.SelectedCategoryIds ?? new List<int>();
            var selectedBrandIds = filter.SelectedBrandIds ?? new List<int>();
            var minPrice = filter.MinPrice;
            var maxPrice = filter.MaxPrice;

            // Выполняем фильтрацию
            var filteredProducts = await productRepository.Filter(selectedCategoryIds, selectedBrandIds, minPrice, maxPrice);
            await FillViewBags();

            // Возвращаем представление с отфильтрованными продуктами
            return View("Products",filteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> SearchByKeyWord(string word)
        {
            IEnumerable<Product> filteredProducts = await productRepository.SearchByWord(word);

            await FillViewBags();

            return View("Products", filteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Details(int productId)
        {
            var product = await productRepository.GetById(productId);

            return View(product);
        }



        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetRating([FromBody]RatingModel ratingModel)
        {
            var product = await productRepository.GetById(ratingModel.productId);
            product.CountPersonScores++;
            product.Score += ratingModel.rating;
            await productRepository.Update(product);

            // Возвращаем JSON с новым рейтингом и количеством голосов
            return Json(new { score = product.Score, count = product.CountPersonScores });
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ProductDetailsViewModel detailsViewModel)
        {
            var newReview = new ReviewDetail()
            {
                Name = User.Identity.Name,
                DateCreate = DateTime.Now,
                ReviewText = detailsViewModel.reviewText
            };

            var product = await productRepository.GetById(detailsViewModel.productId);

            await _ReviewRepository.Add(newReview);

            product.ReviewDetails.Add(newReview);

            await productRepository.Update(product);

            return RedirectToAction("Index");
        }


    }
}
