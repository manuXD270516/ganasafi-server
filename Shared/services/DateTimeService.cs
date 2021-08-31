using Application.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime nowUtc() => DateTime.UtcNow;
    }
}
