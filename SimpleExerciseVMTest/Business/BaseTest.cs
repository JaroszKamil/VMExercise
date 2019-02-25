using AutoMapper;
using BusinessLayer;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleExerciseVMTests
{
    public class BaseTest
    {
        public ICustomerService service {get;set;}

        public BaseTest()
        {
            var t = this;
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            services.AddDbContext<VMDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("VMCustomersDBConnection")));

            //services.AddScoped<IMapper, Mapper>();

            services.AddAutoMapper();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
      
            service = serviceProvider.GetService<ICustomerService>();
        }
    
    }
}
