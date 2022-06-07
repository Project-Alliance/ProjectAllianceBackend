using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAlliance.Data;
using ProjectAlliance.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    public class QualityController : Controller
    {
        ApiDbContext dbContext;

        public QualityController(ApiDbContext dbcontext)
        {
            dbContext = dbcontext;
        }


        [Authorize]
        [HttpPost("addEnviorment")]
        public async Task<IActionResult> Post(int pid, [FromBody] Enviorment env)
        {
            if (ModelState.IsValid)
            {
                env.projectId = pid;
                if(env.isRequirementBased)
                {
                    env.RequirementId = env.RequirementId;
                }
                else
                {
                    env.RequirementId = 0;
                }
                dbContext.enviornment.Add(env);
                await dbContext.SaveChangesAsync();
                if (env.res != null)
                {
                    foreach (LabResource r in env.res)
                    {
                        r.EnvId = env.id;
                        dbContext.labResource.Add(r);
                    }
                    await dbContext.SaveChangesAsync();
                }
                return Ok(env);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpPost("addTestPlan")]
       public async Task<IActionResult> Post(int envId, [FromBody] TestPlan plan)
        {
            if (ModelState.IsValid)
            {
                plan.EnvId = envId;
                dbContext.testPlan.Add(plan);
                await dbContext.SaveChangesAsync();
                return Ok(plan);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpPost("addTestCase")]
        public async Task<IActionResult> Post(int testPlanId, [FromBody] TestCases test)
        {
            if (ModelState.IsValid)
            {
                test.testPlanId = testPlanId;
                dbContext.testCases.Add(test);
                await dbContext.SaveChangesAsync();
                return Ok(test);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpPost("addTestResult")]
        public async Task<IActionResult> Post(int testCaseId, [FromForm] TestResult result)
        {
            if (ModelState.IsValid)
            {
                result.testId = testCaseId;
                dbContext.testResult.Add(result);
                await dbContext.SaveChangesAsync();
                if (result.ExpectedOutcomeFile != null && result.testOutComeFile != null)
                {
                    foreach (var file in result.ExpectedOutcomeFile)
                    {
                        TestCaseAttachment attachment = new TestCaseAttachment();

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
                            attachment.testresultId = result.id;
                            attachment.AtttachmentType="ExpectedOutcome";
                            dbContext.TestCaseAttachment.Add(attachment);

                        }

                    }
                     foreach (var file in result.testOutComeFile)
                    {
                        TestCaseAttachment attachment = new TestCaseAttachment();

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
                            attachment.testresultId = result.id;
                            attachment.AtttachmentType="testOutCome";
                            dbContext.TestCaseAttachment.Add(attachment);

                        }

                    }
                    await dbContext.SaveChangesAsync();
                }
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [Authorize]
        [HttpGet("getResult")]
        public async Task<IActionResult> GetTestResult(int pid){
                
        }

        [Authorize]
        [HttpGet("getTestCases")]
        public async Task<IActionResult> Get(int pid)
        {
            var env = await dbContext.enviornment.Where(e => e.projectId == pid&& !e.isRequirementBased).ToListAsync();
            List<object> testCasesArray = new List<object>();
            foreach(var envioroment in env){
                List<object> planArray=new List<object>();
                var testPlan = await dbContext.testPlan.Where(t => t.EnvId == envioroment.id).ToListAsync();
                foreach(var tplan in testPlan){
                    
                    var testCases = await dbContext.testCases.Where(t=>t.id==tplan.id).ToListAsync();
                    var caseobject=new{
                        tplan.id,
                        tplan.EnvId,
                        tplan.Description,
                        tplan.Name,
                        testCases=testCases
                    
                    };
                    planArray.Add(caseobject);
                }
            var LabResource= await dbContext.labResource.Where(l=>l.EnvId==envioroment.id).ToListAsync();
                var envioromentobject=new{
                    envioroment.id,
                    envioroment.projectId,
                    envioroment.Description,
                    envioroment.Name,
                    envioroment.summary,
                    LabResource=LabResource,
                    plans=planArray
                };
                testCasesArray.Add(envioromentobject);
            }
            return Ok(testCasesArray);
        }
       [Authorize]
        [HttpGet("getRequirementBasedTestCases")]
        public async Task<IActionResult> GetTest(int pid)
        {
            var env = await dbContext.enviornment.Where(e => e.projectId == pid && e.isRequirementBased).ToListAsync();
            List<object> testCasesArray = new List<object>();
            foreach(var envioroment in env){
                List<object> planArray=new List<object>();
                var testPlan = await dbContext.testPlan.Where(t => t.EnvId == envioroment.id).ToListAsync();
                foreach(var tplan in testPlan){
                    
                    var testCases = await dbContext.testCases.Where(t=>t.id==tplan.id).ToListAsync();
                    var caseobject=new{
                        tplan.id,
                        tplan.EnvId,
                        tplan.Description,
                        tplan.Name,
                        testCases=testCases
                    
                    };
                    planArray.Add(caseobject);
                }
            var LabResource= await dbContext.labResource.Where(l=>l.EnvId==envioroment.id).ToListAsync();
                var envioromentobject=new{
                    envioroment.id,
                    envioroment.projectId,
                    envioroment.Description,
                    envioroment.Name,
                    envioroment.summary,
                    LabResource=LabResource,
                    plans=planArray
                };
                testCasesArray.Add(envioromentobject);
            }
            return Ok(testCasesArray);
        }
       
    }
}
