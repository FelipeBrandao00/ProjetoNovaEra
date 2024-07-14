using API_NOVA_ERA.Database;
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

            services.AddAutoMapper(typeof(UsuarioMapping));

            return services;
        }
    }
}
