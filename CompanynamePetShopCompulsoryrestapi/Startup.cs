using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PetShop.Infrastructure.Data;
using PetShopCompulsory.Core;
using PetShopCompulsory.Core.ApplicationService;
using PetShopCompulsory.Core.ApplicationService.Impl;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Infrastructure.Data;
using PetShopCompulsory.Infrastructure.Data.SQL_Repositories;

namespace CompanynamePetShopCompulsoryrestapi
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
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerService, OwnerService>();
            //services.AddDbContext<PetShopCompulsoryContext>(opt => opt.UseInMemoryDatabase("DBOne"));

            services.AddDbContext<PetShopCompulsoryContext>(opt => opt.UseSqlite("Data Source=petshop.db"));

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();

                using (IServiceScope scope = app.ApplicationServices.CreateScope()) {
                    PetShopCompulsoryContext ctx = scope.ServiceProvider.GetService<PetShopCompulsoryContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
