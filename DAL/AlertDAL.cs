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
    public class AlertDAL
    {
        DbConnection conn = null;
        public AlertDAL()
        {
            conn = new DbConnection();
        }

        public List<Alert> GetAllAlert()
        {
            List<Alert> AlertList = new List<Alert>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Alert alert = new Alert();

                alert.AlertId = Convert.ToInt32(dr["AlertId"]);
                alert.UserId = Convert.ToInt32(dr["UserId"]);
                alert.DestinationId = Convert.ToInt32(dr["DestinationId"]);
                alert.AlertMessage = Convert.ToString(dr["AlertMessage"]);
                alert.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                alert.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                alert.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                alert.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                AlertList.Add(alert);
            }
            con.Close();
            return AlertList;
        }






        public Alert GetAlertById(int Id)
        {
            Alert alert = new Alert();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAlertById", con);
            cmd.Parameters.Add("AlertId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                alert.AlertId = Convert.ToInt32(dr["AlertId"]);
                alert.UserId = Convert.ToInt32(dr["UserId"]);
                alert.DestinationId = Convert.ToInt32(dr["DestinationId"]);

                alert.AlertMessage = Convert.ToString(dr["AlertMessage"]);

                alert.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                alert.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                alert.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                alert.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return alert;
        }


        public string AddAlert(Alert alert)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserAlert", con);
            cmd.Parameters.Add("AlertId", SqlDbType.Int).Value = alert.AlertId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = alert.UserId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = alert.DestinationId;

            cmd.Parameters.Add("AlertMessage", SqlDbType.NVarChar).Value = alert.AlertMessage;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = alert.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = alert.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = alert.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = alert.UpdatedDate;


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
        public string UpdateAlert(Alert alert)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("AlertId", SqlDbType.Int).Value = alert.AlertId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = alert.UserId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = alert.DestinationId;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = alert.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = alert.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = alert.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = alert.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return alert.AlertId.ToString();

        }


        
        public string DeleteAlert(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteAlert", con);
            cmd.Parameters.Add("AlertId", SqlDbType.Int).Value = Id;
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