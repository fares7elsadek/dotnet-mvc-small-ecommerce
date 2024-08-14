using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;
using SmallEcommerceProject.ViewModel;
using System.Diagnostics;

namespace SmallEcommerceProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using(var context = new AppDbContext())
            {
                var products = context.Products.ToList();
                Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
                var cart = context.Carts.Include(p => p.Products).FirstOrDefault(c => c.Id == cart_id);
                int CartCount = cart.Products.Count();

                HomeViewModel home = new HomeViewModel();
                home.Products = [..products];
                home.CartCount = CartCount;
                home.Cart = cart;

                return View(home);
            }
        }
    }
}
