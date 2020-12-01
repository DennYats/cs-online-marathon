using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint10.Task7
{
    public class Invoice
    {
        MailSender ms = new MailSender();

        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public void FileLogger()
        {
            // Code for initialization i.e. Creating Log file with specified  
            // details
        }
        public void Add()
        {
            Console.WriteLine("Adding amount...");
            // Code for adding invoice
            // Once Invoice has been added , send mail 
            string mailMessage = "Your invoice is ready.";
            ms.SendEmail(mailMessage);
        }
        public void Delete()
        {
            Console.WriteLine("Deleting amount...");
            // Code for Delete invoice
        }
        
    }

    interface IFileLogger
    {
        void Check();
        void Debug();
        void Info();
    }

    public class FileLogger : IFileLogger
    {
        public void Check() { }
        public void Debug() { }
        public void Info() { }
    }

    public class MailSender
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public void SendEmail(string mailMessage)
        {
            Console.WriteLine("Sending Email: {0}", mailMessage);
            // Code for getting Email setting and send invoice mail
        }
    }
}
