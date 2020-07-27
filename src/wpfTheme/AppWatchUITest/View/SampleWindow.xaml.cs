using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AppWatchUITest.View
{
    /// <summary>
    /// SampleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SampleWindow : Window
    {
        public SampleWindow()
        {
            InitializeComponent();

            this.Loaded += SampleWindow_Loaded;
        }

        private void SampleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartTime();
        }

        ~SampleWindow()
        {
            isTiming = false;
        }

        bool isTiming = true;
        void StartTime()
        {
            Task.Factory.StartNew(() =>
            {
                while (isTiming)
                {
                    Thread.Sleep(1000);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var time = DateTime.Now;
                        HourText.Text = time.Hour.ToString();
                        MinText.Text = time.Minute.ToString();
                        Second.Angle = (time.Second + 1) / 60.0 * 360.0;
                    }));
                }
            });
        }
    }
}
