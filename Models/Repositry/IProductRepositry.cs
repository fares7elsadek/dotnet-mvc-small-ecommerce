namespace SmallEcommerceProject.Models.Repositry
{
    public interface IProductRepositry
    {
        public Product GetProductsById(Guid productId);
        public List<Product> GetProducts();
        public void UpdateProduct(Product product,Guid productId);
        public void DeleteProduct(Product product);

        public void AddProduct (Product product);   
    }
}
