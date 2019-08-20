using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Timer2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Alarm> AlarmList { set; get; }

        public MainWindow()
        {
            InitializeComponent();
            AlarmList = new List<Alarm>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var alarmTime = AlarmInput.Text;
            var message = Messageboxx.Text;
            var newAlarm = new Alarm(alarmTime, message, this);
            AlarmList.Add(newAlarm);
            UpdateGridList();
        }

        private void UpdateGridList()
        {
            GuiListAlarm.Items.Clear();
            foreach (var alarm in AlarmList)
            {
                GuiListAlarm.Items.Add(alarm.Time + " " + alarm.Message);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var alarm in AlarmList)
            {
                alarm.Load(this);
            }
            TimerDisplay();
            DynamicTimer.Text = Controller.Time();
            Screen1.IsEnabled = false;
            Screen2.IsEnabled = true;
            Screen1.Visibility = Visibility.Hidden;
            Screen2.Visibility = Visibility.Visible;
        }

        private void TimerDisplay()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var time = Controller.Time();
            DynamicTimer.Text = time;
            CommandManager.InvalidateRequerySuggested();
        }

        private void Messageboxx_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Messageboxx.Text != "     <Message>") return;
            Messageboxx.Foreground = Brushes.Black;
            Messageboxx.Text = "";

        }

        private void AlarmInput_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AlarmInput.Text != "<HH:MM:SS>") return;
            AlarmInput.Foreground = Brushes.Black;
            AlarmInput.Text = "";

        }

        private void AlarmInput_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AlarmInput.Text != "") return;
            AlarmInput.Foreground = new SolidColorBrush(Color.FromArgb(255, 137, 137, 137));
            AlarmInput.Text = "<HH:MM:SS>";
        }

        private void Messageboxx_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Messageboxx.Text != "") return;
            Messageboxx.Foreground = new SolidColorBrush(Color.FromArgb(255, 137, 137, 137));
            Messageboxx.Text = "     <Message>";
        }
    }
}
