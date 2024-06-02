using Microsoft.EntityFrameworkCore;
using Pluralsight.AspNetCore.BethanysPie.Models;

namespace Pluralsight.AspNetCore.BethanysPie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPieRepository, PieRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllersWithViews();  // enables MVC
            builder.Services.AddRazorPages();  // enables Razor Pages

            builder.Services.AddDbContext<BethanysPieDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieDbContextConnection"]);
            });

            var app = builder.Build();

            #region Middleware Components
            /// <summary>
            /// Middleware components pipeline.
            /// </summary>
            app.UseStaticFiles();  // support for returning static files
            app.UseSession();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // enables the developers exception page
            }

            app.MapDefaultControllerRoute();  // sets MVC defaults to route to views
            app.MapRazorPages();  // enables Razor Pages models
            #endregion

            DbInitialiser.Seed(app);

            app.Run();
        }
    }
}
