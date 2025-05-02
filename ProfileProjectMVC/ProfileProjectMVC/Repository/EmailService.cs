using ProfileProjectMVC.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace ProfileProjectMVC.Repository
{
    public class EmailService
    {
        public bool sendEmail(Email email)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(email.EmailId);
                mailMessage.To.Add("contact.ravinderyadav@gmail.com");
                mailMessage.CC.Add("ravinderyadav347@gmail.com");
                mailMessage.CC.Add("ravinderyadav347@outlook.com");
                mailMessage.Subject = string.Concat("Enquery from ravinder profile:- ", email.Subject);
                mailMessage.Body = email.EmailBody;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("contact.ravinderyadav@gmail.com", "lgkvxhgextymahso");
                smtpClient.EnableSsl = true;
                //smtpClient.Host = "webmail.ravinderyadav.in";
                //smtpClient.Port = 25;
                //smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new NetworkCredential("contact@ravinderyadav.in", "sCpX2ls44kz*Ozlh");
                //smtpClient.EnableSsl = false;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}