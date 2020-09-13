using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Safra.Domain.InfrastructureServices
{
    public interface IFileService
    {
        bool IsImage(IFormFile file);
        Task<bool> Save(IFormFile file, string baseName, string path);
    }
}
