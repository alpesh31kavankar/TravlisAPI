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
    public class StudentController : ApiController
    {
        
        public Logger Log = null;
        public StudentController()
        {
            Log = Logger.GetLogger();
        }

        StudentDAL StudentDAL = new StudentDAL();

        [HttpGet]
        [ActionName("GetAllStudent")]
        public List<Student> GetAllStudent()
        {
            Log.writeMessage("StudentController GetAllStudent Start");
            List<Student> list = null;
            try
            {
                list = StudentDAL.GetAllStudent();
            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController GetAllStudent Error " + ex.Message);
            }
            Log.writeMessage("StudentController GetAllStudent End");
            return list;
        }

        [HttpGet]
        [ActionName("GetStudentById")]
        public Student GetStudentById(int Id)
        {
            Log.writeMessage("StudentController GetStudentById Start");
            Student student = null;
            try
            {
                student = StudentDAL.GetStudentById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController GetStudentById Error " + ex.Message);
            }
            Log.writeMessage("StudentController GetStudentById End");
            return student;
        }



        [HttpPost]
        [ActionName("AddStudent")]
        public IHttpActionResult AddStudent(Student student)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                student.CreatedBy = "Admin";
                student.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                student.UpdatedBy = "Admin";

                student.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = StudentDAL.AddStudent(student);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController AddStudent Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateStudent")]
        public IHttpActionResult UpdateStudent(Student student)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                student.CreatedBy = "Admin";
                student.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                student.UpdatedBy = "Admin";
                student.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = StudentDAL.UpdateStudent(student);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController AddStudent Error " + ex.Message);
            }
            return Ok(result);
        }
    }
}


        