using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGuidance.Application.Contracts;
using StudentGuidance.Application.Services;
using StudentGuidance.Infrastructure.Context;
using StudentGuidance.Infrastructure.Interfaces;
using StudentGuidance.Infrastructure.Repositories;

namespace StudentGuidance.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StudentGuidanceContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IEstudianteRepository, EstudianteRepository>();
        services.AddScoped<IOrientadorRepository, OrientadorRepository>();
        services.AddScoped<ICitaRepository, CitaRepository>();
        services.AddScoped<ISeguimientoRepository, SeguimientoRepository>();

        services.AddScoped<IEstudianteService, EstudianteService>();
        services.AddScoped<IOrientadorService, OrientadorService>();
        services.AddScoped<ICitaService, CitaService>();
        services.AddScoped<ISeguimientoService, SeguimientoService>();

        return services;
    }
}