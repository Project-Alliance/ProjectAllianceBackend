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
        [HttpPut("updateEnviorment")]
        public async Task<IActionResult> Put(int id, [FromBody] Enviorment env)
        {
            if (ModelState.IsValid)
            {
                Enviorment enviorment = await dbContext.enviornment.FindAsync(id);
                if (enviorment == null)
                {
                    return NotFound();
                }
                enviorment.Name = env.Name;
                enviorment.Description = env.Description;
                enviorment.summary = env.summary;
                enviorment.TestType = env.TestType;
                dbContext.enviornment.Update(enviorment);
                await dbContext.SaveChangesAsync();
                if (env.res != null)
                {
                    foreach (LabResource r in env.res)
                    {
                        r.EnvId = env.id;
                        dbContext.labResource.Update(r);
                    }
                    await dbContext.SaveChangesAsync();
                }
                return Ok(enviorment);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpDelete("deleteEnviorment")]
        public async Task<IActionResult> Delete(int id)
        {
            Enviorment enviorment = await dbContext.enviornment.FindAsync(id);
            if (enviorment == null)
            {
                return NotFound();
            }
            foreach (LabResource r in dbContext.labResource.Where(x => x.EnvId == id).ToList())
            {
                dbContext.labResource.Remove(r);
            }
            foreach(TestPlan t in dbContext.testPlan.Where(x => x.EnvId == id).ToList())
            {
                foreach(TestCases i in dbContext.testCases.Where(x => x.testPlanId == t.id).ToList())
                {
                    foreach(TestResult r in dbContext.testResult.Where(x => x.testId == i.id).ToList())
                    {
                        foreach(TestCaseAttachment d in dbContext.TestCaseAttachment.Where(x => x.testresultId == r.id).ToList())
                        {
                            dbContext.TestCaseAttachment.Remove(d);
                        }
                        dbContext.testResult.Remove(r);
                    }
                    dbContext.testCases.Remove(i);
                }
                dbContext.testPlan.Remove(t);
            }
            dbContext.enviornment.Remove(enviorment);
            await dbContext.SaveChangesAsync();
            return Ok(enviorment);
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
        [HttpPut("updateTestPlan")]

        public async Task<IActionResult> Put(int id, [FromBody] TestPlan plan)
        {
            if (ModelState.IsValid)
            {
                TestPlan testPlan = await dbContext.testPlan.FindAsync(id);
                if (testPlan == null)
                {
                    return NotFound();
                }
                testPlan.Name = plan.Name;
                testPlan.Description = plan.Description;
                dbContext.testPlan.Update(testPlan);
                await dbContext.SaveChangesAsync();
                return Ok(testPlan);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpGet("deleteTestPlan")]
        public async Task<IActionResult> DeleteA(int id)
        {
            TestPlan testPlan = await dbContext.testPlan.FindAsync(id);
            if (testPlan == null)
            {
                return NotFound();
            }
            foreach (TestCases i in dbContext.testCases.Where(x => x.testPlanId == id).ToList())
            {
                foreach (TestResult r in dbContext.testResult.Where(x => x.testId == i.id).ToList())
                {
                    foreach (TestCaseAttachment d in dbContext.TestCaseAttachment.Where(x => x.testresultId == r.id).ToList())
                    {
                        dbContext.TestCaseAttachment.Remove(d);
                    }
                    dbContext.testResult.Remove(r);
                }
                dbContext.testCases.Remove(i);
            }
            dbContext.testPlan.Remove(testPlan);
            await dbContext.SaveChangesAsync();
            return Ok(testPlan);
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
        [HttpPut("updateTestCase")]
        public async Task<IActionResult> Put(int id, [FromBody] TestCases test)
        {
            if (ModelState.IsValid)
            {
                TestCases testCases = await dbContext.testCases.FindAsync(id);
                if (testCases == null)
                {
                    return NotFound();
                }
                testCases.Name = test.Name;
                testCases.categoryName = test.categoryName;
                testCases.testType = test.testType;
                testCases.categoryType = test.categoryType;
                dbContext.testCases.Update(testCases);
                await dbContext.SaveChangesAsync();
                return Ok(testCases);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpGet("deleteTestCase")]
        public async Task<IActionResult> DeleteB(int id)
        {
            TestCases testCases = await dbContext.testCases.FindAsync(id);
            if (testCases == null)
            {
                return NotFound();
            }
            foreach (TestResult r in dbContext.testResult.Where(x => x.testId == id).ToList())
            {
                foreach (TestCaseAttachment d in dbContext.TestCaseAttachment.Where(x => x.testresultId == r.id).ToList())
                {
                    dbContext.TestCaseAttachment.Remove(d);
                }
                dbContext.testResult.Remove(r);
            }
            dbContext.testCases.Remove(testCases);
            await dbContext.SaveChangesAsync();
            return Ok(testCases);
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
        [HttpPut("deleteTestResult")]
        public async Task<IActionResult> DeleteR(int id)
        {
            TestResult testResult = await dbContext.testResult.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }
            dbContext.testResult.Remove(testResult);
            await dbContext.SaveChangesAsync();
            return Ok(testResult);
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
