using System;
namespace ProjectAlliance.Controllers
{
    public class SampleCode
    {
        public SampleCode()
        {
        }
    }
}


//[HttpPost("signup")]
//public IActionResult Post([FromBody] User value)
//{

//    var VerifyEmail = dbContext.Users
//               .Where(s => s.email == value.email)
//               .FirstOrDefault();
//    var VerifyCompany = dbContext.Company
//              .Where(s => s.companyName == value.companyId)
//              .FirstOrDefault();
//    if(VerifyCompany!=null)
//    {
//        object res = new
//        {
//            message = "Company Already Exists.",
//        };

//        return BadRequest(res);
//    }

//    if (VerifyEmail != null)
//    {
//        object res = new
//        {
//            message = "email Already Exists.",
//        };

//        return BadRequest(res);
//    }
//    else
//    {
//        var VerifyUserName = dbContext.Users
//              .Where(s => s.userName == value.userName)
//              .FirstOrDefault();
//        if (VerifyUserName != null)
//        {
//            object res = new
//            {
//                message = "UserName Already Exists.",
//            };

//            return BadRequest(res);
//        }

//        User user = new User();
//        Company comp = new Company();
//        user.name = value.name;
//        user.email = value.email;
//        user.phone = value.phone;
//        user.userName = value.userName;
//        user.role = "admin";
//        user.password= BCryptNet.HashPassword(value.password);
//        comp.companyName = value.companyId;

//        dbContext.Company.Add(comp);
//        dbContext.SaveChanges();
//        user.companyId = comp.id.ToString();
//        dbContext.Users.Add(user);

//        comp.createdBy = user.userName;
//        dbContext.SaveChanges();

//        return Ok(user);

//    }


//}


//[HttpPost("addmembers")]
//public IActionResult AddMembers([FromBody] User value)
//{
//    try
//    {
//        var VerifyEmail = dbContext.Users
//                   .Where(s => s.email == value.email)
//                   .FirstOrDefault();



//        if (VerifyEmail != null)
//        {
//            object res = new
//            {
//                message = "email Already Exists.",
//            };

//            return BadRequest(res);
//        }
//        else
//        {

//            var VerifyUserName = dbContext.Users
//                  .Where(s => s.userName == value.userName)
//                  .FirstOrDefault();
//            if (VerifyUserName != null)
//            {
//                object res = new
//                {
//                    message = "UserName Already Exists.",
//                };

//                return BadRequest(res);
//            }

//            var comp = dbContext.Company
//                  .Where(s => s.companyName == value.company)
//                  .FirstOrDefault();

//            User user = new User();

//            user.name = value.name;
//            user.email = value.email;
//            user.phone = value.phone;
//            user.userName = value.userName;
//            user.role = "admin";
//            user.password = BCryptNet.HashPassword(value.password);
//            user.companyId = comp.id.ToString();


//            dbContext.SaveChanges();

//            dbContext.Users.Add(user);

//            comp.createdBy = user.userName;
//            dbContext.SaveChanges();

//            return Ok(user);

//        }
//    }
//    catch(Exception ex)
//    {
//        return NotFound((message: " Server error ", Exception: ex));
//    }


//}
