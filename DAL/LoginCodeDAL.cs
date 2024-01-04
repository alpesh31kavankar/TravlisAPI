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
    public class LoginCodeDAL
    {
        DbConnection conn = null;
        public LoginCodeDAL()
        {
            conn = new DbConnection();
        }

        public List<LoginCode> GetAllLoginCode()
        {
            List<LoginCode> loginCodeList = new List<LoginCode>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LoginCode loginCode = new LoginCode();

                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);

                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                loginCodeList.Add(loginCode);
            }
            con.Close();
            return loginCodeList;
        }


        public LoginCode GetLoginCodeByEmail(string Email)
        {
            LoginCode loginCode = new LoginCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserLoginByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return loginCode;
        }



        public LoginCode GetLoginCodeById(int Id)
        {
            LoginCode loginCode = new LoginCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserLoginById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return loginCode;
        }


        public string AddLoginCode(LoginCode loginCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserLogin", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = loginCode.Name;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = loginCode.Email;
            cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = loginCode.Mobile;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = loginCode.Password;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = loginCode.Address;

            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = loginCode.BirthDate;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = loginCode.Photo;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = loginCode.EmailStatus;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = loginCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = loginCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = loginCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = loginCode.UpdatedDate;


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
        public string UpdateLoginCode(LoginCode loginCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = loginCode.Id;

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = loginCode.Name;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = loginCode.Email;
            cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = loginCode.Mobile;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = loginCode.Password;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = loginCode.Address;

            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = loginCode.BirthDate;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = loginCode.Photo;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = loginCode.EmailStatus;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = loginCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = loginCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = loginCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = loginCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return loginCode.Id.ToString();

        }

        public Loginc Loginc(string Email, string Password)
        {
            Loginc user = new Loginc();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserEmailAndPassword", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return user;
        }


        public OtpNo OtpNo(string Mobile)
        {
            OtpNo OtpNo = new OtpNo();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserOtp", con);
            cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                OtpNo.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return OtpNo;
        }
        //public string UpdateFirstModel(FirstModel firstModel)
        //{
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("UpdateFirstModel", con);
        //    cmd.Parameters.Add("Id", SqlDbType.Int).Value = firstModel.Id;
        //    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = firstModel.FirstName;
        //    cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = firstModel.LastName;
        //    cmd.Parameters.Add("DOB", SqlDbType.NVarChar).Value = firstModel.DOB;





        //    //cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = firstModel.CreatedBy;
        //    //cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = firstModel.CreatedDate;
        //    //cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = firstModel.UpdatedBy;
        //    //cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = firstModel.UpdatedDate;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}


        //public string DeleteFirstModel(int Id)
        //{
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("DeleteFirstModel", con);
        //    cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}
    }
}