using log4net.Core;
using System;

namespace Yanbal.SFT.Infrastructure.CrossCutting.Log4Net
{
    public interface IErrorHandler
    {
        void Error(string message, Exception e, ErrorCode errorCode);
        void Error(string message, Exception e);
        void Error(string message);
    }
}
