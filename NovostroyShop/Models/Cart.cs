namespace NovostroyShop.Models
{
    public class Cart
    {
        private List<CartItem> _items = new List<CartItem>();

        public IEnumerable<CartItem> Items => _items;

        public void AddItem(Product product, int quantity)
        {
            var cartItem = _items.SingleOrDefault(i => i.Product.Id == product.Id);
            if (cartItem == null)
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            var cartItem = _items.SingleOrDefault(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                _items.Remove(cartItem);
            }
        }

        public decimal TotalValue()
        {
            return _items.Sum(i => i.Product.Price * i.Quantity);
        }
    }

}
