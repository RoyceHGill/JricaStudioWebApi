namespace JricaStudioWebApi.Services.Contracts
{
    /// <summary>
    /// Sends Emails Related to the operations of the Web Application
    /// </summary>
    public interface IEmailSenderService
    {
        /// <summary>
        /// Send an email to the administrator to notify them of an event.
        /// </summary>
        /// <param name="email">The Administrators Email</param>
        /// <param name="subject">What the notification is about</param>
        /// <param name="message">The message body of the Notification.</param>
        /// <returns>Task Representing the asynchronous method call.</returns>
        Task SendNotificationEmail(string email, string subject, string message);

        /// <summary>
        /// Send an email to the administrator to complete a password reset.
        /// </summary>
        /// <param name="email">The administrators email</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The message body of the Reset Email</param>
        /// <returns>Task Representing the asynchronous method call.</returns>
        Task SendResetEmail(string email, string subject, string message);

        /// <summary>
        /// Send an email to the administrator from a user who uses the contact page on the website.
        /// </summary>
        /// <param name="fromEmail">The user's email address</param>
        /// <param name="subject">The subject of the communication</param>
        /// <param name="message">The message from the user.</param>
        /// <returns>Task Representing the asynchronous method call.</returns>
        Task SendContactEmail(string fromEmail, string subject, string message);

        /// <summary>
        /// Send an email to the user to notify them that their email has been sent and received. 
        /// </summary>
        /// <param name="toEmail">The users Email</param>
        /// <param name="subject">The Subject of the communication.</param>
        /// <param name="message">The message body of the Email.</param>
        /// <returns>Task Representing the asynchronous method call.</returns>
        Task SentConfirmContactMadeEmail(string toEmail, string subject, string message);

    }
}
