using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TARge24_Car_Test.Mock;
using TARge24_Car_Test.Macros;
using Car_TARge24.Data;
using Car_TARge24.Core.ServiceInterface;
using Car_TARge24.ApplicationServices.Services;
using Microsoft.EntityFrameworkCore.InMemory;

namespace TARge24_Car_Test
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();

        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();

            services.AddDbContext<Car_TARge24Context>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
            // Resolve service from the service provider
            return serviceProvider.GetService<T>();
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(t => macroBaseType.IsAssignableFrom(t)
                && !t.IsInterface && !t.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }

    }
}

