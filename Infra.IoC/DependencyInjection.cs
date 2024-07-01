using API_NOVA_ERA.Database;
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

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //         options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            //services.AddScoped<IAuthenticate, AuthenticateService>();
            //services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            ////services.AddMediatR(myhandlers);
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}
