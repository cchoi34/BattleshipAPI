using BattleshipGoogleCloud.Models;
using Google.Cloud.Storage.V1;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGoogleCloud.Services
{
    public class GoogleCloudStorageService : IStorageService
    {
        private readonly StorageClient _storageClient;
        private const string BucketName = "";

        public GoogleCloudStorageService()
        {
            // If running locally have to authenticate
#if DEBUG
            var credentialJson = System.IO.File.ReadAllText(@"PATH_TO_CREDENTIALS_FILE");
            _storageClient = StorageClient.Create(Google.Apis.Auth.OAuth2.GoogleCredential.FromJson(credentialJson));
            // If running in the cloud auth is automatic
#else
            _storageClient = StorageClient.Create();
#endif
        }

        public async Task<Game> GetGame(string name)
        {
            var source = await _storageClient.GetObjectAsync(BucketName, name);

            using (var ms = new MemoryStream())
            {
                await _storageClient.DownloadObjectAsync(source, ms);
                var json = Encoding.UTF8.GetString(ms.ToArray());

                return JsonConvert.DeserializeObject<Game>(json);
            }
        }

        public async Task<bool> SaveGame(Game game, string name)
        {
            try
            {
                var json = JsonConvert.SerializeObject(game);

                var byteArray = Encoding.UTF8.GetBytes(json);

                using (var stream = new MemoryStream(byteArray))
                {
                    await _storageClient.UploadObjectAsync(BucketName, name, "application/json", stream);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
