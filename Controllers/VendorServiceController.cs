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


namespace PrismAPI.Controllers
{
    public class VendorServiceController : ApiController
    {
        // GET: VendorService
        public Logger Log = null;
        public VendorServiceController()
        {
            Log = Logger.GetLogger();
        }

        VendorServiceDAL vendorserviceDAL = new VendorServiceDAL();

        [HttpGet]
        [ActionName("GetAllVendorService")]
        public List<VendorService> GetAllVendorService()
        {
            Log.writeMessage("VendorServiceController GetAllVendorService Start");
            List<VendorService> list = null;
            try
            {
                list = vendorserviceDAL.GetAllVendorService();
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorServiceController GetAllVendorService Error " + ex.Message);
            }
            Log.writeMessage("VendorServiceController GetAllVendorService End");
            return list;
        }
        public IHttpActionResult DeleteVendorService(int Id)
        {
            try
            {
                var result = vendorserviceDAL.DeleteVendorService(Id);

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
        [ActionName("GetVendorServiceById")]
        public VendorService GetVendorServiceById(int Id)
        {
            Log.writeMessage("VendorServiceController GetVendorServiceById Start");
            VendorService VendorService = null;
            try
            {
                VendorService = vendorserviceDAL.GetVendorServiceById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorServiceController GetVendorServiceById Error " + ex.Message);
            }
            Log.writeMessage("VendorServiceController GetVendorServiceById End");
            return VendorService;
        }

        /* [HttpGet]
         [ActionName("GetVendorServiceByEmail")]
         public VendorService GetVendorServiceByEmail(string Email)
         {
             Log.writeMessage("VendorServiceController GetVendorServiceByEmail Start");
             VendorService VendorService = null;
             try
             {
                 VendorService = VendorServiceDAL.GetVendorServiceByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("VendorServiceController GetVendorServiceByEmail Error " + ex.Message);
             }
             Log.writeMessage("VendorServiceController GetVendorServiceByEmail End");
             return VendorService;
         }*/

        [HttpPost]
        [ActionName("AddVendorService")]
        public IHttpActionResult AddVendorService(VendorService VendorService)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                VendorService.CreatedBy = "Admin";
                VendorService.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                VendorService.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                VendorService.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = vendorserviceDAL.AddVendorService(VendorService);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorServiceController AddVendorService Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateVendorService")]
        public IHttpActionResult UpdateVendorService(VendorService VendorService)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                VendorService.CreatedBy = "Admin";
                VendorService.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                VendorService.UpdatedBy = "Admin";
                VendorService.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = vendorserviceDAL.UpdateVendorService(VendorService);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorServiceController AddVendorService Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("VendorServiceController GetVendorServiceById Start");
    Loginc user = null;
    try
    {
        user = VendorServiceDAL.VendorServiceDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("VendorServiceController GetVendorServiceById Error " + ex.Message);
    }
    Log.writeMessage("VendorServiceController GetVendorServiceById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("VendorServiceController GetVendorServiceById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = VendorServiceDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("VendorServiceController GetVendorServiceById Error " + ex.Message);
    }
    Log.writeMessage("VendorServiceController GetVendorServiceById End");
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


//[HttpPost]
//public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
//{                  
//    try
//    {              
//        if (!Request.Content.IsMimeMultipartContent())
//            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

//        var provider = new MultipartMemoryStreamProvider();
//        await Request.Content.ReadAsMultipartAsync(provider);
//        foreach (var file in provider.Contents)
//        {
//            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
//            var buffer = await file.ReadAsByteArrayAsync();
//            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
//            //get the folder that's in
//            string theDirectory = Path.GetDirectoryName(fullPath);
//            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

//            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
//            //Do whatever you want with filename and its binary data.
//        }
//    }
//    catch (Exception ex)
//    {
//        Log.writeMessage(ex.Message);
//    }

//    return Ok();
//}

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
public async Task<IHttpActionResult> SaveVendorServiceImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/VendorService" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var VendorService = VendorServiceDAL.GetVendorServiceById(Id);
            var filenamenew = Id + "_" + filename;
            if (VendorService.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/VendorService" + "/" + VendorService.Photo);
                VendorService.Photo = Id + "_" + filename;
                var result = VendorServiceDAL.UpdateVendorService(VendorService);

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