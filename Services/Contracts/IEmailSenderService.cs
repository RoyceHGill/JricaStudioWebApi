namespace JricaStudioWebAPI.Services.Contracts
{
    public interface IEmailSenderService
    {
        Task SendNotificationEmail( string email, string subject, string message );
        Task SendResetEmail( string email, string subject, string message );
        Task SendContactEmail( string fromEmail, string subject, string message );
        Task SentConfirmContactMadeEmail( string toEmail, string subject, string message );
    }
}
