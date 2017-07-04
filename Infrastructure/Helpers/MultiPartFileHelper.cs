using System.Net.Http;
using Newtonsoft.Json;

namespace Infrastructure.Helpers
{
    public static class MultipartFileHelper
    {
        public static string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private static string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
