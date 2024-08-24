using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.ViewModel;
using System.Security.Claims;

namespace SmallEcommerceProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> SignInManager)
        {
            this.userManager = userManager;
            signInManager = SignInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newRegister)
        {
            if (ModelState.IsValid) {
                ApplicationUser newUser = new();
                newUser.UserName = newRegister.UserName;
                newUser.PasswordHash = newRegister.PasswordHash;
                newUser.Address = newRegister.Address;
                IdentityResult result = await userManager.CreateAsync(newUser,newUser.PasswordHash);
                if (result.Succeeded)
                {
                    // Create Cookie
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("color", "red"));
                    await signInManager.SignInWithClaimsAsync(newUser,true,claims);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {

                        ModelState.AddModelError("Password", item.Description);

                    }
                }
            }
            return View();
        }
    }
}
