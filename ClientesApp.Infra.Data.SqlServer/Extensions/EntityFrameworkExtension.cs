using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Services;
using ClientesApp.Infra.Data.SqlServer.Contexts;
using ClientesApp.Infra.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientesApp.Infra.Data.SqlServer.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções de dependência
    /// do projeto Infra.Data e do EntityFramework
    /// </summary>
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ClientesApp");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            //injeções de dependência
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();

            return services;
        }
    }
}
