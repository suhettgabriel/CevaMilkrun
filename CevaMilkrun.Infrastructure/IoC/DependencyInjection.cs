using CevaMilkrun.Domain.Interfaces;
using CevaMilkrun.Infrastructure.ExternalServices.Implementations;
using CevaMilkrun.Infrastructure.ExternalServices.Refit;
using CevaMilkrun.Infrastructure.Persistence.Contexts;
using CevaMilkrun.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace CevaMilkrun.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(sqlConnection));

            services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();

            var redisConnection = configuration.GetConnectionString("RedisConnection");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnection;
                options.InstanceName = "CevaMilkrun:";
            });

            var cevaBaseUrl = configuration["CevaApi:BaseUrl"];

            services.AddRefitClient<ICevaMilkrunApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(cevaBaseUrl!));

            services.AddScoped<IMilkrunExternalService, MilkrunExternalService>();

            return services;
        }
    }
}