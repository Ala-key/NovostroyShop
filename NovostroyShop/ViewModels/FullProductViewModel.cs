using NovostroyShop.Models;

namespace NovostroyShop.ViewModels
{
    public class FullProductViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Brand> Brands { get; set; }

        public List<Product> Products { get; set; }
    }
}
