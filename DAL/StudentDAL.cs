using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;

namespace PrismAPI.DAL
{
    public class StudentDAL
    {
        DbConnection conn = null;
        public StudentDAL()
        {
            conn = new DbConnection();
        }

        public List<Student> GetAllStudent()
        {
            List<Student> studentList = new List<Student>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Student student = new Student();

                student.Id = Convert.ToInt32(dr["Id"]);

                student.Name = Convert.ToString(dr["Name"]);


                student.Address = Convert.ToString(dr["Address"]);


                student.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                student.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                student.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                student.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                   studentList.Add(student);
            }
            con.Close();
            return studentList;
        }





        public Student GetStudentById(int Id)
        {
            Student student = new Student();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserLoginById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                student.Id = Convert.ToInt32(dr["Id"]);

                student.Name = Convert.ToString(dr["Name"]);

                student.Address = Convert.ToString(dr["Address"]);



                student.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                student.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                student.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                student.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return student;
        }


        public string AddStudent(Student student)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddStudent", con);

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = student.Name;

            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = student.Address;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = student.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = student.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = student.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = student.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }

        [HttpPost]
        public string UpdateStudent(Student student)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = student.Id;

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = student.Name;
            ;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = student.Address;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = student.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = student.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = student.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = student.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return student.Id.ToString();

        }
    }
}

       
        
        