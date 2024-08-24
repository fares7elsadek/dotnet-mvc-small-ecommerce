namespace SmallEcommerceProject.Models.Repositry
{
    public interface ICartRepositry
    {
        public Cart GetCartById(Guid CartId);
        public List<Cart> GetCarts();
        public void UpdateCart(Cart cart, Guid CartId);
        public void DeleteCart(Cart cart);

        public void UpdatCartPrice(Guid CartId , decimal Price);

        public void AddProductToCart(Product product,Guid CartId);
    }
}
