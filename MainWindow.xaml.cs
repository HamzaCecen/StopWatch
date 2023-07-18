using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace TimeMeasure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dt;
        //private DateTime displayTime;
        private const string displaytime = "00:00:00";
        private Stopwatch stopwatch;
        private System.Timers.Timer timer;
                
        public MainWindow()
        {
            InitializeComponent();

            //display as 00:00
            DisplayTime.Text = displaytime;

            //create new instances
            stopwatch = new Stopwatch();
            dt = new DispatcherTimer();
            timer = new System.Timers.Timer(interval:1000);


            //timer.Interval = 1000; //1s
            timer.Elapsed += timer_tick;

            //timer.Interval = TimeSpan.FromSeconds(1);

            



        }

        private void OnTimerElapsed(object sender, EventArgs e)
        {
            
        }

        private void timer_tick(object sender, EventArgs e)
        {
            //TimeSpan elapsedTime = DateTime.Now - displayTime;
            //DisplayTime.Text = elapsedTime.ToString(@"hh\:mm");
            Application.Current.Dispatcher.Invoke(() => DisplayTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss"));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
            Clear.IsEnabled = false;

        }
        
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
            Clear.IsEnabled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            DisplayTime.Text = displaytime;
        }
    }
}
