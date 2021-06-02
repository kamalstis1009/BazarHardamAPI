using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SSL_EC_API.Controllers
{
    public class FileController : ApiController
    {
        //======================================================| Upload
        //Help: -https://www.c-sharpcorner.com/UploadFile/2b481f/uploading-a-file-in-Asp-Net-web-api/
        [Route("Api/File/Upload")]
        [HttpPost]
        public HttpResponseMessage Upload([FromUri] string directory)
        {
            var httpRequest = HttpContext.Current.Request;
            HttpResponseMessage result;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + directory + "/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        //======================================================| Download
        [Route("Api/File/DownloadByte")]
        [HttpGet]
        public async Task<IHttpActionResult> DownloadByte([FromUri] string fileName, [FromUri] string directory)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + directory + "/" + fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //string base64String = Convert.ToBase64String(bytes);
            //string imgDataURL = string.Format("data:image/png;base64,{0}", base64String);
            var base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            if (base64String != null)
            {
                //return Ok("data:image/png;base64," + base64String);
                return Ok(base64String);
            }
            return NotFound();
        }

        [Route("Api/File/LoadFile")]
        [HttpGet]
        public IHttpActionResult LoadFile([FromUri] string fileName)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads/" + fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                return Ok(Image.FromFile(path));
            }
            return NotFound();
        }

        //======================================================| Delete
        [Route("Api/File/Delete")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] string fileName, [FromUri] string directory)
        {
            //var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + directory + "/" + fileName);
            //File.Delete(path);

            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + directory + "/" + fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                return Ok(path);
            }
            return NotFound();
        }

        //======================================================| DeleteAndUpload
        [Route("Api/File/DeleteAndUpload")]
        [HttpPost]
        public HttpResponseMessage DeleteAndUpload([FromUri] string fileName)
        {
            //path = "E:\\SSL_JMS\\UserPhoto\\" + fileName;
            var path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + fileName); //"~/App_Data/" + directory + "/" + fileName
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            var httpRequest = HttpContext.Current.Request;
            HttpResponseMessage result;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName); //"~/App_Data/" + directory + "/" + postedFile.FileName
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        //======================================================| DeleteAndUpload
        [Route("Api/File/Test")]
        [HttpPost]
        public HttpResponseMessage Test()
        {
            var httpRequest = HttpContext.Current.Request;
            HttpResponseMessage result;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName); //"~/App_Data/" + directory + "/" + postedFile.FileName
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

    }
}
