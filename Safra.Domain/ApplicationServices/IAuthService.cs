using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Application.Services
{
    public interface IAuthService
    {
        Task<Token> Authorize(string token);
    }
}
