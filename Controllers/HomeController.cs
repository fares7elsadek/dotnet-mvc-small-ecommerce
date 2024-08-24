using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;
using SmallEcommerceProject.Models.Repositry;
using SmallEcommerceProject.ViewModel;
using System.Diagnostics;

namespace SmallEcommerceProject.Controllers
{
    public class HomeController : Controller
    {
        IProductRepositry IProduct;
        ICartRepositry ICart;
        public HomeController(IProductRepositry IProduct, ICartRepositry ICart)
        {
            this.IProduct = IProduct;
            this.ICart = ICart;
        }
        public IActionResult Index()
        {
            var products = IProduct.GetProducts();
            Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
            var cart = ICart.GetCartById(cart_id);
            int CartCount = cart.Products.Count();
            HomeViewModel home = new HomeViewModel();
            home.Products = [..products];
            home.CartCount = CartCount;
            home.Cart = cart;

            return View(home);
           
        }
    }
}
