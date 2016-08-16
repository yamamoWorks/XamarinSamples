using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFApp1
{
    public class StackLayoutCollectionBinder : CollectionBinderBase
    {
        public StackLayoutCollectionBinder(BindableObject bindable)
            : base(bindable)
        {
        }

        protected override void OnItemsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var target = Target as StackLayout;

            target.Children.Clear();

            foreach (var item in ItemsSource)
            {
                var content = (View)ItemTemplate.CreateContent();
                content.BindingContext = item;
                target.Children.Add(content);
            }
        }
    }
}
