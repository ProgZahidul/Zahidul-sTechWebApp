using Microsoft.AspNetCore.Identity.UI.Services;

namespace Zahidul_s_Tech_Emporium.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
