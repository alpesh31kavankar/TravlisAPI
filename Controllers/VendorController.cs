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
    public class VendorController : ApiController
    {
        // GET: Vendor
        public Logger Log = null;
        public VendorController()
        {
            Log = Logger.GetLogger();
        }

        VendorDAL vendorDAL = new VendorDAL();

        [HttpGet]
        [ActionName("GetAllVendor")]
        public List<Vendor> GetAllVendor()
        {
            Log.writeMessage("VendorController GetAllVendor Start");
            List<Vendor> list = null;
            try
            {
                list = vendorDAL.GetAllVendor();
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorController GetAllVendor Error " + ex.Message);
            }
            Log.writeMessage("VendorController GetAllVendor End");
            return list;
        }
        public IHttpActionResult DeleteVendor(int Id)
        {
            try
            {
                var result = vendorDAL.DeleteVendor(Id);

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
        [ActionName("GetVendorById")]
        public Vendor GetVendorById(int Id)
        {
            Log.writeMessage("VendorController GetVendorById Start");
            Vendor Vendor = null;
            try
            {
                Vendor = vendorDAL.GetVendorById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorController GetVendorById Error " + ex.Message);
            }
            Log.writeMessage("VendorController GetVendorById End");
            return Vendor;
        }

        /* [HttpGet]
         [ActionName("GetVendorByEmail")]
         public Vendor GetVendorByEmail(string Email)
         {
             Log.writeMessage("VendorController GetVendorByEmail Start");
             Vendor Vendor = null;
             try
             {
                 Vendor = VendorDAL.GetVendorByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("VendorController GetVendorByEmail Error " + ex.Message);
             }
             Log.writeMessage("VendorController GetVendorByEmail End");
             return Vendor;
         }*/

        [HttpPost]
        [ActionName("AddVendor")]
        public IHttpActionResult AddVendor(Vendor Vendor)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Vendor.CreatedBy = "Admin";
                Vendor.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Vendor.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Vendor.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = vendorDAL.AddVendor(Vendor);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorController AddVendor Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
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
        [HttpPost]
        [ActionName("UpdateVendor")]
        public IHttpActionResult UpdateVendor(Vendor Vendor)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Vendor.CreatedBy = "Admin";
                Vendor.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Vendor.UpdatedBy = "Admin";
                Vendor.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = vendorDAL.UpdateVendor(Vendor);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorController AddVendor Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("VendorController GetVendorById Start");
    Loginc user = null;
    try
    {
        user = VendorDAL.VendorDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("VendorController GetVendorById Error " + ex.Message);
    }
    Log.writeMessage("VendorController GetVendorById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("VendorController GetVendorById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = VendorDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("VendorController GetVendorById Error " + ex.Message);
    }
    Log.writeMessage("VendorController GetVendorById End");
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

/*/ [HttpPost]
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
/*
[HttpPost]
public async Task<IHttpActionResult> SaveVendorImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Vendor" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Vendor = VendorDAL.GetVendorById(Id);
            var filenamenew = Id + "_" + filename;
            if (Vendor.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Vendor" + "/" + Vendor.Photo);
                Vendor.Photo = Id + "_" + filename;
                var result = VendorDAL.UpdateVendor(Vendor);

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