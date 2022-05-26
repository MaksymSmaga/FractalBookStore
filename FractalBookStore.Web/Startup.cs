using FractalBookStore.Domain.Services;
using FractalBookStore.Memory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FractalBookStore.Data.EF;

namespace FractalBookStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // To declare Dependency injection.
            // services.AddSingleton<IBookRepository,MockBookRepository>();
            // services.AddSingleton<IOrderRepository, OrderRepository>();

            // To declare of BookService - search servise.
            // services.AddSingleton<BookService>();

            // Cart Data in cash
            services.AddDistributedMemoryCache();


             

            // To use Sessions.
            services.AddSession(options =>
            {
                // Time term of the session.
                options.IdleTimeout = System.TimeSpan.FromMinutes(60);
                
                // To get from server side.
                options.Cookie.HttpOnly = true;

                // Protect personal data.
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // To connect session.
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
