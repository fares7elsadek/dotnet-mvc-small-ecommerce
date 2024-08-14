namespace SmallEcommerceProject.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public decimal TotalPrice { get; set; }
    }
}
