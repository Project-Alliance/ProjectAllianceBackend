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
    public class RequirementsController : Controller
    {
        // GET: api/values

        private readonly ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public RequirementsController(ApiDbContext _dbContext,IJwtTokenManager _jwtTokenManage)
        {
            this.dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
        }
      

       [Authorize]
        [HttpPost("createModule/{projectId}")]
        public async Task<IActionResult> CreateModule(int projectId, [FromBody] RequirementModule value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = _jwtTokenManage.getUserId(identity.Claims);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&  s.pid == projectId && s.role == "Requirement Engineer").SingleOrDefault();
            if(permision==null)
            {
                return BadRequest(new { message = "You have not permision, only Requirement Engineer can do this task" });
            }
            RequirementModule module = new RequirementModule();
            module.name = value.name;
            module.status = value.status;
            module.modifiedBy = userId;
            module.modifeidOn = DateTime.Now;
            module.projectId = projectId;
            dbContext.RequirementsModule.Add(module);
            await dbContext.SaveChangesAsync();
            return Ok(new{message="Module Created Successfully"});
        }
        [Authorize]

        [HttpPut("updateModule")]
        public async Task<IActionResult> UpdateModule(int moduleId, [FromBody] RequirementModule value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userId = _jwtTokenManage.getUserId(identity.Claims);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == value.projectId && s.role == "Requirement Engineer").SingleOrDefault();
            if (permision == null)
            {
                return BadRequest(new { message = "You have not permision, only Requirement Engineer can do this task" });
            }
            RequirementModule module = dbContext.RequirementsModule.Where(s => s.id == moduleId).SingleOrDefault();
            module.name = value.name;
            module.status = value.status;
            module.modifiedBy = userId;
            module.modifeidOn = DateTime.Now;
            dbContext.RequirementsModule.Update(module);
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Module Updated Successfully" });
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(int projectId,int moduleId,[FromForm]Requirements value)
        {
          
           try{
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManage.getUserId(claim);
            var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&  s.pid == projectId && s.role == "Requirement Engineer").SingleOrDefault();
            if(permision==null)
            {
                return BadRequest(new { message = "You have not permision, only Requirement Engineer can do this task" });
            }
            Requirements req=new Requirements();
            req.name = value.name;
            req.status = value.status;
            req.requirementDescription = value.requirementDescription;
            req.requirementType=value.requirementType;
            req.moduleId=moduleId;
            req.modifiedBy = userId;
            req.modifeidOn = DateTime.Now;
            dbContext.requirements.Add(req);
            dbContext.SaveChanges();
            if(value.file!=null)
            {foreach(var file in value.file){
                RequirementAttachment attachment= new RequirementAttachment();

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
                attachment.requirementId = req.id;
                dbContext.RequirementAttachments.Add(attachment);
                
            }
            
            }
            await dbContext.SaveChangesAsync();}
            return Ok(new { message = "Requirement Created" });
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
                var req = dbContext.RequirementsModule.Where(s => s.projectId == projectId).ToList();
                List <object> modules = new List<object>();
                if(req!=null)
                {
                    foreach(var item in req)
                    {
                        List <object> requirementsArray = new List<object>();
                        var requirements = dbContext.requirements.Where(s => s.moduleId == item.id).ToList();
                        if(requirements==null)
                        {
                            return BadRequest(new { message = "No Requirement Found" });
                        }
                        foreach(var reqItem in requirements)
                        {
                            var attachments = dbContext.RequirementAttachments.Where(s => s.requirementId == reqItem.id).ToList();
                            List<object> attachmentsArray = new List<object>();
                            if(attachments!=null)
                            {
                                foreach(var attachment in attachments)
                                {
                                    attachmentsArray.Add(new { id=attachment.id,name = attachment.name, AttachmentExtension = attachment.AttachmentExtension, AttachmentPath = "http://192.168.43.107:5005/api/Document/FileAPI/"+attachment.AttachmentPath });
                                }
                            }
                            object reqObj = new { id = reqItem.id, name = reqItem.name, status = reqItem.status, requirementDescription = reqItem.requirementDescription, requirementType = reqItem.requirementType, attachments = attachmentsArray };
                            requirementsArray.Add(reqObj);
                        }
                        object module = 
                        new { 
                        id = item.id, 
                        moduleName = item.name, 
                        moduleStatus = item.status, 
                        modifiedBy = item.modifiedBy,
                        modifeidOn = item.modifeidOn, 
                        projectId = item.projectId, 
                        requirements = requirementsArray 
                        };
                        modules.Add(module);
                    }
                }
                return Ok(modules);
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Update(int reqId,int projectId,[FromForm]Requirements value)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&s.pid==projectId&& s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement update" });
                }
                var req = await dbContext.requirements.Where(s => s.id == reqId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Requirement not found" });
                }
                req.name = value.name;
                req.status = value.status;
                req.requirementDescription = value.requirementDescription;
                req.requirementType = value.requirementType;
                req.modifiedBy = userId;
                req.modifeidOn = DateTime.Now;
                dbContext.requirements.Update(req);
                dbContext.SaveChanges();
                foreach(var file in value.file)
                {
                    RequirementAttachment attachment = new RequirementAttachment();
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
                        attachment.requirementId = req.id;
                        dbContext.RequirementAttachments.Add(attachment);

                    }
                }
                await dbContext.SaveChangesAsync();

                return Ok(new { message = "Requirement Updated" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int reqId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.pid == projectId && s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement delete" });
                }
                var req = await dbContext.requirements.Where(s => s.id == reqId).SingleOrDefaultAsync();
                if(req==null)
                {
                    return BadRequest(new { message = "Requirement not found" });
                }
                dbContext.requirements.Remove(req);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Requirement Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteAttachment")]
        public async Task<IActionResult> DeleteAttachment(int attachmentId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) && s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement delete" });
                }
                var attachment = await dbContext.RequirementAttachments.Where(s => s.id == attachmentId).SingleOrDefaultAsync();
                if(attachment==null)
                {
                    return BadRequest(new { message = "Attachment not found" });
                }
                dbContext.RequirementAttachments.Remove(attachment);
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Attachment Deleted" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("deleteModule")]
        public async Task<IActionResult> DeleteModule(int moduleId,int projectId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;
                string userId = _jwtTokenManage.getUserId(claim);
                var permision = dbContext.ProjectTeams.Where(s => s.uid == Convert.ToInt16(userId) &&s.pid==projectId && s.role == "Requirement Engineer").SingleOrDefault();
                if (permision == null)
                {
                    return BadRequest(new { message = "You have not permision, only Requirement Engineer can perform requirement delete" });
                }
                var module = await dbContext.RequirementsModule.Where(s => s.id == moduleId).SingleOrDefaultAsync();
                if(module==null)
                {
                    return BadRequest(new { message = "Module not found" });
                }
                var requirement = dbContext.requirements.Where(s => s.moduleId == module.id).ToList();
                if(requirement.Count>0)
                {
                    return BadRequest(new { message = "Module has requirement, can't delete" });
                }
                dbContext.RequirementsModule.Remove(module);
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
