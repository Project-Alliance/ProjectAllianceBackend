using System;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Services
{
    public interface IStorageServiceInterface
    {
        void upload(IFormFile formFile);
    }
}
