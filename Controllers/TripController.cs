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
    public class TripController : ApiController
    {
        // GET: Trip
        public Logger Log = null;
        public TripController()
        {
            Log = Logger.GetLogger();
        }

        TripDAL tripDAL = new TripDAL();

        [HttpGet]
        [ActionName("GetAllTrip")]
        public List<Trip> GetAllTrip()
        {
            Log.writeMessage("TripController GetAllTrip Start");
            List<Trip> list = null;
            try
            {
                list = tripDAL.GetAllTrip();
            }
            catch (Exception ex)
            {
                Log.writeMessage("TripController GetAllTrip Error " + ex.Message);
            }
            Log.writeMessage("TripController GetAllTrip End");
            return list;
        }

        [HttpGet]
        [ActionName("GetTripById")]
        public Trip GetTripById(int Id)
        {
            Log.writeMessage("TripController GetTripById Start");
            Trip Trip = null;
            try
            {
                Trip = tripDAL.GetTripById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("TripController GetTripById Error " + ex.Message);
            }
            Log.writeMessage("TripController GetTripById End");
            return Trip;
        }
        public IHttpActionResult DeleteTrip(int Id)
        {
            try
            {
                var result = tripDAL.DeleteTrip(Id);

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
        /* [HttpGet]
         [ActionName("GetTripByEmail")]
         public Trip GetTripByEmail(string Email)
         {
             Log.writeMessage("TripController GetTripByEmail Start");
             Trip Trip = null;
             try
             {
                 Trip = TripDAL.GetTripByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("TripController GetTripByEmail Error " + ex.Message);
             }
             Log.writeMessage("TripController GetTripByEmail End");
             return Trip;
         }*/

        [HttpPost]
        [ActionName("AddTrip")]
        public IHttpActionResult AddTrip(Trip Trip)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Trip.CreatedBy = "Admin";
                Trip.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Trip.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Trip.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = tripDAL.AddTrip(Trip);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TripController AddTrip Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateTrip")]
        public IHttpActionResult UpdateTrip(Trip Trip)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Trip.CreatedBy = "Admin";
                Trip.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Trip.UpdatedBy = "Admin";
                Trip.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = tripDAL.UpdateTrip(Trip);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TripController AddTrip Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("TripController GetTripById Start");
    Loginc user = null;
    try
    {
        user = TripDAL.TripDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("TripController GetTripById Error " + ex.Message);
    }
    Log.writeMessage("TripController GetTripById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("TripController GetTripById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = TripDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("TripController GetTripById Error " + ex.Message);
    }
    Log.writeMessage("TripController GetTripById End");
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
public async Task<IHttpActionResult> SaveTripImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Trip" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Trip = TripDAL.GetTripById(Id);
            var filenamenew = Id + "_" + filename;
            if (Trip.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Trip" + "/" + Trip.Photo);
                Trip.Photo = Id + "_" + filename;
                var result = TripDAL.UpdateTrip(Trip);

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