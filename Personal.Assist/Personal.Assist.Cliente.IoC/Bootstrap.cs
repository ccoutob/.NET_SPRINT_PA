using Personal.Assist.Cliente.Application.Services;
using Personal.Assist.Cliente.Data.AppData;
using Personal.Assist.Cliente.Data.Repositories;
using Personal.Assist.Cliente.Domain.Interfaces;
using Personal.Assist.Cliente.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Personal.Assist.Cliente.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            services.AddTransient<IClienteService, ClienteService>();

            services.AddTransient<IClienteRepository, ClienteRepository>();

            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

        }
    }
}
