using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebService.Models;

namespace DemoWebService.Controllers
{
    public class FileController : ApiController
    {
        public IHttpActionResult GetFileContents()
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string path = string.Empty;
            if (headers.Contains("Path"))
            {
                path = headers.GetValues("Path").First();
            }
            else
                throw new ApplicationException("Path Header cannot be empty");

            var content = System.IO.File.ReadAllText(path);

            DemoFile fileContent = new DemoFile
            {
                FileContent = content
            };

            return Content(HttpStatusCode.OK, fileContent);
        }


    }

    

}
