
using SmallEcommerceProject.Models.Data;

namespace SmallEcommerceProject.Models.Repositry
{
    public class ProductRepositry : IProductRepositry
    {
        AppDbContext context;
        public ProductRepositry(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            var products = context.Products.ToList();
            return products;
        }

        public Product GetProductsById(Guid productId)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }

        public void UpdateProduct(Product UpdatedProduct, Guid productId)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            product.Name = UpdatedProduct.Name;
            product.Cart = UpdatedProduct.Cart;
            product.Stars = UpdatedProduct.Stars;
            product.Sale = UpdatedProduct.Sale;
            product.Price = UpdatedProduct.Price;
            product.Cart_Id = UpdatedProduct.Cart_Id;
            context.SaveChanges();
        }
    }
}
