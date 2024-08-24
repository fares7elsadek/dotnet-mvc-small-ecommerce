using Microsoft.AspNetCore.Mvc;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;
using SmallEcommerceProject.Models.Repositry;

namespace SmallEcommerceProject.Controllers
{
    public class CartController : Controller
    {
        IProductRepositry IProduct;
        ICartRepositry ICart;
        public CartController(IProductRepositry IProduct, ICartRepositry ICart)
        {
            this.IProduct = IProduct;
            this.ICart = ICart;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(Guid Id)
        {
            using(var context = new AppDbContext())
            {
                Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
                var cart = ICart.GetCartById(cart_id);
                var product = IProduct.GetProductsById(Id);
                ICart.UpdatCartPrice(cart_id,product.Price);
                ICart.AddProductToCart(product, cart_id);
                context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
