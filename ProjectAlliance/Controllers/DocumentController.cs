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




        public DocumentController(ApiDbContext dbcontext,IConfiguration configuration)
        {
            dbContext = dbcontext;
            _configuration = configuration;


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
        [Authorize]
        [Route("SaveDocument")]
        [HttpPost]

        public async Task<IActionResult> OnPostUploadAsync(IFormFile formFile)
        {
            if (formFile == null)
                return BadRequest(new { message = "Please select A document", status = 400 });
            long size = formFile.Length;
            string filePath="";

            
                 
                    //Getting FileName
                    var fileName = Path.GetFileName(formFile.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    filePath = Path.Combine(_configuration["StoredFilesPath"],
                        newFileName);

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }
                 
           
            // Process uploaded filesx
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { size, path = filePath, fileName, fileExtension });
        }
        [Authorize]
        [HttpPost("saveDocumentToDatabase")]
        public async Task<IActionResult> SaveDocumentInformation([FromBody] ProjectDocument value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            ProjectDocument document = new ProjectDocument();
            document.documentName = value.documentName;
            document.sectionId = value.sectionId;
            document.projectId=value.projectId;
            document.documentFileExtension=value.documentFileExtension;
            document.documentDescription=value.documentDescription;
            document.filePath = value.filePath;
            document.uploadBy=value.uploadBy;
            document.documentVersion=value.documentVersion;
            document.documentStatus = value.documentStatus;
            await dbContext.projectDocument.AddAsync(document);
            dbContext.SaveChanges();
            return Ok(new
            {
                message = "Created Successfully"
            });

        }
        [Authorize]
        [HttpGet("GetDocument/{pid}")]
        public async Task<IActionResult> GetDocumentInformation(int pid)
        {
            List<object> list = new List<object>();
            var documentSection=dbContext.documentSection.Where(s=>s.projectId==pid).ToListAsync();
            foreach(var document in await documentSection)
            {
                var Documents = dbContext.projectDocument.Where(s => s.projectId == pid && s.sectionId == document.sectionId).ToListAsync();
                List<ProjectDocument> doc = new List<ProjectDocument>();
                foreach (var DOC in await Documents)
                {
                    doc.Add(DOC);
                }
                var obj = new
                {
                    sectionId = document.sectionId,
                    sectionName = document.sectionName,
                    sectionDescription = document.sectionDescription,
                    projectId = document.projectId,
                    documents = doc
                };
                list.Add(obj);
            }
            return Ok(list);
        }

        

    }
    public interface ReturnSectonType
    {
        
        public int sectionId { set; get; }
        public string sectionName { set; get; }
        public string sectionDescription { set; get; }
        public int projectId { set; get; }
        

    }
}

