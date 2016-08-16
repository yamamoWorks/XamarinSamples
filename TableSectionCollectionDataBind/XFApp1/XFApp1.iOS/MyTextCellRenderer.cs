using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextCell), typeof(XFApp1.iOS.MyTextCellRenderer))]

namespace XFApp1.iOS
{
    public class MyTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;            
            return cell; 
        }
    }
}