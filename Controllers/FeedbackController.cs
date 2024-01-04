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
    public class FeedbackController : ApiController
    {
        // GET: Feedback
        public Logger Log = null;
        public FeedbackController()
        {
            Log = Logger.GetLogger();
        }

        FeedbackDAL feedbackDAL = new FeedbackDAL();

        [HttpGet]
        [ActionName("GetAllFeedback")]
        public List<Feedback> GetAllFeedback()
        {
            Log.writeMessage("FeedbackController GetAllFeedback Start");
            List<Feedback> list = null;
            try
            {
                list = feedbackDAL.GetAllFeedback();
            }
            catch (Exception ex)
            {
                Log.writeMessage("FeedbackController GetAllFeedback Error " + ex.Message);
            }
            Log.writeMessage("FeedbackController GetAllFeedback End");
            return list;
        }

        public IHttpActionResult DeleteFeedback(int Id)
        {
            try
            {
                var result = feedbackDAL.DeleteFeedback(Id);

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
        [ActionName("GetFeedbackById")]
        public Feedback GetFeedbackById(int Id)
        {
            Log.writeMessage("FeedbackController GetFeedbackById Start");
            Feedback Feedback = null;
            try
            {
                Feedback = feedbackDAL.GetFeedbackById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("FeedbackController GetFeedbackById Error " + ex.Message);
            }
            Log.writeMessage("FeedbackController GetFeedbackById End");
            return Feedback;
        }

        /* [HttpGet]
         [ActionName("GetFeedbackByEmail")]
         public Feedback GetFeedbackByEmail(string Email)
         {
             Log.writeMessage("FeedbackController GetFeedbackByEmail Start");
             Feedback Feedback = null;
             try
             {
                 Feedback = FeedbackDAL.GetFeedbackByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("FeedbackController GetFeedbackByEmail Error " + ex.Message);
             }
             Log.writeMessage("FeedbackController GetFeedbackByEmail End");
             return Feedback;
         }*/

        [HttpPost]
        [ActionName("AddFeedback")]
        public IHttpActionResult AddFeedback(Feedback Feedback)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Feedback.CreatedBy = "Admin";
                Feedback.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Feedback.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Feedback.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = feedbackDAL.AddFeedback(Feedback);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("FeedbackController AddFeedback Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateFeedback")]
        public IHttpActionResult UpdateFeedback(Feedback Feedback)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Feedback.CreatedBy = "Admin";
                Feedback.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Feedback.UpdatedBy = "Admin";
                Feedback.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = feedbackDAL.UpdateFeedback(Feedback);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("FeedbackController AddFeedback Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("FeedbackController GetFeedbackById Start");
    Loginc user = null;
    try
    {
        user = FeedbackDAL.FeedbackDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("FeedbackController GetFeedbackById Error " + ex.Message);
    }
    Log.writeMessage("FeedbackController GetFeedbackById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("FeedbackController GetFeedbackById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = FeedbackDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("FeedbackController GetFeedbackById Error " + ex.Message);
    }
    Log.writeMessage("FeedbackController GetFeedbackById End");
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
public async Task<IHttpActionResult> SaveFeedbackImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Feedback" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Feedback = FeedbackDAL.GetFeedbackById(Id);
            var filenamenew = Id + "_" + filename;
            if (Feedback.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Feedback" + "/" + Feedback.Photo);
                Feedback.Photo = Id + "_" + filename;
                var result = FeedbackDAL.UpdateFeedback(Feedback);

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