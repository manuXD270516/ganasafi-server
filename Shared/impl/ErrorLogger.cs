using Shared.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.impl
{
    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessage)
        {
            // log the error to your error database
        }
    }
}
