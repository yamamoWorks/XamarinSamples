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
    public abstract class CollectionBinderBase : IDisposable
    {
        protected BindableObject Target { get; }

        public CollectionBinderBase(BindableObject bindable)
        {
            Target = bindable;
        }

        public IEnumerable ItemsSource
        {
            get { return CollectionBindings.GetItemsSource(Target); }
        }

        public DataTemplate ItemTemplate
        {
            get { return CollectionBindings.GetItemTemplate(Target); }
        }

        public void SetItemSource(object oldValue, object newValue)
        {
            if (oldValue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)oldValue).CollectionChanged -= OnItemsCollectionChanged;
            }
            if (newValue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)newValue).CollectionChanged += OnItemsCollectionChanged;
            }
        }

        public void Reset()
        {
            if (ItemTemplate == null || ItemsSource == null)
            {
                return;
            }

            OnItemsCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected abstract void OnItemsCollectionChanged(NotifyCollectionChangedEventArgs e);

        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnItemsCollectionChanged(e);
        }

        #region Dispose

        private bool disposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.disposed)
            {
                if (isDisposing)
                {
                    var items = ItemsSource as INotifyCollectionChanged;
                    if (items != null)
                    {
                        items.CollectionChanged -= OnItemsCollectionChanged;
                    }
                }

                this.disposed = true;
            }
        }

        #endregion
    }
}
