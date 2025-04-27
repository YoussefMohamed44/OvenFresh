namespace MVC_Project.Services
{
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetLink)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("noreply@yourapp.com", "Your App Name");
            var to = new EmailAddress(email);
            var subject = "Password Reset Request";
            var htmlContent = $@"
            <h2>Password Reset</h2>
            <p>Click the link below to reset your password:</p>
            <a href='{resetLink}'>{resetLink}</a>
            <p>This link will expire in 1 hour.</p>
        ";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
