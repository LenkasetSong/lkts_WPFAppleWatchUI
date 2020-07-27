using AppWatchUITest.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWatchUITest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int total = wave.Totals;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(50);
                    int start = rand.Next(1, 10);
                    int end = rand.Next(10, total);
                    int count = rand.Next(0, 20);
                    Dictionary<int, Double> chgVals = new Dictionary<int, double>();
                    for (int i = 0; i < count; i++)
                    {
                        int key = rand.Next(start, end);
                        if (chgVals.ContainsKey(key)) continue;
                        double val = rand.NextDouble() * 20;
                        chgVals.Add(key, val);
                    }
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        wave.IndexedValue = chgVals;
                    }));
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow nw = new NavigationWindow();
            nw.ShowInTaskbar = false;
            //nw.ShowsNavigationUI = false;
            nw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var pd = new PreDesignView();
            nw.Width = pd.Width;
            nw.Height = pd.Height;
            nw.Content = pd;
            nw.ShowDialog();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SampleWindow sw = new SampleWindow();
            sw.ShowDialog();
        }
    }
}
