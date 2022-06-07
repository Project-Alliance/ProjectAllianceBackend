using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using ProjectAlliance.Models;
using ProjectAlliance.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class DesignController : Controller
    {
        // GET: api/values

        private readonly ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public DesignController(ApiDbContext _dbContext,IJwtTokenManager _jwtTokenManage)
        {
            this.dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
        }
      

       [Authorize]
        [HttpPost("createFolder")]
        public async Task<IActionResult> CreateModule(int projectId, [FromBody] DesignFolder value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = _jwtTokenManage.getUserId(identity.Claims);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&  s.pid == projectId && s.role == "Designer").SingleOrDefault();
            if(permision==null)
            {
                return BadRequest(new { message = "You have not permision, only Design Engineer can do this task" });
            }
            DesignFolder module = new DesignFolder();
            module.name = value.name;
            module.folderType = "Design";
            module.modifiedBy = Convert.ToInt16(userId);
            module.modifeidOn = DateTime.Now;
            module.projectId = projectId;
            dbContext.folders.Add(module);
            await dbContext.SaveChangesAsync();
            return Ok(new{message="Folder Created Successfully"});
        }
        [Authorize]

        [HttpPut("updateFolder")]
        public async Task<IActionResult> UpdateModule(int folderId, [FromBody] RequirementModule value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = _jwtTokenManage.getUserId(identity.Claims);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == value.projectId && s.role == "Designer").SingleOrDefault();
            if (permision == null)
            {
                return BadRequest(new { message = "You have not permision, only Designer can do this task" });
            }
            DesignFolder module = dbContext.folders.Where(s => s.id == folderId).SingleOrDefault();
            module.name = value.name;
            module.modifiedBy = Convert.ToInt16(userId);
            module.modifeidOn = DateTime.Now;
            dbContext.folders.Update(module);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Folder Updated Successfully" });
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(int projectId,int folderId,[FromForm]Design value)
        {
          
           try{
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManage.getUserId(claim);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&  s.pid == projectId && s.role == "Designer").SingleOrDefault();
            if(permision==null)
            {
                return BadRequest(new { message = "You have not permision, only Designer can do this task" });
            }
            Design req=new Design();
            req.Name = value.Name;
            req.Description = value.Description;
            req.folderId = folderId;
            req.url=value.url;
            dbContext.Designs.Add(req);
            dbContext.SaveChanges();

            if(value.file!=null){
            foreach(var file in value.file){
            DesignAttachment attachment= new DesignAttachment();

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
                attachment.name = fileName;
                attachment.AttachmentExtension = fileExtension;
                attachment.AttachmentPath = newFileName;
                attachment.designId = req.id;
                dbContext.DesignAttachments.Add(attachment);
                
            }
            
            }
            await dbContext.SaveChangesAsync();
            }
            return Ok(new { message = "Design Created" });
           }
           catch(Exception ex){
               return Ok(new { message = ex.Message });
           }
        }
        [Authorize]
        [HttpGet("get/{projectId}")]
        public  IActionResult Get(int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var folders = dbContext.folders.Where(s => s.projectId == projectId && s.folderType=="Design").ToList();
                List <object> folderArray = new List<object>();
                if(folders!=null)
                {
                    foreach(var item in folders)
                    {
                        List <object> designArray = new List<object>();
                        var design = dbContext.Designs.Where(s => s.folderId == item.id).ToList();
                        if(design==null)
                        {
                            return BadRequest(new { message = "No Design Found" });
                        }
                        foreach(var reqItem in design)
                        {
                            var attachments = dbContext.DesignAttachments.Where(s => s.designId == reqItem.id).ToList();
                            List<object> attachmentsArray = new List<object>();
                            if(attachments!=null)
                            {
                                foreach(var attachment in attachments)
                                {
                                    attachmentsArray.Add(new { id=attachment.id,name = attachment.name, AttachmentExtension = attachment.AttachmentExtension, AttachmentPath = "http://localhost:5000/api/Document/FileAPI/"+attachment.AttachmentPath });
                                }
                            }
                            object reqObj = new { id = reqItem.id, Name = reqItem.Name, description = reqItem.Description, url = reqItem.url, attachments = attachmentsArray };
                            designArray.Add(reqObj);
                        }
                        object module = 
                        new { 
                        id = item.id, 
                        folderName = item.name, 
                        
                        modifiedBy = item.modifiedBy,
                        modifeidOn = item.modifeidOn, 
                        projectId = item.projectId, 
                        Design = designArray 
                        };
                        folderArray.Add(module);
                    }
                }
                return Ok(folderArray);
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Update(int projectId,int designId,[FromForm]Design value)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&s.pid==projectId&& s.role == "Designer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Designer can perform requirement update" });
                }
                var req = await dbContext.Designs.Where(s => s.id == designId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Design not found" });
                }
                req.Name = value.Name;
                req.Description = value.Description;
                req.url=value.url;
                
                dbContext.Designs.Update(req);
                dbContext.SaveChanges();
                if(value.file!=null)
                {
                      foreach(var file in value.file)
                {
                    DesignAttachment attachment = new DesignAttachment();
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
                        attachment.name = fileName;
                        attachment.AttachmentExtension = fileExtension;
                        attachment.AttachmentPath = newFileName;
                        attachment.designId = req.id;
                        dbContext.DesignAttachments.Add(attachment);

                    }
                }
                await dbContext.SaveChangesAsync();

                }
                return Ok(new { message = "Design Updated" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int designId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == projectId && s.role == "Designer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Designer can perform requirement delete" });
                }
                var req = await dbContext.Designs.Where(s => s.id == designId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Requirement not found" });
                }
                dbContext.Designs.Remove(req);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Designs Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteAttachment")]
        public async Task<IActionResult> DeleteAttachment(int attachmentId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid==projectId &&s.role == "Designer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Designer can perform requirement delete" });
                }
                var attachment = await dbContext.DesignAttachments.Where(s => s.id == attachmentId).SingleOrDefaultAsync();
                if(attachment==null)
                {
                    return BadRequest(new { message = "Attachment not found" });
                }
                dbContext.DesignAttachments.Remove(attachment);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Attachment Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("desleteFolder")]
        public async Task<IActionResult> DeleteModule(int folderId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&s.pid==projectId && s.role == "Designer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Designer can perform requirement delete" });
                }
                var folder = await dbContext.folders.Where(s => s.id == folderId).SingleOrDefaultAsync();
                if(folder==null)
                {
                    return BadRequest(new { message = "Module not found" });
                }
                var Design = dbContext.Designs.Where(s => s.folderId == folder.id).ToList();
                if(Design.Count>0)
                {
                    return BadRequest(new { message = "Module has Design, can't delete" });
                }
                dbContext.folders.Remove(folder);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Module Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        
 
  }
}
