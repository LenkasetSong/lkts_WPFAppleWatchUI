using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWatchUITest.Toy
{
    [TemplatePart(Name = "PART_Border", Type = typeof(Border))]
    public class SwitchViewItem : ContentControl
    {
        Border bdr { get; set; }

        static SwitchViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchViewItem), new FrameworkPropertyMetadata(typeof(SwitchViewItem)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            bdr = this.GetTemplateChild("PART_Border") as Border;
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            var control = this as FrameworkElement;
            while ((control = (FrameworkElement)VisualTreeHelper.GetParent(control)) != null)
            {
                if (control.GetType() == typeof(SwitchView)) break;
            }
            if (control is SwitchView)
            {
                (control as SwitchView).UnselectAll();
            }
            this.IsSelected = true;
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(SwitchViewItem), new PropertyMetadata(false));

    }
}
