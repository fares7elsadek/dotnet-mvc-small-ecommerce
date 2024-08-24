using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;
using SmallEcommerceProject.Models.Repositry;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SmallEcommerceProject.Controllers
{
    public class ProductController : Controller
    {
        IProductRepositry IProduct;
        ICartRepositry ICart;
        public ProductController(IProductRepositry IProduct,ICartRepositry ICart)
        {
            this.IProduct = IProduct;
            this.ICart = ICart;
        }

        [Authorize]
        public IActionResult AddProduct()
        {
        
            Guid cart_id = new Guid("7035B26A-EB64-45F7-8967-834F0A36EA17");
            var cart = ICart.GetCartById(cart_id);
            int CartCount = cart.Products.Count();
            ViewData["CartCount"] = CartCount;
            ViewData["Cart"] = cart;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAddProduct(Product product)
        {
            if (ModelState.IsValid) {

                
                
                IProduct.AddProduct(product);
                
                return RedirectToAction("Index", "Home");
            }
            return View("AddProduct", product);
        }

        //public IActionResult UniqueName(string Name)
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        var product = context.Products.FirstOrDefault(p => p.Name == Name);
        //        if (product == null)
        //        {
        //            return Json(true);
        //        }
        //    }
        //    return Json(false);
        //}
    }
}
