using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net.Mime;

namespace EmailNotifierWindowsService
{
    class EmailService 
    { 
       public void sendMail(List<String> emails)
        {
            try
            {
                foreach (string x in emails)
                {
                    MailMessage mailMsg = new MailMessage();

                    // To
                    mailMsg.To.Add(new MailAddress(x, "User"));

                    // From
                    mailMsg.From = new MailAddress("cmentarz@cmentarz.pl", "Admin");

                    // Subject and multipart/alternative Body
                    mailMsg.Subject = "Przypomnienie o zapłaceniu prolongaty";
                    string text = "Za mniej niż 30 dni termin prolongaty upłynie. Proszę uregulować opłaty" + Environment.NewLine + "Z wyrazami szacunku administracja cmentarza";
                    string html = @"<p>Przypominamy o uiszczeniu oplaty </p>";
                    mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                    mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                    // Init SmtpClient and send
                    SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("osek", "projekt86");
                    smtpClient.Credentials = credentials;

                    smtpClient.Send(mailMsg);
                    System.Threading.Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
