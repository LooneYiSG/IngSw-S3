using IngSw_Domain.Interfaces;
using IngSw_Infraestructure.Transversal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IngSw_Infraestructure.Transversal;

public static class ServiceExtensions
{ 
    public static void AddInfraestructureTransversalServices(this IServiceCollection services)
    {
        services.AddScoped<ISocialWorkServiceApi, SocialWorkServiceApi>();
    }
}
