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
            
            services.AddTransient<IEmailService, EmailService>();
            
            services.AddScoped<IPasswordChangeRepository, PasswordChangeRepository>();
            services.AddScoped<IPasswordChangeService, PasswordChangeService>();
            
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IPermissaoService, PermissaoService>();
            
            services.AddScoped<IPermissaoCargoRepository, PermissaoCargoRepository>();
            services.AddScoped<IPermissaoCargoService, PermissaoCargoService>();
            
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICursoService, CursoService>();
     
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IProfessorService, ProfessorService>();
          
            services.AddScoped<IGeneroService, GeneroService>();

            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaService, TurmaService>();

            services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();
            services.AddScoped<ITurmaAlunoService, TurmaAlunoService>();

            services.AddScoped<IAulaRepository, AulaRepository>();
            services.AddScoped<IAulaService, AulaService>();

            services.AddScoped<IFrequenciaRepository, FrequenciaRepository>();
            services.AddScoped<IFrequenciaService, FrequenciaService>();

            services.AddScoped<IConteudoRepository, ConteudoRepository>();
            services.AddScoped<IConteudoService, ConteudoService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<ICertificadoRepository, CertificadoRepository>();
            services.AddScoped<ICertificadoService, CertificadoService>();

            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IMatriculaService, MatriculaService>();

            services.AddAutoMapper(typeof(UsuarioMapping));
            services.AddAutoMapper(typeof(CargoMapping));
            services.AddAutoMapper(typeof(CargoUsuarioMapping));
            services.AddAutoMapper(typeof(PasswordChangeMapping));
            services.AddAutoMapper(typeof(PermissaoMapping));
            services.AddAutoMapper(typeof(PermissaoCargoMapping));
            services.AddAutoMapper(typeof(TurmaAlunoMapping));
            services.AddAutoMapper(typeof(CursoMapping));
            services.AddAutoMapper(typeof(TurmaMapping));
            services.AddAutoMapper(typeof(AulaMapping));
            services.AddAutoMapper(typeof(FrequenciaMapping));
            services.AddAutoMapper(typeof(ConteudoMapping));
            services.AddAutoMapper(typeof(CertificadoMapping));
            services.AddAutoMapper(typeof(MatriculaMapping));

            return services;
        }
    }
}
