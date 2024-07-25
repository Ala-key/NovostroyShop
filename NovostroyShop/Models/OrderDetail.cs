using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Models
{
    public class OrderDetail
    {
        [Key]
        public int id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
