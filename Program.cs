using Pluralsight.AspNetCore.BethanysPie.Models;

namespace Pluralsight.AspNetCore.BethanysPie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            builder.Services.AddScoped<IPieRepository, MockPieRepository>();

            builder.Services.AddControllersWithViews();  // enables MVC

            var app = builder.Build();

            #region Middleware Components
            /// <summary>
            /// Middleware components pipeline.
            /// </summary>
            app.UseStaticFiles();  // support for returning static files

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // enables the developers exception page
            }

            app.MapDefaultControllerRoute();  // sets MVC defaults to route to views
            #endregion

            app.Run();
        }
    }
}
