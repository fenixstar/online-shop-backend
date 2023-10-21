using System.Threading.Tasks;
using EASendMail;
using online_shop_backend.Services.Interfaces;

namespace online_shop_backend.Services.Implementations;

public class MailService : IMailService
{
    public async Task SendEmailAsync(string emailTo, string nameTo, string subject, string message)
    {
        var oMail = new SmtpMail("TryIt")
        {
            From = "noreply@vetuniverse.ru",
            To = emailTo,
            Subject = subject,
            TextBody = message
        };

        // Gmail SMTP server address
        var oServer = new SmtpServer("smtp.gmail.com")
        {
            User = "gavrikovantonsergeevich@gmail.com",
            // https://support.google.com/accounts/answer/185833?hl=en
            Password = "upje cwoi rqhg hgby",
            Port = 465,
            ConnectType = SmtpConnectType.ConnectSSLAuto
        };

        var oSmtp = new SmtpClient();
        await oSmtp.SendMailAsync(oServer, oMail);
    }
}