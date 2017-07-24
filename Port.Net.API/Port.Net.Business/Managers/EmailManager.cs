using Port.Net.Models.Dto;
using System;
using System.Net;
using System.Net.Mail;
using Port.Net.Data.Repositories;
using Port.Net.Models.Dbo;

namespace Port.Net.Business.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly string _myEmail = System.Configuration.ConfigurationManager.AppSettings["myEmail"];
        private readonly string _myEmailPass = System.Configuration.ConfigurationManager.AppSettings["myEmailPass"];
        private readonly IEmailRepository _emailRepository;

        public EmailManager(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }
        public bool SendEmail(EmailModel email)
        {
            //try
            //{
            //    MailMessage mail = new MailMessage(_myEmail, _myEmail);
            //    SmtpClient client = new SmtpClient();
            //    client.EnableSsl = true;
            //    client.Port = 587;
            //    client.UseDefaultCredentials = false;

            //    NetworkCredential nc = new NetworkCredential(_myEmail, _myEmailPass);
            //    client.Credentials = nc;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.UseDefaultCredentials = false;
            //    client.Host = "smtp.gmail.com";
            //    mail.Subject = "New Inquiry - PhoneNumber: " + email.PhoneNumber + "EmailAddress: "+ email.EmailAddress;
            //    mail.Body = email.Message;
            //    client.Send(mail);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    return false;
            //}
            var newEmail = new Email
            {
                EmailAddress = email.EmailAddress,
                Message = email.Message,
                PhoneNumber = email.PhoneNumber,
                Name = email.Name
            };
            _emailRepository.Create(newEmail);
            return true;
        }
    }
}