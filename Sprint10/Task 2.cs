using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint10.Task2
{
    public class Customer
    {
        public static void Register(string email, string password)
        {
            
            try
            {
                MailService ms = new MailService();
                ms.Email = email;
                ms.EmailTitle = "User registration";
                ms.EmailBody = "Body of message...";
            
                SmsService ss = new SmsService();
                ss.Number = "111 111 111";
                ss.SmsText = "User successfully registered...";
                
                if (ms.ValidEmail() == true)
                {
                    ms.SendNotification();
                    ss.SendNotification();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public abstract class NotificationService
    {
        public abstract void SendNotification();
    }

    public class MailService : NotificationService
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }

        public bool ValidEmail()
        {
            return Email.Contains("@");
        }

        public override void SendNotification()
        {
            Console.WriteLine(string.Format($"Mail:{Email}, Title:{EmailTitle}, Body:{EmailBody}"));
        }
    }

    public class SmsService : NotificationService
    {
        public string Number { get; set; }
        public string SmsText { get;set; }

        public override void SendNotification()
        {
            Console.WriteLine(string.Format($"Number:{Number}, Message:{SmsText}"));
        }
    }
}
