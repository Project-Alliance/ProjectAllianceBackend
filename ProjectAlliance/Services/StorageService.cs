using System;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace ProjectAlliance.Services
{
    public class StorageService : IStorageServiceInterface
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public StorageService(
            BlobServiceClient blobServiceClient,
            IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }

        public void upload(IFormFile formFile)
        {
            

            var containerName = _configuration.GetSection("Storage:ContainerName").Value;

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(formFile.FileName);

            using var stream = formFile.OpenReadStream();
            blobClient.Upload(stream, true);
        }
    }
}
