using Microsoft.Extensions.DependencyInjection;
using PetShopCompulsory.Core;
using PetShopCompulsory.Core.ApplicationService.Impl;
using PetShopCompulsory.Core.DomainService;
using PetShopCompulsory.Infrastructure.Static.Data;
using System;

namespace PetShopCompulsory
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUp();
        }
    }
}
