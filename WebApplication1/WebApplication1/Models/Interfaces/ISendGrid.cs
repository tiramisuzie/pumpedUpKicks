using SendGrid.Helpers.Mail;

namespace PumpedUpKicks.Models.Interfaces
{
    public interface ISendGrid
    {
        SendGridMessage CreateRegisterEmailMessage(string email, string name);

        void SendEmail(SendGridMessage msg);

        void SendRegisterEmail(string email, string name);
    }
}
