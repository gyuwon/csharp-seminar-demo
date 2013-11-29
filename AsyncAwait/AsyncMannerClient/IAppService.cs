using System.Threading.Tasks;

namespace AsyncManner
{
    public interface IAppService
    {
        Task<Contact[]> GetContacts();
    }
}
