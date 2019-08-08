using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type in timer (format [MM,SS]: ");
            var count = Console.ReadLine();
            var timer = CheckInput(count);
            var numberCount = MinutesToSeconds(timer) + timer[1];
            for (var i = 0; i < numberCount; numberCount--)
            {
                var timeCon = TimerAppearance(numberCount, timer);
                var firstInput = timeCon[0].ToString().PadLeft(2, '0');
                var secondInput = timeCon[1].ToString().PadLeft(2,'0');
                Console.Clear();
                Console.WriteLine("Timer: " + firstInput + ":" +secondInput);
                Thread.Sleep(1000);
            }
        }
        

        public static int[] CheckInput(string input)
        {
            var cutCount = string.IsNullOrEmpty(input) ? new string[0] : input.Split(',');
            var iArray = new int[cutCount.Length];
            for (var i = 0; i < cutCount.Length; i++)
            {
                int.TryParse(cutCount[i], out var result);
                iArray[i] = result;
            }

            return iArray;
        }

        public static int[] TimerAppearance(int time, int[] timer)
        {
            var minuteConvert = SecondsToMinutes(time);
            var spaghetti = minuteConvert.ToString().Split(',');
            float test;
            float result;
            if (spaghetti.Length > 1)
            {
                float.TryParse(spaghetti[0], out test);
                float.TryParse("," + spaghetti[1], out result);

            }
            else
            {
                test = 0;
                float.TryParse(spaghetti[0], out result);

            }
            var backSeconds = result * 60;
            var roundOff = Math.Round(backSeconds, 0);
            var appearance = new int[] {(int)test,(int)roundOff};
            return appearance;
        }

        public static int MinutesToSeconds(int[] time)
        {
            var minutes = time[0];
            var seconds = minutes * 60;
            return seconds;
        }

        public static float SecondsToMinutes(int seconds)
        {
            var minutes = seconds / (float)60;
            return minutes;
        }
    }
}
