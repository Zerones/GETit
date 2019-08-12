using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Klokke
{
    class Program
    {
        static void Main(string[] args)
        {
            Alert();
        }

        public static void Alert()
        {
            var list = new List<Alert>();
            while (true) //Stage 1 setting alarms
            {
                Console.Clear();
                Console.WriteLine("Alarm list:");
                foreach (var alarm in list) Console.WriteLine(alarm.AlarmMessage);
                Console.Write("Add as many alarms at you would like (Format: HH:MM:SS <Alert Message>):");
                var messageString = new StringBuilder();
                var inputArray = Input();
                if (inputArray[0].ToLower() == "start") break;
                foreach (var t in inputArray) messageString.Append(t + " ");
                var alert = new Alert(inputArray[0], messageString.ToString());
                list.Add(alert);
            }
            Clock(list);
        }

        public static void Clock(List<Alert> list)
        {
            var alertList = AlarmingList(list);
            var expiredAlerts = new List<string>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Distillation());
                var alert = CheckAlertTime(alertList);
                if(!string.IsNullOrEmpty(alert)) expiredAlerts.Add(alert);
                Console.WriteLine("Expired Alerts:");
                foreach (var exAlert in expiredAlerts) Console.WriteLine(exAlert);
                Thread.Sleep(999);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public static string CheckAlertTime(List<string> list)
        {
            var currentTime = Distillation();
            foreach (var alert in list)
            {
                if (currentTime != alert) continue;
                Console.WriteLine("Alarm:" + alert + " Has been triggered");
                return alert;
            }

            return null;
        }


        public static List<string> AlarmingList(List<Alert> list)
        {
            var alertList = new List<string>();
            foreach (var alert in list)
            {
                alertList.Add(alert.CombineTime());
            }

            return alertList;
        }

        public static string[] Input()
        {
            var input = Console.ReadLine();
            var inputArray = input?.Split(' ');
            return inputArray;
        }

        public static string Distillation()
        {
            var tid = System.DateTime.Now;
            var test = tid.ToString(CultureInfo.InvariantCulture).Split(' ');
            var test2 = test[1];
            return test2;
        }
    }
}
