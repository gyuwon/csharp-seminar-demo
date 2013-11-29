using System;

namespace WeakSubscription
{
    public class EventPublisher
    {
        public event EventHandler Fire;
        public void RaiseFire()
        {
            if (this.Fire != null)
                this.Fire(this, EventArgs.Empty);
        }
    }

    public class EventSubscriber
    {
        private string _name;

        public EventSubscriber(string name)
        {
            this._name = name;
        }

        public void Handler(object sender, EventArgs e)
        {
            Console.WriteLine("{0}: Kabooooooom!", this._name);
        }

        ~EventSubscriber()
        {
            Console.WriteLine(string.Format("{0}: \"Good bye.\"", this._name));
        }
    }

    public class WeakEventHandler
    {
        private EventPublisher _publisher;
        private WeakReference _handler;

        public WeakEventHandler(EventPublisher publisher, EventSubscriber subscriber)
        {
            this._publisher = publisher;
            this._handler = new WeakReference(subscriber);
            this._publisher.Fire += OnFire;
        }

        void OnFire(object sender, EventArgs e)
        {
            if (this._handler.IsAlive)
                ((EventSubscriber)this._handler.Target).Handler(sender, e);
            else
                this._publisher.Fire -= this.OnFire;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();

            new WeakEventHandler(publisher, new EventSubscriber("Mac"));
            new EventSubscriber("Tosh");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            publisher.RaiseFire();

            Console.WriteLine("Finish");

            // Output
            // Tosh: "Good bye."
            // Mac: "Good bye."
            // Finish
        }
    }
}
