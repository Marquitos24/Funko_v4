using System.Reflection;
using Scrutor;

namespace Funkos.Scrutor;

public static class Prueba
{
public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
{
    // Scrutor escanea el ensamblado actual buscando clases que implementen interfaces
    services.Scan(scan => scan
        .FromAssemblies(Assembly.GetExecutingAssembly())
        .AddClasses()
        .AsMatchingInterface()
        .WithScopedLifetime());

    return services;
}
}