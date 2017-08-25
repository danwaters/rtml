using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace RealtimeMoodLighting.iOS.Services
{
    public class FaceUploader
    {
        public static async Task Upload(byte[] image)
        {
            App.Log.Write("configuring storage account...");
			string storageConnectionString = "DefaultEndpointsProtocol=https;" +
                "AccountName=rtml;" +
                "AccountKey=Z5h/KqGdYm4qKzyycA8TueLr+3yOY+yotONko5dBggLeWAi7hjs2uCizH4ig6nrMxSnTLS8YEZsWh4RQIJrvuQ==;" +
                "EndpointSuffix=core.windows.net";

			CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
			CloudBlobClient serviceClient = account.CreateCloudBlobClient();

            var container = serviceClient.GetContainerReference("faces");
            container.CreateIfNotExistsAsync().Wait();
            var exists = await container.ExistsAsync();
            App.Log.Write($"exists? {exists}");

			// write a blob to the container
            CloudBlockBlob blob = container.GetBlockBlobReference(GetTempFilename());
            App.Log.Write($"About to upload {image.Length} bytes");
            blob.UploadFromByteArrayAsync(image, 0, image.Length).ContinueWith(async(Task) => { App.Log.Write("completed upload"); });
        }

        private static string GetTempFilename()
        {
            var g = Guid.NewGuid().ToString().Replace("{", "").Replace("}", "").Replace("-", "");
            return $"{g}.img";
        }
    }
}
