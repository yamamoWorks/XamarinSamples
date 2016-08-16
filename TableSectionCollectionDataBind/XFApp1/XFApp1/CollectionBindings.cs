using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFApp1
{
    public static class CollectionBindings
    {
        #region ItemsSource

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.CreateAttached(
                "ItemsSource", typeof(IEnumerable), typeof(BindableObject), null, BindingMode.OneWay,
                propertyChanged: (b, o, n) => OnItemsSourceChanged(b, o, n));

        public static IEnumerable GetItemsSource(BindableObject bindable)
        {
            return (IEnumerable)bindable.GetValue(ItemsSourceProperty);
        }

        public static void SetItemsSource(BindableObject bindable, CollectionBinderBase value)
        {
            bindable.SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var binder = CollectionBindings.GetBinder(bindable);
            if (binder == null)
            {
                binder = CreateBinder(bindable);
                CollectionBindings.SetBinder(bindable, binder);
            }
            binder.SetItemSource(oldValue, newValue);
            binder.Reset();
        }

        #endregion

        #region ItemTemplate

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.CreateAttached(
                "ItemTemplate", typeof(DataTemplate), typeof(BindableObject), null, BindingMode.OneWay,
                propertyChanged: (b, o, n) => OnItemTemplateChanged(b, o, n));

        public static DataTemplate GetItemTemplate(BindableObject bindable)
        {
            return (DataTemplate)bindable.GetValue(ItemTemplateProperty);
        }

        public static void SetItemTemplate(BindableObject bindable, CollectionBinderBase value)
        {
            bindable.SetValue(ItemTemplateProperty, value);
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var binder = CollectionBindings.GetBinder(bindable);
            if (binder == null)
            {
                binder = CreateBinder(bindable);
                CollectionBindings.SetBinder(bindable, binder);
            }
            binder.Reset();
        }

        #endregion

        #region Binder

        private static readonly BindableProperty BinderProperty =
            BindableProperty.CreateAttached(
                "Binder", typeof(CollectionBinderBase), typeof(BindableObject), null, BindingMode.OneWay,
                propertyChanged: OnBinderChanged);

        private static CollectionBinderBase GetBinder(BindableObject bindable)
        {
            return (CollectionBinderBase)bindable.GetValue(BinderProperty);
        }

        private static void SetBinder(BindableObject bindable, CollectionBinderBase value)
        {
            bindable.SetValue(BinderProperty, value);
        }

        private static void OnBinderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue is CollectionBinderBase)
            {
                ((CollectionBinderBase)oldValue).Dispose();
            }
        }

        #endregion

        private static CollectionBinderBase CreateBinder(BindableObject target)
        {
            // ExportRendererのような登録機構を作るべきだが今回は手抜き

            if (target is TableSection)
            {
                return new TableSectionCollectionBinder(target);
            }
            if (target is StackLayout)
            {
                return new StackLayoutCollectionBinder(target);
            }
            return null;
        }
    }
}
