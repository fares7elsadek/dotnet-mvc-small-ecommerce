using SmallEcommerceProject.Models;

namespace SmallEcommerceProject.ViewModel
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }

        public int CartCount { get; set; }

        public Cart Cart { get; set; }
    }
}
