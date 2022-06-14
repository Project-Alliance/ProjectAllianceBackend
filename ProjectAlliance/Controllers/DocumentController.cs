using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.Models;
using ProjectAlliance.Data;
using FileResult = ProjectAlliance.Models.ProjectDocument;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Web;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProjectAlliance.Services;
using System.Net.Http;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        ApiDbContext dbContext;
        public IConfiguration Configuration { get; }
        private readonly IConfiguration _configuration;
        private FileServices fileServices;
            



        public DocumentController(ApiDbContext dbcontext,IConfiguration configuration)
        {
            dbContext = dbcontext;
            _configuration = configuration;
            fileServices = new FileServices();


        }
        [Authorize]
        [HttpPost("createsection")]
        public async Task<IActionResult> createSection([FromBody]DocumentSection value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            DocumentSection section = new DocumentSection();
            section.sectionName=value.sectionName;
            section.sectionDescription=value.sectionDescription;
            section.projectId=value.projectId;
            await dbContext.documentSection.AddAsync(section);
            dbContext.SaveChanges();
            return Ok(new {
            message="Created Successfully",
            section
            });

        }

        [Authorize]
        [HttpDelete("deleteSection/{id}")]
        public  IActionResult deleteSection(int id)
        {
            var section = dbContext.documentSection.SingleOrDefault(s=>s.sectionId==id);
            if(section!=null)
            {
                var document = dbContext.projectDocument.Where(s => s.sectionId == id).ToList();
                dbContext.projectDocument.RemoveRange(document);
                dbContext.documentSection.Remove(section);
                dbContext.SaveChanges();
                return Ok(new { message = "Deleted Successfully" });
            }else
            {
                return BadRequest(new { meassage = "Record Not Found" });
            }
        }
        //file will save into database
        [Authorize]
        [Route("files")]
        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new Files()
                    {
                        DocumentId = 0,
                        Name = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    dbContext.Files.Add(objfiles);
                    dbContext.SaveChanges();

                }
            }
            return Ok(new {message="created"});
        }

        //file will save to physical location
       
        [HttpGet]
        [Route("FileAPI/{fileName}")]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename is not availble");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, fileServices.GetContentType(path), Path.GetFileName(path));
        }
        [HttpGet]
        [Route("FileAPIV/{fileName}")]
        public HttpResponseMessage DownloadVideo(string filename)
        {
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", filename);

            if (filename != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = filename
                };
                return response;
            }
            else return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
       [Authorize]
        [HttpPost("saveDocumentToDatabase")]
        public async Task<IActionResult> SaveDocumentInformation([FromForm] ProjectDocument value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            ProjectDocument document = new ProjectDocument();
            document.documentName = value.documentName;
            document.sectionId = value.sectionId;
            document.projectId=value.projectId;
         
            document.documentDescription=value.documentDescription;
            
            document.uploadBy=value.uploadBy;
            document.documentVersion=value.documentVersion;
            document.documentStatus = value.documentStatus;


            // Getting Image
            var file = value.file;

            //Getting FileName
            var fileName = Path.GetFileName(file.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);
            // concatenating  FileName + FileExtension
            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), "Files", fileExtension);

            // Saving Image on Server
            if (file.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", newFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    file.CopyTo(fileStream);
                }
                document.documentFileExtension = fileExtension;
                document.filePath = newFileName;
                
            }
            else
            {
                return BadRequest(new { message= "File Not Uploaded to server", value });
            }

          



            await dbContext.projectDocument.AddAsync(document);
            dbContext.SaveChanges();           
            return Ok(new
            {
                message = "Created Successfully"
            });

        }
        [Authorize]
        [HttpGet("GetDocument/{pid}")]
        public async Task<ActionResult> GetDocumentInformation(int pid)
        {
            List<object> list = new List<object>();
            var documentSection=dbContext.documentSection.Where(s=>s.projectId==pid).ToListAsync();
            foreach (var document in await documentSection)
            {
                var Documents = dbContext.projectDocument.Where(s => s.projectId == pid && s.sectionId == document.sectionId).ToListAsync();
                List<object> doc = new List<object>();
                foreach (var DOC in await Documents)
                {
                    if (DOC.filePath == null)
                        return Content("filename is not availble");
                    var user = dbContext.Users.SingleOrDefault(s=>s.id== Convert.ToInt32(DOC.uploadBy));
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", DOC.filePath);
                    object documentObject = new {
                         documentName=DOC.documentName,
                         documentDescription=DOC.documentDescription,
                        documentStatus=DOC.documentStatus,
                         uploadBy=user.name,
                        uploadById = user.id,
                        documentVersion =DOC.documentVersion,
                        filePath= "http://192.168.43.107:5005/api/Document/FileAPI/"+DOC.filePath,
                        sectionId=DOC.sectionId,
                         projectId=DOC.projectId,
                        documentId=DOC.documentId,
                        documentFileExtension =DOC.documentFileExtension,
                        file= path
                    };
                    doc.Add(documentObject);
                }
                var obj = new
                {
                    sectionId = document.sectionId,
                    sectionName = document.sectionName,
                    sectionDescription = document.sectionDescription,
                    projectId = document.projectId,
                    documents = doc,
                    
                };
                list.Add(obj);
            }
            
            return Ok(list);
        }

        [Authorize]
        [HttpDelete("DeleteDocument/{documentId}")]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            var document = dbContext.projectDocument.SingleOrDefault(s => s.documentId == documentId);
            if(document!=null)
            {
                dbContext.projectDocument.Remove(document);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Deleted Document" });
            }
            return BadRequest(new { message = "Deleted Not Found" });
        }

        [Authorize]
        [HttpPut("UpdateDocument/{documentId}")]
        public async Task<IActionResult> UpdateDocument(int documentId, [FromBody] ProjectDocument document)
        {
            var Doc = dbContext.projectDocument.SingleOrDefault(s => s.documentId == documentId);
           if(Doc!=null)
            {
                Doc.documentName = document.documentName;
                Doc.documentStatus = document.documentStatus;
                dbContext.projectDocument.Update(Doc);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Document Update" });
            }
            return BadRequest(new { message = "Deleted Not Found" });
        }

    }


}

