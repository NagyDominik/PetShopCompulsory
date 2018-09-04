using Microsoft.Extensions.DependencyInjection;
using PetShopCompulsory.Core;
using PetShopCompulsory.Core.ApplicationService;
using PetShopCompulsory.Core.ApplicationService.Impl;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Infrastructure.Static.Data;
using PetShopCompulsory.Infrastructure.Static.Data.Repositories;
using System;

namespace PetShopCompulsory
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petservice = serviceProvider.GetRequiredService<IPetService>();
            var printer = new Printer(petservice);
            printer.StartUp();
        }
    }
}
