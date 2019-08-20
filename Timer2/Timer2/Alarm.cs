using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Input;

namespace Timer2
{
    public class Alarm
    {
        public string Time { get; set; }
        public string Message { get; set; }
        public MainWindow Screen { get; set; }

        public Alarm(string time, string message, MainWindow screen)
        {
            Time = time;
            Message = message;
            Screen = screen;
        }

        public void Load(MainWindow screen)
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var time = Controller.Time();
            if(Time == time) AlarmSound();
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
