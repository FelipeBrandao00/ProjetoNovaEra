using API_NOVA_ERA.Database;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
       IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            
            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            
            services.AddScoped<IJwtService, JwtService>();
            
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICargoService, CargoService>();
            
            services.AddScoped<ICargoUsuarioRepository, CargoUsuarioRepository>();
            services.AddScoped<ICargoUsuarioService, CargoUsuarioService>();
            
            
            services.AddAutoMapper(typeof(UsuarioMapping));
            services.AddAutoMapper(typeof(CargoMapping));
            services.AddAutoMapper(typeof(CargoUsuarioMapping));



            return services;
        }
    }
}
