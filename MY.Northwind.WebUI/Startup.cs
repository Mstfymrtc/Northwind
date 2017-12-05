using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MY.Northwind.Bal.Abstract;
using MY.Northwind.Bal.Concrete;
using MY.Northwind.Dal.Abstract;
using MY.Northwind.Dal.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using MY.Northwind.WebUI.Entity;
using MY.Northwind.WebUI.Middlewares;
using MY.Northwind.WebUI.Services;

namespace MY.Northwind.WebUI
{
    public class Startup
    {
        //////////////////////////
        //public Startup(IConfiguration configuration) =>
        //    Configuration = configuration;
        //public IConfiguration Configuration { get; }
        //////////////////////////


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ////////////////////////////////
            //services.AddDbContext<NorthwindContext>(options =>
            //    options.UseSqlServer(Configuration["Data:NorthwindMain:ConnectionString"]));
            /////////////////////////////////
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            
               // CustomIdentityUser ve customidentityrole ı kullanarak konfigürasyon yap.




            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseBowerComponents(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(ConfigureRoutes);

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {

            routeBuilder.MapRoute("Default", "{controller=Product}/{Action=Index}/{id?}");
        }
    }
}
