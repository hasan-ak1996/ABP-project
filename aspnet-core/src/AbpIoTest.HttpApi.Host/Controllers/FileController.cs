using AbpIoTest.Models;
using AttachmentMasterFolder;
using classAttachmentDetailManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpIoTest.Controllers
{
    public class FileController : AbpController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AttachmentMasterManager.AttachmentMasterManager _attachmentMasterManager;
        private readonly AttachmentDetailManager _attachmentDetailManager;

        public FileController(IWebHostEnvironment hostingEnvironment ,
            AttachmentMasterManager.AttachmentMasterManager attachmentMasterManager,
            AttachmentDetailManager attachmentDetailManager
            )
        {
            _hostingEnvironment = hostingEnvironment;
            _attachmentMasterManager = attachmentMasterManager;
            _attachmentDetailManager = attachmentDetailManager;
        }
        // GET: FileController
        public ActionResult Index()
        {
            return Ok("ok");
        }

        // GET: FileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: FileController/Create
        [HttpPost]

        public async Task<ActionResult> Create(FileUpload fileObj)
        {

            var lastFolderCreated = await _attachmentMasterManager.GetLastFolderCreated();
            var files = fileObj.Files;
            //List<AttachmentDetail.AttachmentDetail> MasterFiles = new List<AttachmentDetail.AttachmentDetail>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();

                            AttachmentDetail.AttachmentDetail attachmentDetail = new AttachmentDetail.AttachmentDetail
                            {
                                FileName = file.FileName,
                                File = fileBytes,
                                AttachmentMasterId = lastFolderCreated.Id
                            };

                            await _attachmentDetailManager.CreateFile(attachmentDetail);
                        //    MasterFiles.Add(attachmentDetail);
                        }
                    }

                }
               // attachmentMaster.Files = MasterFiles;

                //order.Files = orderFiles;
            }
      
            return Ok("ok");
        }

        [HttpGet]
        public async Task<ActionResult> Download(string fileName)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            // string t = GetContentType(filePath);
            // var y = t.IndexOf('/');
            // var j = t.Substring(y+1);


            return File(memory, GetContentType(filePath), fileName);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        [HttpPost]
        public async Task<ActionResult> EditFile(EditFile editObj)
        {
            var updatedItem = await _attachmentDetailManager.GetFileById(editObj.id);

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var file = editObj.file;
            if (file != null)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        updatedItem.File = fileBytes;
                        updatedItem.FileName = file.FileName;
                    }

                }

            }
            await _attachmentDetailManager.UpdateFile(updatedItem);


            return Ok("Ok");
        }

        // GET: FileController/Create

        // POST: FileController/Create
        public ActionResult CreateTest()
        {
            return Ok("ok");
        }

        // GET: FileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
