using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        public string ImageSrc { get; set; }

        public string ImageSrc2 { get; set; }

        public string ImageSrc3 { get; set; }

        public string ImageSrc4 { get; set; }

        public string ImageSrc5 { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public decimal Discount { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }
    }

}
