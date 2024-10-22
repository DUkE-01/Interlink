using Interlink.Core.Domain.Settings;
using Interlink.Infrastructure.Shared.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interlink.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<EmailService, EmailService>();

        }
    }
}
