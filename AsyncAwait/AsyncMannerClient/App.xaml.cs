using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncManner
{
    public partial class App : Application
    {
        public static IAppService GetAppService()
        {
            return FakeAppService.Instance;
        }
    }

    class FakeAppService : IAppService
    {
        public static readonly FakeAppService Instance = new FakeAppService();

        public Task<Contact[]> GetContacts()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return new Contact[]
                {
                    new Contact { Id = 1, FirstName = "Tony", LastName = "Stark", Email = "ironman@avengers.com" },
                    new Contact { Id = 2, FirstName = "Bruce", LastName = "Banner", Email = "hulk@avengers.com" },
                    new Contact { Id = 3, FirstName = "Thor", LastName = "Odinson", Email = "thor@avengers.com" }
                };
            });
        }
    }
}
