using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace AIronMan.Logging
{
    public class NLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception x)
        {
            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            string strErrorMsg = Environment.NewLine + "Error in Path :" + System.Web.HttpContext.Current.Request.Path;
            // Get the QueryString along with the Virtual Path
            strErrorMsg += Environment.NewLine + "Raw Url :" + System.Web.HttpContext.Current.Request.RawUrl;
            // Get the error message
            strErrorMsg += Environment.NewLine + "Message :" + logException.Message;
            // Source of the message
            strErrorMsg += Environment.NewLine + "Source :" + logException.Source;
            // Stack Trace of the error
            strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;
            // Method where the error occurred
            strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;

            Error(strErrorMsg);
        }

        public void Error(string message, Exception x)
        {
            _logger.ErrorException(message, x);
        }
    }
}
