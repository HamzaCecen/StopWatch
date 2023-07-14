using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DispatcherTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dt = new DispatcherTimer(); //I cannot use DispatcherTime bcz it is namespace not type
            dt.Tick += new EventHandler(UpdateTime_Tick); // EventHandler -> process events raised by multiple controls, Tick -> tekrarlanmasını istenen bir metot
            dt.Interval = new TimeSpan(0, 0, 1); //DateTime gibi struct(yapı) olarak tasarlanmış bir süre temsil eden değişkendir
            dt.Start();
        }

        private void UpdateTime_Tick(object sender, EventArgs e)
        {
            DisplayDate.Text = DateTime.Now.ToString();
        }
    }
}
