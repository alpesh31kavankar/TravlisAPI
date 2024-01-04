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
    public class BookingDAL
    {
        DbConnection conn = null;
        public BookingDAL()
        {
            conn = new DbConnection();
        }

        public List<Booking> GetAllBooking()
        {
            List<Booking> BookingList = new List<Booking>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Booking booking = new Booking();

                booking.BookingId = Convert.ToInt32(dr["BookingId"]);
                booking.UserId = Convert.ToInt32(dr["UserId"]);
                booking.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);
                booking.BookingDate = Convert.ToString(dr["BookingDate"]);
                booking.Status = Convert.ToString(dr["Status"]);
                booking.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                booking.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                booking.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                booking.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                BookingList.Add(booking);
            }
            con.Close();
            return BookingList;
        }






        public Booking GetBookingById(int Id)
        {
            Booking Booking = new Booking();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetBookingById", con);
            cmd.Parameters.Add("BookingId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                Booking.BookingId = Convert.ToInt32(dr["BookingId"]);
                Booking.UserId = Convert.ToInt32(dr["UserId"]);
                Booking.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);
                Booking.BookingDate = Convert.ToString(dr["BookingDate"]);
                Booking.Status = Convert.ToString(dr["Status"]);
                Booking.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                Booking.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                Booking.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                Booking.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return Booking;
        }


        public string AddBooking(Booking booking)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserBooking", con);
            cmd.Parameters.Add("BookingId", SqlDbType.Int).Value = booking.BookingId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = booking.UserId;
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = booking.VendorServiceId;
            cmd.Parameters.Add("BookingDate", SqlDbType.NVarChar).Value = booking.BookingDate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = booking.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = booking.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = booking.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = booking.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = booking.UpdatedDate;


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
        public string UpdateBooking(Booking booking)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("BookingId", SqlDbType.Int).Value = booking.BookingId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = booking.UserId;
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = booking.VendorServiceId;
            cmd.Parameters.Add("BookingDate", SqlDbType.NVarChar).Value = booking.BookingDate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = booking.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = booking.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = booking.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = booking.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = booking.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return booking.BookingId.ToString();

        }



        public string DeleteBooking(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteBooking", con);
            cmd.Parameters.Add("BookingId", SqlDbType.Int).Value = Id;
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