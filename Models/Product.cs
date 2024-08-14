using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmallEcommerceProject.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }

        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        
        public bool Sale { get; set; }

        [DisplayName("Reviews")]
        public int Stars { get; set; }

        [DisplayName("Product Image")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        public Guid? Cart_Id { get; set; }

        public Cart? Cart { get; set; }
    }
}
