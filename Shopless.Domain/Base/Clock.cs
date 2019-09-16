using System;
using System.Collections.Generic;
using System.Text;

namespace Shopless.Base
{
    public class Clock
    {
        public static Func<DateTime> Time { get; set; } = () => DateTime.Now;
    }
}
