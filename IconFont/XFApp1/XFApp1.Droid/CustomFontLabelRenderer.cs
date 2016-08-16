using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Label), typeof(XFApp1.Droid.CustomFontLabelRenderer))]

namespace XFApp1.Droid
{
    public class CustomFontLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var fontFamily = e.NewElement.FontFamily?.ToLower();
            if (fontFamily != null && (fontFamily.EndsWith(".otf") || fontFamily.EndsWith(".ttf")))
            {
                var lable = (TextView)Control;
                lable.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, e.NewElement.FontFamily);
            }
        }
    }
}