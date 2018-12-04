using PumpedUpKicks.Models.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;

namespace PumpedUpKicks.Models.Services
{
    public class SendGridService : ISendGrid
    {
        public static string ApiKey { get; set; }
        
        public SendGridMessage CreateRegisterEmailMessage(string email, string name)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("no-reply@no-reply.com", "PumpedUpKicks"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(email, name)
            };
            msg.AddTos(recipients);

            msg.SetSubject("Welcome to PumpUpKicks");

            msg.AddContent(MimeType.Text, "You have successfully created an account!");
            msg.AddContent(MimeType.Html, "<p>You have successfully created an account!</p>");
            return msg;
        } 

        public async void SendEmail(SendGridMessage msg)
        {
            var client = new SendGridClient(ApiKey);
            Response response = await client.SendEmailAsync(msg);
        }

        public void SendRegisterEmail(string email, string name)
        {
            SendGridMessage msg = CreateRegisterEmailMessage(email, name);
            SendEmail(msg);
        }
    }
}
