
using Microsoft.EntityFrameworkCore;
using SmallEcommerceProject.Models.Data;

namespace SmallEcommerceProject.Models.Repositry
{
    public class CartRepositry : ICartRepositry
    {
        AppDbContext context;
        public CartRepositry(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProductToCart(Product product,Guid CartId)
        {
            var cart = context.Carts.Include(c => c.Products).FirstOrDefault(c => c.Id == CartId);
            cart.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public Cart GetCartById(Guid CartId)
        {
            var cart = context.Carts.Include(c => c.Products).FirstOrDefault(c => c.Id == CartId);
            return cart;
        }

        public List<Cart> GetCarts()
        {
            var carts = context.Carts.ToList();
            return carts;
        }

        public void UpdatCartPrice(Guid CartId, decimal Price)
        {
            var cart  = context.Carts.FirstOrDefault(c => c.Id == CartId);
            cart.TotalPrice += Price;
            context.SaveChanges();
        }

        public void UpdateCart(Cart cart, Guid CartId)
        {
            throw new NotImplementedException();
        }
    }
}
