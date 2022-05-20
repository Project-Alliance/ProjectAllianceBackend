using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.Data;
using ProjectAlliance.Services;
using ProjectAlliance.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class PermisionsController : Controller
    {
       
        ApiDbContext dbContext;
        public readonly IJwtTokenManager _jwtTokenManager;
        List<Permisions> permisions=new List<Permisions>();
        
        public PermisionsController( IJwtTokenManager jwtTokenManager, ApiDbContext _dbContext)
        {
            
            this._jwtTokenManager = jwtTokenManager;
            this.dbContext = _dbContext;
            List<object> list=new List<object>(new []{
                    new {permisionTitle="manageMember",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageProjects",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageTasks",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="goalsManagement",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="managePermisions",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageRoles",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageUsers",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageReports",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageSettings",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageNotifications",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageCalendar",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageFiles",read=false,updtae=false,delete=false,create=false},
                    new {permisionTitle="manageMessages",read=false,updtae=false,delete=false,create=false},
                    });
            foreach (var item in list)
            {
                permisions.Add(new Permisions()
                {
                    permisionTitle = item.GetType().GetProperty("permisionTitle").GetValue(item).ToString(),
                    read = Convert.ToBoolean(item.GetType().GetProperty("read").GetValue(item)),
                    update = Convert.ToBoolean(item.GetType().GetProperty("updtae").GetValue(item)),
                    Delete = Convert.ToBoolean(item.GetType().GetProperty("delete").GetValue(item)),
                    create = Convert.ToBoolean(item.GetType().GetProperty("create").GetValue(item))
                });
            }
           
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // var identity = HttpContext.User.Identities as ClaimsIdentity;
            // IEnumerable<Claim> claims = identity.Claims;
            //  string id=_jwtTokenManager.getUserId(claims);
           
                var permisionList = dbContext.permisions.Where(s => s.userId == Convert.ToInt16(id)).ToList();
                if (permisionList != null)
                    return Ok(new { meassage = "successfully get permisions", data = permisionList,newadded=false, });
                else
                    return BadRequest(new { meassage = "no permisions found", newadded=true,permisions });

        }

        // POST api/values
        [Authorize]
        [HttpPut]
        public object Post([FromBody] List<Permisions> value)
        {
           
           
        var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;
            string userId = _jwtTokenManager.getUserId(claim);
            var checkPermisions=dbContext.permisions.Where(s=>s.userId==Convert.ToInt16(userId)&&(s.permisionTitle=="superUser"||s.permisionTitle=="managePermisions")).SingleOrDefault();
            if(!checkPermisions.update)
                return Ok(new { meassage = "Not allowed to update" });  
           foreach (var item in value)
                {
                    var PERMISION = dbContext.permisions.Where(s => s.permisionId == item.permisionId).FirstOrDefault();
                    if (PERMISION != null)
                    {
                        PERMISION.read = item.read;
                        PERMISION.update = item.update;
                        PERMISION.Delete = item.Delete;
                        PERMISION.create = item.create;
                        dbContext.permisions.Update(PERMISION);
                    }
                    
                }
                dbContext.SaveChanges();
                return Ok(new { meassage = "successfully updated permisions", data = value });
           
            

        }

        public void AddPermisionsToNewMembers(int id,string role){

            if (role == "Moderator")
            {
                foreach (var permision in permisions)
                {
                    permision.create = true;
                    permision.Delete = false;
                    permision.read = true;
                    permision.update = true;
                    permision.userId = id;
                    permision.permisionTitle = permision.permisionTitle;
                    dbContext.permisions.Update(permision);

                }
                dbContext.SaveChanges();
            }
            else{
                foreach (var permision in permisions)
                {
                    permision.create = false;
                    permision.Delete = false;
                    permision.read = true;
                    permision.update = false;
                    permision.userId = id;
                    permision.permisionTitle = permision.permisionTitle;
                    dbContext.permisions.Update(permision);

                }
                dbContext.SaveChanges();
            }
        }
       

      
    }
}
