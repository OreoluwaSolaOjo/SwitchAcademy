using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwitchAcademy.Services.Implementations
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private string _host;
        private string _password;
        private string _email;
        private int _port;
        private string _name;
        private string _subject;
        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _port = _configuration.GetValue<int>("MailSettings:Port");
            _password = _configuration.GetSection("MailSettings:Password").Value;
            _host = _configuration.GetSection("MailSettings:Host").Value;
            _name = _configuration.GetSection("MailSettings:DisplayName").Value;
            _email = _configuration.GetSection("MailSettings:Mail").Value;
            _subject = _configuration.GetSection("MailSettings:Subject").Value;
        }
        public async Task SendEmail(SendEmailDto request)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_email, _name)
                };
                mail.To.Add(new MailAddress(request.ToEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = request.Subject;
                mail.Body = request.Body;
                mail.IsBodyHtml = false;
                //mail.Priority = MailPriority.High;

                //using (SmtpClient smtp = new SmtpClient(_host, _port))
                //{
                //    smtp.Credentials = new NetworkCredential(_email, _password);
                //    smtp.EnableSsl = true;
                //    await smtp.SendMailAsync(mail);
                //}

                using (var client = new SmtpClient
                {
                    Port = _port,
                    Host = _host,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential
                    {
                        Password = _password,
                        UserName = _email
                    },
                    EnableSsl = true,

                })
                {
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }
    }
}

