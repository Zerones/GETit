using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klokke
{
    public class Alert
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string AlarmMessage { get; set; }
        public  Alert(string time, string alarmMessage)
        {
            var convert = StringToTime(time);
            Hours = convert[0];
            Minutes = convert[1];
            Seconds = convert[2];
            AlarmMessage = alarmMessage;
        }

        public string CombineTime()
        {
            var alertTime = new StringBuilder();
            alertTime.Append(Hours.ToString().PadLeft(2, '0') + ":");
            alertTime.Append(Minutes.ToString().PadLeft(2, '0') + ":");
            alertTime.Append(Seconds.ToString().PadLeft(2,'0'));
            return alertTime.ToString();
        }

        public int[] StringToTime(string time)
        {
            var array = time.Split(':');
            var intArray = new int[array.Length];
            var count = 0;
            foreach (var number in array)
            {
                intArray[count] = int.Parse(number);
                count++;
            }

            return intArray;
        }
    }
}
