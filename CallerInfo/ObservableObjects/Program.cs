using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ObservableObjects
{
    interface IHasValue : INotifyPropertyChanged
    {
        int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IHasValue[] observables = new IHasValue[]
            {
                new Observable1(),
                new Observable2(),
                new Observable3()
            };
            foreach (var observable in observables)
            {
                observable.PropertyChanged += (s, e) => Console.WriteLine(e.PropertyName);
                observable.Value = 10;
            }
        }
    }

    class Observable1 : IHasValue, INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                this.OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Observable2 : IHasValue, INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get { return this._value; }
            set
            {
                this.Set(() => this.Value, ref this._value, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(
            Expression<Func<T>> propertyExpression,
            ref T field,
            T newValue)
        {
            var body = propertyExpression.Body as MemberExpression;
            string propertyName = body.Member.Name;
            field = newValue;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Observable3 : IHasValue, INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get { return this._value; }
            set
            {
                this.Set(ref this._value, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(
            ref T field,
            T newValue,
            [CallerMemberName]string propertyName = null)
        {
            field = newValue;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
