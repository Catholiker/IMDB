using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyMovies.Controllers
{
    public class FileUploadController : ApiController
    {

        // POST api/FileUpload
        public async Task<string> Post()
        {
            string result = "File not Uploaded";

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                return result;

            try
            {
                var provider = new PhotoMultipartFormDataStreamProvider(@"E:\SinglePageApplication\MyMovies\MovieImages");
                await Request.Content.ReadAsMultipartAsync(provider);

            }
            catch (Exception ex)
            {
                return result;
            }

            result = "File Uploaded Successfully";
            return result;
        }

    }
}
