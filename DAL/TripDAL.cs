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
    public class TripDAL
    {
        DbConnection conn = null;
        public TripDAL()
        {
            conn = new DbConnection();
        }

        public List<Trip> GetAllTrip()
        {
            List<Trip> TripList = new List<Trip>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Trip trip = new Trip();

                trip.TripId = Convert.ToInt32(dr["TripId"]);
                trip.UserId = Convert.ToInt32(dr["UserId"]);
                trip.VendorId = Convert.ToInt32(dr["VendorId"]);
                trip.TripTypeId = Convert.ToInt32(dr["TripTypeId"]);
                trip.Source = Convert.ToString(dr["Source"]);
                trip.Date = Convert.ToString(dr["Date"]);
                trip.Status = Convert.ToString(dr["Status"]);
                trip.Budget = Convert.ToDecimal(dr["Budget"]);
                trip.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                trip.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                trip.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                trip.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                TripList.Add(trip);
            }
            con.Close();
            return TripList;
        }






        public Trip GetTripById(int Id)
        {
            Trip trip = new Trip();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetTripById", con);
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                trip.TripId = Convert.ToInt32(dr["TripId"]);
                trip.UserId = Convert.ToInt32(dr["UserId"]);
                trip.VendorId = Convert.ToInt32(dr["VendorId"]);
                trip.TripTypeId = Convert.ToInt32(dr["TripTypeId"]);

                trip.Source = Convert.ToString(dr["Source"]);
                trip.Date = Convert.ToString(dr["Date"]);
                trip.Status = Convert.ToString(dr["Status"]);
                trip.Budget = Convert.ToDecimal(dr["Budget"]);

                trip.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                trip.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                trip.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                trip.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return trip;
        }


        public string AddTrip(Trip trip)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserTrip", con);
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = trip.TripId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = trip.UserId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = trip.VendorId;
            cmd.Parameters.Add("TripTypeId", SqlDbType.Int).Value = trip.TripTypeId;

            cmd.Parameters.Add("Source", SqlDbType.NVarChar).Value = trip.Source;
            cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = trip.Date;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = trip.Status;
            cmd.Parameters.Add("Budget", SqlDbType.NVarChar).Value = trip.Budget;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = trip.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = trip.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = trip.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = trip.UpdatedDate;


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
        public string UpdateTrip(Trip trip)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = trip.TripId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = trip.UserId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = trip.VendorId;
            cmd.Parameters.Add("TripTypeId", SqlDbType.Int).Value = trip.TripTypeId;

            cmd.Parameters.Add("Source", SqlDbType.NVarChar).Value = trip.Source;
            cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = trip.Date;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = trip.Status;
            cmd.Parameters.Add("Budget", SqlDbType.NVarChar).Value = trip.Budget;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = trip.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = trip.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = trip.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = trip.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return trip.TripId.ToString();

        }



        public string DeleteTrip(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteTrip", con);
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = Id;
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
