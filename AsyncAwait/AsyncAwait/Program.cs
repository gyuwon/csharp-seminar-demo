using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            IRemoteService rs = new FakeRemoteService();
            int key = 3;
            BlockingCall(rs, key);
            UsingTask(rs, key).Wait();
            UsingAwait(rs, key).Wait();
        }

        static void BlockingCall(IRemoteService rs, int key)
        {
            int x = rs.Compute(rs.Get(key));
            Console.WriteLine(x);
        }

        static Task UsingTask(IRemoteService rs, int key)
        {
            return
                rs.GetAsync(key)
                    .ContinueWith(t1 => rs.ComputeAsync(t1.Result)
                        .ContinueWith(t2 => Console.WriteLine(t2.Result))).Result;
        }

        async static Task UsingAwait(IRemoteService rs, int key)
        {
            int x = await rs.ComputeAsync(await rs.GetAsync(key));
            Console.WriteLine(x);
        }
    }

    interface IRemoteService
    {
        int Get(int key);
        Task<int> GetAsync(int key);
        int Compute(int x);
        Task<int> ComputeAsync(int x);
    }

    class FakeRemoteService : IRemoteService
    {
        const int delay = 100;

        public int Get(int key)
        {
            return this.GetAsync(key).Result;
        }

        public Task<int> GetAsync(int key)
        {
            return Task.Factory.StartNew(() => { Thread.Sleep(delay); return key; });
        }

        public int Compute(int x)
        {
            Thread.Sleep(delay);
            return x * x;
        }

        public Task<int> ComputeAsync(int x)
        {
            return Task.Factory.StartNew(() => { Thread.Sleep(delay); return x * x; });
        }
    }
}
