using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Infrastructure.Helpers;
using Security.Providers;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : BaseApiController
    {

        [Route("upload")]
        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile()
        {

            if (!Request.Content.IsMimeMultipartContent())
            {
                return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(root);
            CustomMultipartFormDataStreamProvider result = await Request.Content.ReadAsMultipartAsync(provider);

            foreach (MultipartFileData file in provider.FileData)
            {
                string originalFileName = MultipartFileHelper.GetDeserializedFileName(result.FileData.First());

                using (FileStream stream = new FileStream(file.LocalFileName, FileMode.Open))
                {
                    //Do something with the stream
                    stream.Close();
                    stream.Dispose();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}