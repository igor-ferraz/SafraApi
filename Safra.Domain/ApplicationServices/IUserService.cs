using System.Threading.Tasks;

namespace Safra.Domain.ApplicationServices
{
    public interface IUserService
    {
        Task<bool> SaveToken(string clientId, string token);
        Task<string> GetCurrentTokenByAccount(string id);
    }
}
