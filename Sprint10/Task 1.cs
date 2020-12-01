using System;

namespace Sprint10.Task1
{
    public class Customer
    {
        MailService ms = new MailService();
        public void Register(string email, string password)
        {
            try
            {
                if (ms.ValidEmail(email))
                    ms.SendEmail(email, "Email Title", "Email body");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class MailService
    {
        public bool ValidEmail(string email)
        {
            return email.Contains("@");
        }

        public void SendEmail(string mail, string emailTitle, string emailBody)
        {
            Console.WriteLine(string.Format($"Mail:{mail}, Title:{emailTitle}, Body:{emailBody}"));
        }
    }
}