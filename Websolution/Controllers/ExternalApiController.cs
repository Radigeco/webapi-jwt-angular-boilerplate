using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Http;
using Websolution.Controllers.Base;

namespace Websolution.Controllers
{
    [RoutePrefix("api/externalapi")]
    public class ExternalApiController : BaseApiController
    {

        [AllowAnonymous]
        [Route("badrequesthandling")]
        [HttpGet]
        public IHttpActionResult HitApi()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://developers.google.com/vision/android/barcodes-overview");
            // Set the Method property of the request to POST.
            request.Method = "PUT";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            WebResponse response = null;
            // Get the response.
            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    throw;
                }

                response =  e.Response;
            }

            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return Ok(responseFromServer);
        }
    }
}