using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Models
{
    public class Product
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

        public int Score { get; set; }

        public int CountPersonScores { get; set; }

        public int Price { get; set; }

        public decimal Discount { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual List<ReviewDetail> ReviewDetails { get; set; }


    }
}
