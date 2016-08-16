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
    public class TableSectionCollectionBinder : CollectionBinderBase
    {
        private IList<Cell> cells = new List<Cell>();

        public TableSectionCollectionBinder(BindableObject bindable)
            : base(bindable)
        {
        }

        protected override void OnItemsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // 本来は NotifyCollectionChangedAction に応じて子要素の処理をすべきだが、ここでは全てクリアして作り変える
            // 但し、今回は最後に「アカウントを追加」を表示する為にデータバインド以外の子要素を許容しているので
            // その子要素を消さないようにデータバインドで作成した子要素を管理している

            var target = Target as TableSection;

            // データバインドで作成した子要素だけ削除
            foreach (var cell in cells)
            {
                target.Remove(cell);
                cell.BindingContext = null;
            }
            cells.Clear();

            // コレクションデータ毎にDataTemplateからCellを作成して追加
            var index = 0;
            foreach (var item in ItemsSource)
            {
                var content = (Cell)ItemTemplate.CreateContent();
                content.BindingContext = item;
                target.Insert(index, content);
                cells.Add(content);
                index++;
            }
        }
    }
}
