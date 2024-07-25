using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int TotolSumm { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
