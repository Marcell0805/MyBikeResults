using BikesResponse.Service.Contract;
using BikesResponse.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyBikeResults.Persistence;
using MyBikeResults.Service.Contract;
using MyBikeResults.Service.Implementation;
using System;

namespace MyBikeResults.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("BikeResponseDb") ?? configRoot["ConnectionStrings:InMemoryDb"]
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new CustomerProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //serviceCollection.AddSingleton(mapper);
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
            serviceCollection.AddTransient<IBikeService, BikeService>();
            serviceCollection.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
        }



        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "BikeResults",
                    new OpenApiInfo()
                    {
                        Title = "Bike Response WebAPI",
                        Version = "1",
                        Description = "Through this API you can access bike details",
                        Contact = new OpenApiContact()
                        {
                            Email = "marcellvannniekerk@gmail.com",
                            Name = "Marcell van Niekerk",
                            Url = new Uri("https://github.com/Marcell0805")
                        }
                    });
            });

        }
        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
