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
    public class TripTypeController : ApiController
    {
        // GET: TripType
        public Logger Log = null;
        public TripTypeController()
        {
            Log = Logger.GetLogger();
        }

        TripTypeDAL TripTypeDAL = new TripTypeDAL();

        [HttpGet]
        [ActionName("GetAllTripType")]
        public List<TripType> GetAllTripType()
        {
            Log.writeMessage("TripTypeController GetAllTripType Start");
            List<TripType> list = null;
            try
            {
                list = TripTypeDAL.GetAllTripType();
            }
            catch (Exception ex)
            {
                Log.writeMessage("TripTypeController GetAllTripType Error " + ex.Message);
            }
            Log.writeMessage("TripTypeController GetAllTripType End");
            return list;
        }
        public IHttpActionResult DeleteTripType(int Id)
        {
            try
            {
                var result = TripTypeDAL.DeleteTripType(Id);

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
        [ActionName("GetTripTypeById")]
        public TripType GetTripTypeById(int Id)
        {
            Log.writeMessage("TripTypeController GetTripTypeById Start");
            TripType triptype = null;
            try
            {
                triptype = TripTypeDAL.GetTripTypeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("TripTypeController GetTripTypeById Error " + ex.Message);
            }
            Log.writeMessage("TripTypeController GetTripTypeById End");
            return triptype;
        }

        /* [HttpGet]
         [ActionName("GetTripTypeByEmail")]
         public TripType GetTripTypeByEmail(string Email)
         {
             Log.writeMessage("TripTypeController GetTripTypeByEmail Start");
             TripType TripType = null;
             try
             {
                 TripType = TripTypeDAL.GetTripTypeByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("TripTypeController GetTripTypeByEmail Error " + ex.Message);
             }
             Log.writeMessage("TripTypeController GetTripTypeByEmail End");
             return TripType;
         }*/

        [HttpPost]
        [ActionName("AddTripType")]
        public IHttpActionResult AddTripType(TripType triptype)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                triptype.CreatedBy = "Admin";
                triptype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                triptype.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                triptype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = TripTypeDAL.AddTripType(triptype);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("tripTypeController AddtripType Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateTripType")]
        public IHttpActionResult UpdateTripType(TripType triptype)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                triptype.CreatedBy = "Admin";
                triptype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                triptype.UpdatedBy = "Admin";
                triptype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = TripTypeDAL.UpdateTripType(triptype);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TripTypeController AddTripType Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("TripTypeController GetTripTypeById Start");
    Loginc user = null;
    try
    {
        user = TripTypeDAL.TripTypeDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("TripTypeController GetTripTypeById Error " + ex.Message);
    }
    Log.writeMessage("TripTypeController GetTripTypeById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("TripTypeController GetTripTypeById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = TripTypeDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("TripTypeController GetTripTypeById Error " + ex.Message);
    }
    Log.writeMessage("TripTypeController GetTripTypeById End");
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
public async Task<IHttpActionResult> SaveTripTypeImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/TripType" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var TripType = TripTypeDAL.GetTripTypeById(Id);
            var filenamenew = Id + "_" + filename;
            if (TripType.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/TripType" + "/" + TripType.Photo);
                TripType.Photo = Id + "_" + filename;
                var result = TripTypeDAL.UpdateTripType(TripType);

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