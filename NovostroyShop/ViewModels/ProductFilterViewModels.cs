using NovostroyShop.Models;

namespace NovostroyShop.ViewModels
{
    public class ProductFilterViewModel
    {
        public List<int> SelectedCategoryIds { get; set; }
        public List<int> SelectedBrandIds { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
