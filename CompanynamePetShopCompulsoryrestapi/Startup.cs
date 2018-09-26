using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<CustomerAppContext>(
            //    opt => opt.UseInMemoryDatabase("ThaDB")
            //    );

            if (_env.IsDevelopment()) {
                services.AddDbContext<PetShopCompulsoryContext>(
                    opt => opt.UseSqlite("Data Source=customerApp.db"));
            }
            else if (_env.IsProduction()) {
                services.AddDbContext<PetShopCompulsoryContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var ctx = scope.ServiceProvider.GetService<PetShopCompulsoryContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else {
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var ctx = scope.ServiceProvider.GetService<PetShopCompulsoryContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

}
