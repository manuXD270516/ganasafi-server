using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.interfaces
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessage);
    }
}
