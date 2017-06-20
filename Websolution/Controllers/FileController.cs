using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Security.Providers;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{

    [RoutePrefix("api/file")]
    public class FileController : BaseApiController
    {

        [Authorize(Roles = "User,Admin")]
        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> Encrypt()
        {
            var encryptedFileId = "";

            var user = AppUserManager.FindById(User.Identity.GetUserId());
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            foreach (MultipartFileData file in provider.FileData)
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Files uploaded successfully!", id = encryptedFileId });
        }


        //[Route("download/{id}")]
        //[HttpGet]
        //public async Task<HttpResponseMessage> Download(string id)
        //{
        //    var decryptedFilePath = _storageService.ReadAsEncrypted(id);
        //    HttpResponseMessage response = new HttpResponseMessage();
        //    string fileName = Path.GetFileName(decryptedFilePath);
        //    response.Content = new StreamContent(File.OpenRead(decryptedFilePath));
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = fileName,
        //        DispositionType = "attachment"
        //    };
        //    return response;
        //}




    }
}
