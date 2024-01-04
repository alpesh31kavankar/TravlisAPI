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
    public class FeedbackDAL
    {
        DbConnection conn = null;
        public FeedbackDAL()
        {
            conn = new DbConnection();
        }

        public List<Feedback> GetAllFeedback()
        {
            List<Feedback> FeedbackList = new List<Feedback>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Feedback feedback = new Feedback();

                feedback.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
                feedback.UserId = Convert.ToInt32(dr["UserId"]);
                feedback.VendorId = Convert.ToInt32(dr["VendorId"]);
                feedback.FeedbackText = Convert.ToString(dr["FeedbackText"]);
                feedback.Rating = (int)Convert.ToDecimal(dr["Rating"]);
                feedback.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                feedback.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                feedback.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                feedback.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                FeedbackList.Add(feedback);
            }
            con.Close();
            return FeedbackList;
        }






        public Feedback GetFeedbackById(int Id)
        {
            Feedback feedback = new Feedback();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetFeedbackById", con);
            cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                feedback.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
                feedback.UserId = Convert.ToInt32(dr["UserId"]);
                feedback.VendorId = Convert.ToInt32(dr["VendorId"]);
                feedback.FeedbackText = Convert.ToString(dr["FeedbackText"]);
                feedback.Rating = (int)Convert.ToDecimal(dr["Rating"]);
                feedback.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                feedback.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                feedback.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                feedback.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return feedback;
        }


        public string AddFeedback(Feedback feedback)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserFeedback", con);
            cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = feedback.FeedbackId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = feedback.UserId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = feedback.VendorId;
            cmd.Parameters.Add("FeedbackText", SqlDbType.NVarChar).Value = feedback.FeedbackText;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = feedback.Rating;            
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedback.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedback.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedback.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedback.UpdatedDate;


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
        public string UpdateFeedback(Feedback feedback)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = feedback.FeedbackId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = feedback.UserId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = feedback.VendorId;
            cmd.Parameters.Add("FeedbackText", SqlDbType.NVarChar).Value = feedback.FeedbackText;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = feedback.Rating;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedback.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedback.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedback.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedback.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return feedback.FeedbackId.ToString();

        }



        public string DeleteFeedback(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteFeedback", con);
            cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }
    }
}