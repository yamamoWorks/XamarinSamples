using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFApp1
{
    public static class TextCellExtention
    {
        public static readonly BindableProperty AccessoryProperty =
                   BindableProperty.CreateAttached(
                       "Accessory", typeof(ViewCellAccessory), typeof(BindableObject), ViewCellAccessory.None, BindingMode.OneWay);

        public static ViewCellAccessory GetAccessory(BindableObject bindable)
        {
            return (ViewCellAccessory)bindable.GetValue(AccessoryProperty);
        }

        public static void SetAccessory(BindableObject bindable, ViewCellAccessory value)
        {
            bindable.SetValue(AccessoryProperty, value);
        }
    }

    public enum ViewCellAccessory
    {
        None = 0,
        DisclosureIndicator = 1,
        DetailDisclosureButton = 2,
        Checkmark = 3,
        DetailButton = 4
    }
}
