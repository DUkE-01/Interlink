
using Interlink.Core.Application.Dtos.Email;
using Interlink.Core.Domain.Settings;


namespace Interlink.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings MailSettings { get; }
        Task SendAsync(EmailRequest request);
    }
}
