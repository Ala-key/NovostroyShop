using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Models
{
    public class ReviewDetail
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreate { get; set; }

        public string ReviewText { get; set; }
    }
}
