using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace Timer2
{
    public class Alarm<T> where T : class
    {
        public string Time { get; set; }
        public string Message { get; set; }
        public T Screen { get; set; }
        public int[] Remains { get; set; }
        public string TimeRemaining { get; set; }

        public Alarm(string time, string message, T value) 
        {
            Time = time;
            Message = message;
            Screen = value;
            CalculateTimeDifference();
        }

        public void ClockHacking()
        {
            var timeRemains = Remains;
            switch (timeRemains[0])
            {
                case 0 when timeRemains[1] == 0 && timeRemains[2] == 0:
                    return;
                default:
                {
                    if (timeRemains[2] > 0) timeRemains[2]--;
                    else if (timeRemains[2] == 0)
                    {
                        timeRemains[1]--;
                        timeRemains[2] = 59;
                    }
                    else if (timeRemains[1] == 0 && timeRemains[0] != 0)
                    {
                        timeRemains[0]--;
                        timeRemains[1] = 59;

                    }
                    else
                    {
                        timeRemains[2]--;
                    }
                    break;
                }
            }
            var text = new StringBuilder();
            for (var i = 0; i < timeRemains.Length; i++)
            {
                text.Append(timeRemains[i].ToString().PadLeft(2, '0'));
                if (i != 2) text.Append(":");
            }

            TimeRemaining = text.ToString();
        }

        public void CalculateTimeDifference()
        {
            var currentTime = ParsInt(Controller.Time().Split(':'));
            var alarmTime = ParsInt(Time.Split(':'));
            var intArray = new int[] {0, 0, 0};
            for (var i = 0; i < currentTime.Length; i++)
            {
                intArray[i] = currentTime[i] - alarmTime[i];
                if (intArray[i] < 0) intArray[i] *= -1;
            }
            Remains = intArray;
        }

        public int[] ParsInt(string[] strings)
        {
            var intList = new List<int>();
            foreach (var number in strings)
            {
                int.TryParse(number, out var result);
                intList.Add(result);
            }

            return intList.ToArray();
        }

        public void Load()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var time = Controller.Time();
            if (Time == time) AlarmSound();
            CommandManager.InvalidateRequerySuggested();
        }

        public static void AlarmSound()
        {
            var player = new SoundPlayer();
            var rootLocation = AppDomain.CurrentDomain.BaseDirectory;
            var fullPathToSound = rootLocation + @"music\alarm.wav";
            player.SoundLocation = fullPathToSound;
            player.LoadAsync();
            player.Play();
        }

    }
}
