using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;

namespace SmallEcommerceProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult AddProduct()
        {
            using(var context = new AppDbContext())
            {
                Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
                var cart = context.Carts.Include(p => p.Products).FirstOrDefault(c => c.Id == cart_id);
                int CartCount = cart.Products.Count();
                ViewData["CartCount"] = CartCount;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAddProduct(Product product)
        {
            using(var context = new AppDbContext())
            {
                var products = context.Products;
                products.Add(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
