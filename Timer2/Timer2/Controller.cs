using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;

namespace Timer2
{
    public class Controller
    {
        public static string Time()
        {
            var time = DateTime.Now;
            var timeString = time.ToString(CultureInfo.InvariantCulture).Split(' ');
            return timeString[1];
        }
    }
}
