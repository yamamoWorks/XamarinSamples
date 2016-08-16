using ActivityIndicatorRenderer.UWP;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(RingActivityIndicatorRenderer))]

namespace ActivityIndicatorRenderer.UWP
{
    public class RingActivityIndicatorRenderer : ViewRenderer<ActivityIndicator, Windows.UI.Xaml.Controls.ProgressRing>
    {
        private Brush foregroundDefault;

        protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new Windows.UI.Xaml.Controls.ProgressRing());
                    Control.Loaded += OnControlLoaded;
                }
                UpdateIsRunning();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName)
            {
                UpdateIsRunning();
            }
            else if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
        }

        void OnControlLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            foregroundDefault = Control.Foreground;
            UpdateColor();
        }

        void UpdateColor()
        {
            Color color = Element.Color;
            if (color == Color.Default)
            {
                Control.Foreground = foregroundDefault;
            }
            else
            {
                Control.Foreground = color.ToBrush();
            }
        }

        void UpdateIsRunning()
        {
            Control.IsActive = Element.IsRunning;
        }
    }

    internal static class ConvertExtensions
    {
        public static Brush ToBrush(this Color color)
        {
            return new SolidColorBrush(color.ToWindowsColor());
        }

        public static Windows.UI.Color ToWindowsColor(this Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * 255), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
}
