using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

namespace BirthdayMailer
{
    class Mailer
    {
        
        public void SendEmail(Dictionary<string,string> emailList)
        {
            
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new NetworkCredential("hiteshram.kotha@gmail.com", "Hitesh@1");
            client.EnableSsl = true;
            foreach (var people in emailList)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hiteshram.kotha@gmail.com");
                mail.To.Add(people.Value);
                mail.Subject = "Happy Birthday!!";
                mail.Body = "Hi " + people.Key + ", Many more happy returns of the day";
                client.Send(mail);
            }
        }
    }
}
