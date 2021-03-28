using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGenerator;

namespace UnitTests
{
    class TimeStub : ITime
    {
        public DateTime Now { get; set; }

        public TimeStub(DateTime time)
        {
            Now = time;
        }
    }
}
