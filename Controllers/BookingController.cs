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
    public class BookingController : ApiController
    {
        // GET: Booking
        public Logger Log = null;
        public BookingController()
        {
            Log = Logger.GetLogger();
        }

        BookingDAL bookingDAL = new BookingDAL();

        [HttpGet]
        [ActionName("GetAllBooking")]
        public List<Booking> GetAllBooking()
        {
            Log.writeMessage("BookingController GetAllBooking Start");
            List<Booking> list = null;
            try
            {
                list = bookingDAL.GetAllBooking();
            }
            catch (Exception ex)
            {
                Log.writeMessage("BookingController GetAllBooking Error " + ex.Message);
            }
            Log.writeMessage("BookingController GetAllBooking End");
            return list;
        }

        [HttpGet]
        [ActionName("GetBookingById")]
        public Booking GetBookingById(int Id)
        {
            Log.writeMessage("BookingController GetBookingById Start");
            Booking Booking = null;
            try
            {
                Booking = bookingDAL.GetBookingById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BookingController GetBookingById Error " + ex.Message);
            }
            Log.writeMessage("BookingController GetBookingById End");
            return Booking;
        }

        /* [HttpGet]
         [ActionName("GetBookingByEmail")]
         public Booking GetBookingByEmail(string Email)
         {
             Log.writeMessage("BookingController GetBookingByEmail Start");
             Booking Booking = null;
             try
             {
                 Booking = BookingDAL.GetBookingByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("BookingController GetBookingByEmail Error " + ex.Message);
             }
             Log.writeMessage("BookingController GetBookingByEmail End");
             return Booking;
         }*/

        [HttpPost]
        [ActionName("AddBooking")]
        public IHttpActionResult AddBooking(Booking Booking)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Booking.CreatedBy = "Admin";
                Booking.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Booking.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Booking.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = bookingDAL.AddBooking(Booking);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BookingController AddBooking Error " + ex.Message);
            }
            return Ok(result);
        }

        public IHttpActionResult DeleteBooking(int Id)
        {
            try
            {
                var result = bookingDAL.DeleteBooking(Id);

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
        [HttpPost]
        [ActionName("UpdateBooking")]
        public IHttpActionResult UpdateBooking(Booking Booking)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Booking.CreatedBy = "Admin";
                Booking.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Booking.UpdatedBy = "Admin";
                Booking.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = bookingDAL.UpdateBooking(Booking);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BookingController AddBooking Error " + ex.Message);
            }
            return Ok(result);
        }

    }
}



/*[HttpGet]
[ActionName("Login")]
public Loginc Loginc(string Email, string Password)
{
    Log.writeMessage("BookingController GetBookingById Start");
    Loginc user = null;
    try
    {
        user = BookingDAL.BookingDAL(Email, Password);
    }
    catch (Exception ex)
    {
        Log.writeMessage("BookingController GetBookingById Error " + ex.Message);
    }
    Log.writeMessage("BookingController GetBookingById End");
    return user;
}

[HttpGet]
[ActionName("OtpNo")]
public OtpNo OtpNo(string Mobile)
{
    Log.writeMessage("BookingController GetBookingById Start");
    OtpNo OtpNo = null;
    try
    {
        OtpNo = BookingDAL.OtpNo(Mobile);
    }
    catch (Exception ex)
    {
        Log.writeMessage("BookingController GetBookingById Error " + ex.Message);
    }
    Log.writeMessage("BookingController GetBookingById End");
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
public async Task<IHttpActionResult> SaveBookingImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Booking" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Booking = BookingDAL.GetBookingById(Id);
            var filenamenew = Id + "_" + filename;
            if (Booking.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Booking" + "/" + Booking.Photo);
                Booking.Photo = Id + "_" + filename;
                var result = BookingDAL.UpdateBooking(Booking);

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