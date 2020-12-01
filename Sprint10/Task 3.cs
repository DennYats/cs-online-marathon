using System;

namespace Sprint10.Task3
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

                if (ms.ValidEmail() == true)
                {
                    ms.SendNotification();
                    ms.AddNotificationToDB();
                }
            
                SmsService ss = new SmsService();
                ss.Number = "111 111 111";
                ss.SmsText = "User successfully registered...";
            
                ss.SendNotification();
                //ss.AddNotificationToDB();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    interface INotification
    {
        void SendNotification();
    }

    interface INotificationToDB
    {
        void AddNotificationToDB();
    }

    public class MailService : INotification, INotificationToDB
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }

        public bool ValidEmail()
        {
            return Email.Contains("@");
        }

        public void SendNotification()
        {
            Console.WriteLine(string.Format($"Mail:{Email}, Title:{EmailTitle}, Body:{EmailBody}"));
        }

        public void AddNotificationToDB()
        {
            //add to db
        }
    }

    public class SmsService : INotification
    {
        public string Number { get; set; }
        public string SmsText { get;set; }

        public void SendNotification()
        {
            Console.WriteLine(string.Format($"Number:{Number}, Message:{SmsText}"));
        }

        public void AddNotificationToDB()
        {
            throw new NotImplementedException("Not allowed");
        }
    }
}