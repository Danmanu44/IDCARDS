using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IDCARDS.Shared;

namespace IDCARDS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesaveStaffController : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly ILogger<FilesaveController> logger;

        public FilesaveStaffController(IWebHostEnvironment env,
            ILogger<FilesaveController> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<List<UploadResult>>> UploadFile(List<IFormFile> files)
        {

          //  var filesProcessed = 0;
           // var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
            List<UploadResult> uploadResults = new List<UploadResult>();

            foreach (var file in files)
            {
                var uploadResult = new UploadResult();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                var trustedFileNameForDisplay =
                    WebUtility.HtmlEncode(untrustedFileName);
                trustedFileNameForFileStorage = Path.GetRandomFileName();
                //var path= Path.Combine(env.ContentRootPath,"uploads", trustedFileNameForDisplay);
                string path = Path.Combine(Directory.GetCurrentDirectory().Replace("Server", "Client"), "wwwroot/images/staff", trustedFileNameForDisplay);


                //path.Replace("Server", "Client");


                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);
                uploadResult.StoredFileName = untrustedFileName;
                uploadResults.Add(uploadResult);
            }

            return Ok(uploadResults);
        }
    }
}
