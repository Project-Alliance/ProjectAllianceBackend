using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Services
{
    public interface IStorageService
    {
       string Upload(IFormFile formFile);
    }
}