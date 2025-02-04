using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;      



namespace MovieApp.Web
{

   

    public class Startup
    {
     

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            services.AddMvc();
            // Add controllers to the services
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //wwwroot

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                

                endpoints.MapControllerRoute(
                    
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"


                    );










            });
        }
    }
}
