using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using PetShop_Assignment.Core.Core.ApplicationService;
using PetShop_Assignment.Core.Core.ApplicationService.impl;
using PetShop_Assignment.Core.Core.DomainService;
using System;

namespace Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.initializeData();

            var serviceCollector = new ServiceCollection();
            serviceCollector.AddScoped<IPetRepository, PetRepository>();
            serviceCollector.AddScoped<IPetService, PetService>();
            serviceCollector.AddScoped<IPrinter, Printer >();

            var serviceProvider = serviceCollector.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            new Printer(petService);

            Console.ReadLine();
        }
    }
}
