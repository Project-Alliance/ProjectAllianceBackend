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
    public class mailController : Controller
    {
        private readonly ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManage;

        public mailController(ApiDbContext _dbContext, IJwtTokenManager _jwtTokenManage)
        {
            this.dbContext = _dbContext;
            this._jwtTokenManage = _jwtTokenManage;
        }
        // GET: api/values
        [Authorize]
        [HttpGet("getRecivedMail")]
        public async Task<object> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            int userId = Convert.ToInt16(_jwtTokenManage.getUserId(claim));
            var user = await dbContext.Users.FindAsync(userId);
            var company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).SingleOrDefault();
            var mail = await dbContext.mail.Where(m => m.to == user.userName && m.company == company.companyName).ToListAsync();
            List<object> mailList = new List<object>();
            foreach (var m in mail)
            {
                var mailAttachment = await dbContext.mailAttachments.Where(ma => ma.emailId == m.id).ToListAsync();
                mailList.Add(new { m.id, m.subject, m.description,m.title, m.from, m.to, m.time, m.isRead, m.isStared, m.company, mailAttachment });
            }
            return Ok(mailList);
        }


        [HttpGet("getSentMail")]
        public async Task<object> GetSent()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            int userId = Convert.ToInt16(_jwtTokenManage.getUserId(claim));
            var user = await dbContext.Users.FindAsync(userId);
            var company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).SingleOrDefault();
            var mail = await dbContext.mail.Where(m => m.from == user.userName && m.company == company.companyName).ToListAsync();
            List<object> mailList = new List<object>();
            foreach (var m in mail)
            {
                var mailAttachment = await dbContext.mailAttachments.Where(ma => ma.emailId == m.id).ToListAsync();
                mailList.Add(new { m.id, m.subject, m.description, m.from, m.to, m.time, m.isRead, m.isStared, m.company, mailAttachment });
            }
            return Ok(mailList);
        }

        [HttpGet("getIsStarredMail")]
        public async Task<object> GetStared()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            int userId = Convert.ToInt16(_jwtTokenManage.getUserId(claim));
            var user = await dbContext.Users.FindAsync(userId);
            var company = dbContext.Company.Where(s => s.id == Convert.ToInt16(user.companyId)).SingleOrDefault();
            var mail = await dbContext.mail.Where(m => m.from == user.userName && m.company == company.companyName && m.isStared).ToListAsync();
            List<object> mailList = new List<object>();
            foreach (var m in mail)
            {
                var mailAttachment = await dbContext.mailAttachments.Where(ma => ma.emailId == m.id).ToListAsync();
                mailList.Add(new { m.id, m.subject, m.description, m.from, m.to, m.time, m.isRead, m.isStared, m.company, mailAttachment });
            }
            return Ok(mailList);
        }

        // POST api/values
        [HttpPost("sendMail")]
        public async Task<IActionResult> Post([FromForm] RecevidMail value)
        {
            foreach(var email in value.ToList)
            {
                RecevidMail mail = new RecevidMail();

                mail.to=email;
                mail.time = DateTime.Now;
                mail.isRead = false;
                mail.isStared = false;
                mail.subject = value.subject;
                mail.title = value.title;
                mail.description = value.description;
                mail.company = value.company;
                mail.from = value.from;


                    dbContext.mail.Add(mail);
                    dbContext.SaveChanges();
                    if (value.mailAttachment != null)
                    {
                        foreach (var file in value.mailAttachment)
                        {
                            EmailAttachment attachment = new EmailAttachment();

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
                                attachment.ext = newFileName;
                                attachment.path = "http://localhost:5000/api/Document/FileAPI/"+newFileName;
                                attachment.emailId = mail.id;
                                dbContext.mailAttachments.Add(attachment);

                            }

                        }
                        await dbContext.SaveChangesAsync();

                    }
                    }
            return Ok(new {message = "Mail Sent Successfully"});
        }

        // PUT api/values/5
        [HttpPut("updateMailIsRead")]
        public IActionResult Put(int mailId)
        {
            var mail = dbContext.mail.Find(mailId);
            if(mail != null)
            {
                mail.isRead = true;
                dbContext.SaveChanges();
                return Ok(new { message = "Mail Read Successfully" });
            }
            else {
                return BadRequest(new { message = "Mail Not Found" });
            }
        }

        [HttpPut("updateMailIsStared")]
        public IActionResult PutIsStar(int mailId)
        {
            var mail = dbContext.mail.Find(mailId);
            if(mail != null)
            {
                mail.isStared = !mail.isStared;
                dbContext.SaveChanges();
                return Ok(new { message = "Mail Stared Successfully" });
            }
            else {
                return BadRequest(new { message = "Mail Not Found" });
            }
        }

        // DELETE api/values/5
        [HttpDelete("deleteMail")]
        public IActionResult Delete(int mailId)
        {
            var mail = dbContext.mail.Find(mailId);
            if(mail != null)
            {
                var mailAttachment = dbContext.mailAttachments.Where(ma => ma.emailId == mailId).ToList();
                if(mailAttachment != null)
                {
                    foreach(var ma in mailAttachment)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", ma.ext);
                        System.IO.File.Delete(filePath);
                        dbContext.mailAttachments.Remove(ma);
                    }
                }
                dbContext.mail.Remove(mail);
                dbContext.SaveChanges();
                return Ok(new { message = "Mail Deleted Successfully" });
            }
            else {
                return BadRequest(new { message = "Mail Not Found" });
            }
        }
    }
}
