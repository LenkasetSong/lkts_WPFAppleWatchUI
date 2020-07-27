using Microsoft.Expression.Shapes;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWatchUITest.Toy
{
    /**
     * 另一个Arc和Elli的宽度应该搞成可设置的
     * 那么PART_ValueElli的Margin和大小也应该相应的变化
     * 更新也要更新PART_ValueElli的RenderTransformOrigin
     * **/
    [TemplatePart(Name = "PART_ValueArc", Type = typeof(Arc))]
    [TemplatePart(Name = "PART_ValueElli", Type = typeof(Ellipse))]
    public class ProgressCircle : RangeBase
    {
        Arc valueArc { get; set; }
        Ellipse valueElli { get; set; }

        static ProgressCircle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressCircle), new FrameworkPropertyMetadata(typeof(ProgressCircle)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            valueArc = GetTemplateChild("PART_ValueArc") as Arc;
            if (valueArc != null)
            {
                double newAngle = Value / (Maximum - Minimum) * 360;
                UpdateValueArc(0, newAngle);
            }
            valueElli = GetTemplateChild("PART_ValueElli") as Ellipse;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            if (valueElli != null)
            {
                double y = (this.ActualHeight / 2.0 - valueElli.ActualHeight - valueElli.Margin.Bottom) / valueElli.Height;
                valueElli.RenderTransformOrigin = new Point(0.5, -y);
            }
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            double oldAngle = oldValue / (Maximum - Minimum) * 360;
            double newAngle = newValue / (Maximum - Minimum) * 360;
            //valueArc.EndAngle = Value;
            UpdateValueArc(oldAngle, newAngle);
        }

        void UpdateValueArc(double oldAngle, double newAngle)
        {
            if (valueArc != null)
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(Math.Abs(newAngle - oldAngle) * 2000 / 360));
                DoubleAnimation doubleAnimation = new DoubleAnimation(oldAngle, newAngle, duration);
                valueArc.BeginAnimation(Arc.EndAngleProperty, doubleAnimation);
            }
        }
    }
}
