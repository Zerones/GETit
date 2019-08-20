using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
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

        public static void SoundAlarm()
        {
            var player = new SoundPlayer();
            var rootLocation = typeof(Program).Assembly.Location;
            var fullPathToSound = rootLocation.Replace("Klokke.exe", @"music\alarm.wav");
            player.SoundLocation = fullPathToSound;
            player.LoadAsync();
            player.Play();
        }

        public static void Alert()
        {
            var list = new List<Alert>();
            while (true) 
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
            var expiredAlerts = new List<Alert>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Distillation());
                var alert = CheckAlertTime(list);
                if(alert != null) expiredAlerts.Add(alert);
                Console.WriteLine("Expired Alerts:");
                foreach (var exAlert in expiredAlerts) Console.WriteLine("<------" + exAlert.AlarmMessage + "------>");
                Thread.Sleep(900);
            }
        }

        public static Alert CheckAlertTime(List<Alert> list)
        {
            var currentTime = Distillation();
            foreach (var alert in list)
            {
                if (currentTime != alert.CombineTime()) continue;
                Thread.Sleep(100);
                SoundAlarm();
                return alert;
            }

            return null;
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
