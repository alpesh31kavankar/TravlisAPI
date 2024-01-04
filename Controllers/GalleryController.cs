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
    public class GalleryController : ApiController
    {
        // GET: Gallery
        public Logger Log = null;
        public GalleryController()
        {
            Log = Logger.GetLogger();
        }

        GalleryDAL galleryDAL = new GalleryDAL();

        [HttpGet]
        [ActionName("GetAllGallery")]
        public List<Gallery> GetAllGallery()
        {
            Log.writeMessage("GalleryController GetAllGallery Start");
            List<Gallery> list = null;
            try
            {
                list = galleryDAL.GetAllGallery();
            }
            catch (Exception ex)
            {
                Log.writeMessage("GalleryController GetAllGallery Error " + ex.Message);
            }
            Log.writeMessage("GalleryController GetAllGallery End");
            return list;
        }

        public IHttpActionResult DeleteGallery(int Id)
        {
            try
            {
                var result = galleryDAL.DeleteGallery(Id);

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
        [ActionName("GetGalleryById")]
        public Gallery GetGalleryById(int Id)
        {
            Log.writeMessage("GalleryController GetGalleryById Start");
            Gallery Gallery = null;
            try
            {
                Gallery = galleryDAL.GetGalleryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GalleryController GetGalleryById Error " + ex.Message);
            }
            Log.writeMessage("GalleryController GetGalleryById End");
            return Gallery;
        }

        /* [HttpGet]
         [ActionName("GetGalleryByEmail")]
         public Gallery GetGalleryByEmail(string Email)
         {
             Log.writeMessage("GalleryController GetGalleryByEmail Start");
             Gallery Gallery = null;
             try
             {
                 Gallery = GalleryDAL.GetGalleryByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("GalleryController GetGalleryByEmail Error " + ex.Message);
             }
             Log.writeMessage("GalleryController GetGalleryByEmail End");
             return Gallery;
         }*/

        [HttpPost]
        [ActionName("AddGallery")]
        public IHttpActionResult AddGallery(Gallery Gallery)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Gallery.CreatedBy = "Admin";
                Gallery.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Gallery.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Gallery.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = galleryDAL.AddGallery(Gallery);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("GalleryController AddGallery Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateGallery")]
        public IHttpActionResult UpdateGallery(Gallery Gallery)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Gallery.CreatedBy = "Admin";
                Gallery.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Gallery.UpdatedBy = "Admin";
                Gallery.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = galleryDAL.UpdateGallery(Gallery);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("GalleryController AddGallery Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("GalleryController GetGalleryById Start");
    Loginc user = null;
    try
    {
        user = GalleryDAL.GalleryDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("GalleryController GetGalleryById Error " + ex.Message);
    }
    Log.writeMessage("GalleryController GetGalleryById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("GalleryController GetGalleryById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = GalleryDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("GalleryController GetGalleryById Error " + ex.Message);
    }
    Log.writeMessage("GalleryController GetGalleryById End");
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
public async Task<IHttpActionResult> SaveGalleryImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Gallery" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Gallery = GalleryDAL.GetGalleryById(Id);
            var filenamenew = Id + "_" + filename;
            if (Gallery.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Gallery" + "/" + Gallery.Photo);
                Gallery.Photo = Id + "_" + filename;
                var result = GalleryDAL.UpdateGallery(Gallery);

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