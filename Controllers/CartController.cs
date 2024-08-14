using Microsoft.AspNetCore.Mvc;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;

namespace SmallEcommerceProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddToCart(Guid Id)
        {
            using(var context = new AppDbContext())
            {
                Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
                var cart = context.Carts.FirstOrDefault(c => c.Id == cart_id);
                var product = context.Products.FirstOrDefault(p => p.Id == Id);
                cart.TotalPrice += product.Price;
                cart.Products.Add(product);
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
