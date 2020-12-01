using System;

namespace Sprint10.Task5
{
    public class Customer
    {
        public INotification Notification { get; set; }

        public Customer(INotification notification)
        {
            this.Notification = notification;
        }
   
        public void Register(string email, string password)
        {
        
            try
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SendNotification(INotification notification)
        {
            notification.SendNotification();
        }
    }

    public interface INotification
    {
        void SendNotification();
    }

    interface INotificationToDB
    {
        void AddNotificationToDB();
    }

    interface INotificationToDBRead
    {
        void ReadNotification();
    }

    public class MailService : INotification, INotificationToDB, INotificationToDBRead
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

        public void ReadNotification()
        {
            //read from db
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