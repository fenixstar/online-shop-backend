using System.Threading.Tasks;

namespace online_shop_backend.Services.Interfaces;

public interface IMailService
{
    public Task SendEmailAsync(string emailTo, string nameTo, string subject, string message);
}