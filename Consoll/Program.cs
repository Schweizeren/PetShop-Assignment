using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using PetShop_Assignment.Core.Core.ApplicationService;
using PetShop_Assignment.Core.Core.ApplicationService.impl;
using PetShop_Assignment.Core.Core.DomainService;
using System;

namespace Consoll
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FakeDB.initializeData();

            ServiceCollection serviceCollector = new ServiceCollection();
            serviceCollector.AddScoped<IPetRepository, PetRepository>();
            serviceCollector.AddScoped<IPetService, PetService>();
            serviceCollector.AddScoped<IPrinter, Printer >();

            ServiceProvider serviceProvider= serviceCollector.BuildServiceProvider();
            IPrinter printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.RunUI();
        }
    }
}
