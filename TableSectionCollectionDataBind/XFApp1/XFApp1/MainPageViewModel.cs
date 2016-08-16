using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFApp1
{
    public class MainPageViewModel : BindableObject
    {
        public ObservableCollection<Account> Accounts { get; }

        public ICommand AddCommand { get; }

        public MainPageViewModel()
        {
            Accounts = new ObservableCollection<Account>(new[]
            {
                new Account { Name= "iCloud", Text="iCloud Drive, リマインダー, メモとその他2項目" },
                new Account { Name= "Outlook", Text="メール、連絡先、カレンダーリマインダー、メモ" },
                new Account { Name= "Gmail", Text="メール、連絡先、カレンダー" }
            });

            AddCommand = new Command(() =>
            {
                Accounts.Add(new Account { Name = "Yahoo!", Text = "メール、連絡先、カレンダー" });
            });
        }
    }

    public class Account
    {
        public string Name { get; set; }

        public string Text { get; set; }
    }
}
