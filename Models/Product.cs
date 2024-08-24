using Microsoft.AspNetCore.Mvc;
using SmallEcommerceProject.Custome_Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmallEcommerceProject.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [DisplayName("Product Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        //[UniqueName(ErrorMessage = "Name Already Exist")]
        [Remote("UniqueName","Product",ErrorMessage = "Name Already Exist")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        [Range(0, 1000000,ErrorMessage = "the price must be between 0 and 1000000")]
        [Required]
        public decimal Price { get; set; }

        
        public bool Sale { get; set; }

        [DisplayName("Reviews")]
        [Required]
        [Range(1,5)]
        public int Stars { get; set; }

        [DisplayName("Product Image")]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        public Guid? Cart_Id { get; set; }

        public Cart? Cart { get; set; }
    }
}
