using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
namespace BilisselBeceriler.LoggerService
{
    public class Logger
    {        
        protected Logger()
        {

        }

        static LogWriter logWriter 
        { 
            get 
            { 
                return EnterpriseLibraryContainer.Current.GetInstance<LogWriter>(); 
            } 
        }

        public static void Write(string Message)
        {
            if (logWriter.IsLoggingEnabled())
            {
                logWriter.Write(Message);
            }
        }

        public static void Write(object Message,string Category)
        {
            if (logWriter.IsLoggingEnabled())
            {
                logWriter.Write(Message,Category);
            }
        }

        public static void Write(LogEntry Entry)
        {
            if (logWriter.IsLoggingEnabled())
            {
                logWriter.Write(Entry);
            }
        }
    }
}
