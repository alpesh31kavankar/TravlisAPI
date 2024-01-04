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
    public class AlertController : ApiController
    {
        // GET: Alert
        public Logger Log = null;
        public AlertController()
        {
            Log = Logger.GetLogger();
        }

        AlertDAL alertDAL = new AlertDAL();

        [HttpGet]
        [ActionName("GetAllAlert")]
        public List<Alert> GetAllAlert()
        {
            Log.writeMessage("AlertController GetAllAlert Start");
            List<Alert> list = null;
            try
            {
                list = alertDAL.GetAllAlert();
            }
            catch (Exception ex)
            {
                Log.writeMessage("AlertController GetAllAlert Error " + ex.Message);
            }
            Log.writeMessage("AlertController GetAllAlert End");
            return list;
        }

        [HttpGet]
        [ActionName("GetAlertById")]
        public Alert GetAlertById(int Id)
        {
            Log.writeMessage("AlertController GetAlertById Start");
            Alert Alert = null;
            try
            {
                Alert = alertDAL.GetAlertById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AlertController GetAlertById Error " + ex.Message);
            }
            Log.writeMessage("AlertController GetAlertById End");
            return Alert;
        }

       /* [HttpGet]
        [ActionName("GetAlertByEmail")]
        public Alert GetAlertByEmail(string Email)
        {
            Log.writeMessage("AlertController GetAlertByEmail Start");
            Alert Alert = null;
            try
            {
                Alert = AlertDAL.GetAlertByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AlertController GetAlertByEmail Error " + ex.Message);
            }
            Log.writeMessage("AlertController GetAlertByEmail End");
            return Alert;
        }*/

        [HttpPost]
        [ActionName("AddAlert")]
        public IHttpActionResult AddAlert(Alert Alert)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Alert.CreatedBy = "Admin";
                Alert.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Alert.UpdatedBy = "Admin";
                //Alert.Status = "Success";
                Alert.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = alertDAL.AddAlert(Alert);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AlertController AddAlert Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateAlert")]
        public IHttpActionResult UpdateAlert(Alert Alert)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Alert.CreatedBy = "Admin";
                Alert.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Alert.UpdatedBy = "Admin";
                Alert.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = alertDAL.UpdateAlert(Alert);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AlertController AddAlert Error " + ex.Message);
            }
            return Ok(result);
        }
        public IHttpActionResult DeleteAlert(int Id)
        {
            try
            {
                var result = alertDAL.DeleteAlert(Id);

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

    }
}



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
public async Task<IHttpActionResult> SaveAlertImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Alert" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Alert = AlertDAL.GetAlertById(Id);
            var filenamenew = Id + "_" + filename;
            if (Alert.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Alert" + "/" + Alert.Photo);
                Alert.Photo = Id + "_" + filename;
                var result = AlertDAL.UpdateAlert(Alert);

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