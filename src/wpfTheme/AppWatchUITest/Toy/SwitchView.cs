using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWatchUITest.Toy
{
    public class SwitchView : ItemsControl
    {
        static SwitchView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchView), new FrameworkPropertyMetadata(typeof(SwitchView)));
        }

        public void UnselectAll()
        {
            foreach (var item in this.Items)
            {
                if (item is SwitchViewItem)
                {
                    (item as SwitchViewItem).IsSelected = false;
                }
            }
        }
    }
}
