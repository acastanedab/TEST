using log4net;
using log4net.Core;
using System;
using log4net;
using log4net.Core;
using System;


namespace Yanbal.SFT.Infrastructure.CrossCutting.Log4Net
{
    public class ErrorAppender : IErrorHandler
    {
        private static readonly ILog Log = LogManager.GetLogger("ErrorDB");

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, Exception e)
        {
            Log.Error(message, e);
        }

        public void Error(string message, Exception e, ErrorCode errorCode)
        {
            Log.Error(message, e);
        }


    }
}
