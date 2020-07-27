using AppWatchUITest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AppWatchUITest.Toy
{
    public static class UIElementExtension
    {
        public static double RoundLayoutValue(this UIElement ui, double value,double dpiScale)
        {
            double num;
            if (!DoubleUtil.AreClose(dpiScale, 1.0))
            {
                num = Math.Round(value * dpiScale) / dpiScale;
                if (DoubleUtil.IsNaN(num) || double.IsInfinity(num) || DoubleUtil.AreClose(num, 1.7976931348623157E+308))
                {
                    num = value;
                }
            }
            else
            {
                num = Math.Round(value);
            }
            return num;
        }
    }
}
