using System;
using System.Collections.ObjectModel;
using System.Windows;
using MahApps.Metro.Controls;

namespace AsyncManner
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            this._contacts = new ObservableCollection<Contact>();

            InitializeComponent();
        }

        private int _busyWorks = 0;

        private class BusyWork : IDisposable
        {
            private MainWindow _owner;

            public BusyWork(MainWindow owner)
            {
                this._owner = owner;
            }

            void IDisposable.Dispose()
            {
                this._owner.EndBusy();
            }
        }

        protected IDisposable StartBusy()
        {
            this.VerifyAccess();
            IDisposable work = new BusyWork(this);
            if (this._busyWorks == 0)
            {
                this.busyIndicator.Visibility = Visibility.Visible;
                this.progressRing.IsActive = true;
            }
            this._busyWorks++;
            return work;
        }

        private void EndBusy()
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                this._busyWorks--;
                if (this._busyWorks == 0)
                {
                    this.progressRing.IsActive = false;
                    this.busyIndicator.Visibility = Visibility.Hidden;
                }
            });
        }

        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return this._contacts;
            }
        }

        private void OnLoadClick(object sender, RoutedEventArgs e)
        {
            IAppService service = App.GetAppService();
            this._contacts.Clear();
            foreach (var c in service.GetContacts().Result)
                this._contacts.Add(c);
        }

        async private void OnLoadAsyncClick(object sender, RoutedEventArgs e)
        {
            using (this.StartBusy())
            {
                IAppService service = App.GetAppService();
                this._contacts.Clear();
                foreach (var c in await service.GetContacts())
                    this._contacts.Add(c); 
            }
        }

        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            this._contacts.Clear();
        }
    }
}
