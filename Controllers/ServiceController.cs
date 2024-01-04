using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;
using static Hephaestus.Logs;


namespace PrismAPI.Controllers
{
    public class ServiceController : ApiController
    {
        // GET: Service
        public Logger Log = null;
        public ServiceController()
        {
            Log = Logger.GetLogger();
        }

        ServiceDAL serviceDAL = new ServiceDAL();

        [HttpGet]
        [ActionName("GetAllService")]
        public List<Service> GetAllService()
        {
            Log.writeMessage("ServiceController GetAllService Start");
            List<Service> list = null;
            try
            {
                list = serviceDAL.GetAllService();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController GetAllService Error " + ex.Message);
            }
            Log.writeMessage("ServiceController GetAllService End");
            return list;
        }
        public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

                    File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();
        }
        public IHttpActionResult DeleteService(int Id)
        {
            try
            {
                var result = serviceDAL.DeleteService(Id);

                if (result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("FirstController DeleteFirstModel Error " + ex.Message);
            }
            return Ok("Failed");
        }
        [HttpGet]
        [ActionName("GetServiceById")]
        public Service GetServiceById(int Id)
        {
            Log.writeMessage("ServiceController GetServiceById Start");
            Service Service = null;
            try
            {
                Service = serviceDAL.GetServiceById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController GetServiceById Error " + ex.Message);
            }
            Log.writeMessage("ServiceController GetServiceById End");
            return Service;
        }

        /* [HttpGet]
         [ActionName("GetServiceByEmail")]
         public Service GetServiceByEmail(string Email)
         {
             Log.writeMessage("ServiceController GetServiceByEmail Start");
             Service Service = null;
             try
             {
                 Service = ServiceDAL.GetServiceByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("ServiceController GetServiceByEmail Error " + ex.Message);
             }
             Log.writeMessage("ServiceController GetServiceByEmail End");
             return Service;
         }*/

        [HttpPost]
        [ActionName("AddService")]
        public IHttpActionResult AddService(Service Service)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Service.CreatedBy = "Admin";
                Service.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Service.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Service.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = serviceDAL.AddService(Service);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController AddService Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateService")]
        public IHttpActionResult UpdateService(Service Service)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Service.CreatedBy = "Admin";
                Service.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Service.UpdatedBy = "Admin";
                Service.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = serviceDAL.UpdateService(Service);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController AddService Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("ServiceController GetServiceById Start");
    Loginc user = null;
    try
    {
        user = ServiceDAL.ServiceDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("ServiceController GetServiceById Error " + ex.Message);
    }
    Log.writeMessage("ServiceController GetServiceById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("ServiceController GetServiceById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = ServiceDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("ServiceController GetServiceById Error " + ex.Message);
    }
    Log.writeMessage("ServiceController GetServiceById End");
    return OtpNo;
}*/
// PUT: api/Address/5
//[HttpPut]
//[ActionName("UpdateFirstModel")]
//public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
//{
//    try
//    {
//        if (!ModelState.IsValid)
//        {
//            return BadRequest(ModelState);
//        }
//        var result = firstDAL.UpdateFirstModel(firstModel);




//        if (result == "Success")
//        {
//            return Ok("Success");
//        }
//        else
//        {
//            return Ok("Failed");
//        }
//    }
//    catch (Exception ex)
//    {
//        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
//    }
//    return Ok("Failed");
//}

//// DELETE: api/Address/5

//public IHttpActionResult DeleteFirstModel(int Id)
//{
//    try
//    {
//        var result = firstDAL.DeleteFirstModel(Id);

//        if (result == "Success")
//        {
//            return Ok("Success");
//        }
//        else
//        {
//            return Ok("Failed");
//        }
//    }
//    catch (Exception ex)
//    {
//        Log.writeMessage("FirstController DeleteFirstModel Error " + ex.Message);
//    }
//    return Ok("Failed");
//}


//[HttpPost]
//public async Task<IActionResult> SendMail([FromBody] Email email)
//{
//    Console.WriteLine("Sending email");
//    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
//    client.UseDefaultCredentials = false;
//    client.EnableSsl = true;
//    client.Credentials = new System.Net.NetworkCredential(emailid, password);
//    var mailMessage = new System.Net.Mail.MailMessage();
//    mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
//    mailMessage.To.Add(email.To);
//    mailMessage.Body = email.Text;
//    await client.SendMailAsync(mailMessage);
//    return Ok();
//}


/*[HttpPost]
public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
{
    try
    {
        if (!Request.Content.IsMimeMultipartContent())
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        var provider = new MultipartMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(provider);
        foreach (var file in provider.Contents)
        {
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            //get the folder that's in
            string theDirectory = Path.GetDirectoryName(fullPath);
            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.
        }
    }
    catch (Exception ex)
    {
        Log.writeMessage(ex.Message);
    }

    return Ok();
}*/
//[HttpPost]
//public void SaveProfilePhoto(UserProfilePhoto profile)
//{
//    try
//    {
//        byte[] imageBytes = Convert.FromBase64String(profile.Photo);
//        string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
//        string theDirectory = Path.GetDirectoryName(fullPath);
//        theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
//        //string filePath = "http://localhost:62842/ProfilePhoto/";
//        File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "ProfilePicture_" + profile.Id + ".jpeg", imageBytes);
//        //File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);

//    }
//    catch (Exception ex)
//    {
//        Log.writeMessage(ex.Message);
//    }
//}

/*
[HttpPost]
public async Task<IHttpActionResult> SaveServiceImage(int Id)
{
    try
    {
        if (!Request.Content.IsMimeMultipartContent())
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        var provider = new MultipartMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(provider);
        foreach (var file in provider.Contents)
        {
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
            //get the folder that's in
            string theDirectory = Path.GetDirectoryName(fullPath);
            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
            File.WriteAllBytes(theDirectory + "/Content/Service" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Service = ServiceDAL.GetServiceById(Id);
            var filenamenew = Id + "_" + filename;
            if (Service.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Service" + "/" + Service.Photo);
                Service.Photo = Id + "_" + filename;
                var result = ServiceDAL.UpdateService(Service);

            }
        }
    }
    catch (Exception ex)
    {
        Log.writeMessage(ex.Message);
    }

    return Ok();
}
}
}*/