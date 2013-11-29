using System;

namespace ReferenceToSubscriber
{
    class EventPublisher
    {
        public event EventHandler Fire;
        public void RaiseFire()
        {
            if (this.Fire != null)
                this.Fire(this, EventArgs.Empty);
        }
    }

    class EventSubscriber
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
    
    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();

            publisher.Fire += new EventSubscriber("Mac").Handler;
            new EventSubscriber("Tosh");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            publisher.RaiseFire();

            Console.WriteLine("Finish");

            // Output
            // Tosh: "Good bye."
            // Mac: Kabooooooom!
            // Finish
            // Mac: "Good bye."
        }
    }
}
