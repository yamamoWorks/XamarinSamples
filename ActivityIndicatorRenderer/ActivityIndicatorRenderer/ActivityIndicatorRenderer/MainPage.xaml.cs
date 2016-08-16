using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ActivityIndicatorRenderer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            pk1.SelectedIndexChanged += Pk1_SelectedIndexChanged;
        }

        private void Pk1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ai1.Color = (Color)new ColorTypeConverter().ConvertFrom(pk1.Items[pk1.SelectedIndex]);
        }
    }
}
