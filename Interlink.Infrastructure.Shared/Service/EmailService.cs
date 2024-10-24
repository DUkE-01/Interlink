﻿using Interlink.Core.Application.Dtos.Email;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Domain.Settings;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;


namespace Interlink.Infrastructure.Shared.Service
{
    public class EmailService : IEmailService
    {
        public MailSettings MailSettings { get; }

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            MailSettings = mailSettings.Value;
        }
        

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? MailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(MailSettings.SmtpHost, MailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(MailSettings.SmtpUser, MailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);


            }
            catch (Exception)
            {

            }
        }

    }
}

