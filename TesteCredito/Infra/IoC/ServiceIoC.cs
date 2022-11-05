using CreditoApplication.Services.Creditos;
using CreditoApplication.Services.Interfaces;
using CreditoApplication.Services.Users;
using CreditoApplication.Shared.AutoMapper;
using CreditoApplication.Shared.Creditos.Repository;
using CreditoApplication.Shared.Users.Repository;
using DataServices.Creditos.Repository;
using DataServices.Users.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class ServiceIoC
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddAutoMapper(config => config.AddProfile<ModelToViewModel>());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaxaJurosRepository, TaxaJurosRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICreditoService, CreditoService>();
        }
    }
}