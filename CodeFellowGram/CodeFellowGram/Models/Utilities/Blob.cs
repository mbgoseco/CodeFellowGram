﻿using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFellowGram.Models.Utilities
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Creates a connection the blob storage account associated to the web app, searches for a specific container name and creates one if it doesn't exist.
        /// <param name="containerName">Name of blob storage container</param>
        /// <returns>Container</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return cbc;
        }

        // Get Blob
        /// <summary>
        /// Searches a given storage container and finds the object matching the given image name.
        /// </summary>
        /// <param name="imageName">Name of image being searched</param>
        /// <param name="containerName">Name of blob storage container</param>
        /// <returns>Matching blob object</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }

        /// <summary>
        /// Takes in a file referenced by its name and file path, and uploads a copy of it to the provided Azure storage blob container.
        /// </summary>
        /// <param name="cloudBlobContainer">Blob container</param>
        /// <param name="fileName">Name of file to upload</param>
        /// <param name="filePath">File path of file to upload</param>
        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }
    }
}
