using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallEcommerceProject.Models;
using SmallEcommerceProject.Models.Data;
using SmallEcommerceProject.Models.Repositry;

namespace SmallEcommerceProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductRepositry,ProductRepositry>();
            builder.Services.AddScoped<ICartRepositry,CartRepositry>();

            builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
