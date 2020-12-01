using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sprint10.Task10
{
    public interface ILogger
    {
        void LogMessage(string message);
    }

    public class DbLogger : ILogger
    {
        public void LogMessage(string mMessage)
        {
            //Code to write message in database.  
        }
    }

    public class FileLogger : ILogger
    {
        public void LogMessage(string mStackTrace)
        {
            //code to log stack trace into a file.  
        }
    }

    public class ExceptionLogger
    {
        ILogger _logger;

        public ExceptionLogger(ILogger logger)
        {
            this._logger = logger;
        }

        public void LogException(Exception mException)
        {
            _logger.LogMessage(GetUserReadableMessage(mException));
        }
        private string GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user   
            // readable format.  
            return strMessage;
        }
    }

    public class DataExporter
    {
        ILogger _logger;

        public DataExporter(ILogger logger)
        {
            this._logger = logger;
        }

        public void ExportDataFromFile()
        {
            try
            {
                //code to export data from files to database.  
            }
            catch (Exception ex)
            {
                new ExceptionLogger(_logger).LogException(ex);
            }
        }
    }
}
