using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Interlink.Core.Application
{
    public static class  ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
