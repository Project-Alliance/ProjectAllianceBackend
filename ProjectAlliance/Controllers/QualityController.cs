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
        [HttpGet("getTestCases")]
        public async Task<IActionResult> Get(int pid)
        {
            var env = await dbContext.enviornment.Where(e => e.projectId == pid&& !e.isRequirementBased).ToListAsync();
            List<object> EnvArray = new List<object>();
            foreach(var envioroment in env){
                List<object> planArray=new List<object>();
                var testPlan = await dbContext.testPlan.Where(t => t.EnvId == envioroment.id).ToListAsync();
                foreach(var tplan in testPlan){
                    List<object> testCasesArray=new List<object>();
                    var testCases = await dbContext.testCases.Where(t=>t.testPlanId==tplan.id).ToListAsync();
                    foreach(var test in testCases)
                    {
                        
                        var resultTestCase=dbContext.testResult.Where(s=>s.testId==test.id).ToList();
                        List<object> resultArray=new List<object>();
                        foreach(var result in resultTestCase)
                        {
                            
                            List<object> ExpectedOutcome=new List<object>();
                            List<object> testOutCome=new List<object>();
                            var resultAttachment=dbContext.TestCaseAttachment.Where(s=>s.testresultId==result.id&&s.AtttachmentType=="ExpectedOutcome").ToList();
                            foreach(var ra in resultAttachment){
                                object obj1=new {
                                    ra.AttachmentExtension,
                                    AttachmentPath= "http://192.168.43.107:5005/api/Document/FileAPI/" + ra.AttachmentPath,
                                    ra.AtttachmentType,
                                    ra.id,
                                    ra.name
                                };
                                ExpectedOutcome.Add(obj1);
                            }
                            var resultAttachment2=dbContext.TestCaseAttachment.Where(s=>s.testresultId==result.id&&s.AtttachmentType=="testOutCome").ToList();
                            foreach(var ra in resultAttachment2){
                                object obj2=new {
                                    ra.AttachmentExtension,
                                    AttachmentPath= "http://192.168.43.107:5005/api/Document/FileAPI/" + ra.AttachmentPath,
                                    ra.AtttachmentType,
                                    ra.id,
                                    ra.name
                                };
                                testOutCome.Add(obj2);
                            }
                            resultArray.Add(new{
                                result.Description,
                                result.id,
                                result.testId,
                                ExpectedOutcome,
                                testOutCome
                            });
                        }
                        var obj = new
                        {
                            test.categoryName,
                            test.Name,
                            test.categoryType,
                            test.testType,
                            test.id,
                            test.testPlanId,
                            testResult = resultArray
                        };
                        testCasesArray.Add(obj);
                      
                        
                    }
                    var caseobject=new{
                        tplan.id,
                        tplan.EnvId,
                        tplan.Description,
                        tplan.Name,
                        testCases=testCasesArray
                    
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
                EnvArray.Add(envioromentobject);
            }
            return Ok(EnvArray);
        }
       [Authorize]
        [HttpGet("getRequirementBasedTestCases")]
          public async Task<IActionResult> GetTest(int pid)
        {
            var env = await dbContext.enviornment.Where(e => e.projectId == pid&& e.isRequirementBased).ToListAsync();
            List<object> EnvArray = new List<object>();
            foreach(var envioroment in env){
                List<object> planArray=new List<object>();
                var testPlan = await dbContext.testPlan.Where(t => t.EnvId == envioroment.id).ToListAsync();
                foreach(var tplan in testPlan){
                    List<object> testCasesArray=new List<object>();
                    var testCases = await dbContext.testCases.Where(t=>t.testPlanId==tplan.id).ToListAsync();
                    foreach(var test in testCases)
                    {
                        
                        var resultTestCase=dbContext.testResult.Where(s=>s.testId==test.id).ToList();
                        List<object> resultArray=new List<object>();
                        foreach(var result in resultTestCase)
                        {
                            
                            List<object> ExpectedOutcome=new List<object>();
                            List<object> testOutCome=new List<object>();
                            var resultAttachment=dbContext.TestCaseAttachment.Where(s=>s.testresultId==result.id&&s.AtttachmentType=="ExpectedOutcome").ToList();
                            foreach(var ra in resultAttachment){
                                object obj=new {
                                    ra.AttachmentExtension,
                                    AttachmentPath="http://localhost:5000/Files/"+ra.AttachmentPath,
                                    ra.AtttachmentType,
                                    ra.id,
                                    ra.name
                                };
                                ExpectedOutcome.Add(obj);
                            }
                            var resultAttachment2=dbContext.TestCaseAttachment.Where(s=>s.testresultId==result.id&&s.AtttachmentType=="testOutCome").ToList();
                            foreach(var ra in resultAttachment2){
                                object obj=new {
                                    ra.AttachmentExtension,
                                    AttachmentPath="http://localhost:5000/Files/"+ra.AttachmentPath,
                                    ra.AtttachmentType,
                                    ra.id,
                                    ra.name
                                };
                                testOutCome.Add(obj);
                            }
                            resultArray.Add(new{
                                result.Description,
                                result.id,
                                result.testId,
                                ExpectedOutcome,
                                testOutCome
                            });
                        }
                        testCasesArray.Add(new{
                            test.categoryName,
                            test.Name,
                            test.categoryType,
                            test.testType,
                            test.id,
                            test.testPlanId,
                            testResult=resultArray
                        });
                      
                        
                    }
                    var caseobject=new{
                        tplan.id,
                        tplan.EnvId,
                        tplan.Description,
                        tplan.Name,
                        testCases=testCasesArray
                    
                    };
                    planArray.Add(caseobject);
                }
            var LabResource= await dbContext.labResource.Where(l=>l.EnvId==envioroment.id).ToListAsync();
                var envioromentobject=new{
                    envioroment.id,
                    envioroment.RequirementId,
                    envioroment.projectId,
                    envioroment.Description,
                    envioroment.Name,
                    envioroment.summary,
                    LabResource=LabResource,
                    plans=planArray
                };
                EnvArray.Add(envioromentobject);
            }
            return Ok(EnvArray);
        }
      
    }
}
