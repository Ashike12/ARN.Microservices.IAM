using Application.Abstraction.UseCase;
using Application.UseCases.LogIn;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection services)
        {
            var registrations =
                (from type in typeof(LogInUseCase).Assembly.GetExportedTypes()
                 where type.BaseType != null
                 where type.IsInterface == false
                 where (type.GetInterfaces().Contains(typeof(IUseCase)))
                 from service in type.GetInterfaces()
                 where !service.Equals(typeof(IUseCase))
                 select new { service, implementation = type }).ToArray();

            foreach (var item in registrations)
            {
                services.Add(new ServiceDescriptor(item.service, item.implementation, ServiceLifetime.Transient));
            }

            return services;
        }
    }
}
