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
    public class BlogController : ApiController
    {
        // GET: Blog
        public Logger Log = null;
        public BlogController()
        {
            Log = Logger.GetLogger();
        }

        BlogDAL blogDAL = new BlogDAL();

        [HttpGet]
        [ActionName("GetAllBlog")]
        public List<Blog> GetAllBlog()
        {
            Log.writeMessage("BlogController GetAllBlog Start");
            List<Blog> list = null;
            try
            {
                list = blogDAL.GetAllBlog();
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController GetAllBlog Error " + ex.Message);
            }
            Log.writeMessage("BlogController GetAllBlog End");
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
        [HttpGet]
        [ActionName("GetBlogById")]
        public Blog GetBlogById(int Id)
        {
            Log.writeMessage("BlogController GetBlogById Start");
            Blog Blog = null;
            try
            {
                Blog = blogDAL.GetBlogById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController GetBlogById Error " + ex.Message);
            }
            Log.writeMessage("BlogController GetBlogById End");
            return Blog;
        }

        /* [HttpGet]
         [ActionName("GetBlogByEmail")]
         public Blog GetBlogByEmail(string Email)
         {
             Log.writeMessage("BlogController GetBlogByEmail Start");
             Blog Blog = null;
             try
             {
                 Blog = BlogDAL.GetBlogByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("BlogController GetBlogByEmail Error " + ex.Message);
             }
             Log.writeMessage("BlogController GetBlogByEmail End");
             return Blog;
         }*/

        [HttpPost]
        [ActionName("AddBlog")]
        public IHttpActionResult AddBlog(Blog Blog)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Blog.CreatedBy = "Admin";
                Blog.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Blog.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                Blog.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = blogDAL.AddBlog(Blog);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController AddBlog Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateBlog")]
        public IHttpActionResult UpdateBlog(Blog Blog)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Blog.CreatedBy = "Admin";
                Blog.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                Blog.UpdatedBy = "Admin";
                Blog.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = blogDAL.UpdateBlog(Blog);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController AddBlog Error " + ex.Message);
            }
            return Ok(result);
        }

        public IHttpActionResult DeleteBlog(int Id)
        {
            try
            {
                var result = blogDAL.DeleteBlog(Id);

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
public async Task<IHttpActionResult> SaveBlogImage(int Id)
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
            File.WriteAllBytes(theDirectory + "/Content/Blog" + "/" + Id + "_" + filename, buffer);
            //Do whatever you want with filename and its binary data.

            // get existing rocrd
            var Blog = BlogDAL.GetBlogById(Id);
            var filenamenew = Id + "_" + filename;
            if (Blog.Photo.ToLower() != filenamenew.ToLower())
            {
                File.Delete(theDirectory + "/Content/Blog" + "/" + Blog.Photo);
                Blog.Photo = Id + "_" + filename;
                var result = BlogDAL.UpdateBlog(Blog);

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