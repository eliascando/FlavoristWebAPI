using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Comunication.Mail;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Application.Services
{
    public class SenderService
        : IServiceSender<string, string, string>
    {
        private readonly IOptions<MailConfig> _mailConfig;

        public SenderService(IOptions<MailConfig> mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public async Task<bool> Send(string to, string msg, string sub)
        {
            try
            {
                // Crea un objeto MailMessage para el correo electrónico
                using (var mail = new MailMessage())
                { 
                    mail.From = new MailAddress(_mailConfig.Value.Email);
                    mail.To.Add(to);
                    mail.Subject = sub;
                    mail.Body = msg;
                    mail.IsBodyHtml = true; // Indica que el cuerpo del correo electrónico es HTML

                    // Configura el cliente de SMTP para el envío del correo electrónico
                    using (SmtpClient client = new SmtpClient(_mailConfig.Value.Host, _mailConfig.Value.Port))
                    {
                        client.Credentials = new NetworkCredential(_mailConfig.Value.Email, _mailConfig.Value.Password);
                        client.EnableSsl = _mailConfig.Value.UseSSL;
                        await client.SendMailAsync(mail); // Envía el correo electrónico
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);  // Lanza una excepción con el mensaje de error si ocurre alguna excepción durante el envío del correo electrónico
            }
        }
    }
}
