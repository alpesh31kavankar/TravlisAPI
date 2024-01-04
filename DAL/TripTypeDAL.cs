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
    public class TripTypeDAL
    {
        DbConnection conn = null;
        public TripTypeDAL()
        {
            conn = new DbConnection();
        }

        public List<TripType> GetAllTripType()
        {
            List<TripType> triptypeList = new List<TripType>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TripType triptype = new TripType();

                triptype.TripTypeId = Convert.ToInt32(dr["TripTypeId"]);
                

                triptype.Title = Convert.ToString(dr["Title"]);
                triptype.SubTitle = Convert.ToString(dr["SubTitle"]);
                triptype.Icon = Convert.ToString(dr["Icon"]);

                triptype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                triptype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                triptype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                triptype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                triptypeList.Add(triptype);
            }
            con.Close();
            return triptypeList;
        }






        public TripType GetTripTypeById(int Id)
        {
            TripType triptype = new TripType();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetTripTypeById", con);
            cmd.Parameters.Add("TripTypeId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                triptype.TripTypeId = Convert.ToInt32(dr["TripTypeId"]);
                

                triptype.Title = Convert.ToString(dr["Title"]);
                triptype.SubTitle = Convert.ToString(dr["SubTitle"]);
                triptype.Icon = Convert.ToString(dr["Icon"]);



                triptype.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                triptype.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                triptype.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                triptype.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return triptype;
        }


        public string AddTripType(TripType triptype)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddTripType", con);
            
            

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = triptype.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = triptype.SubTitle;
            cmd.Parameters.Add("Icon", SqlDbType.NVarChar).Value = triptype.Icon;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = triptype.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = triptype.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = triptype.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = triptype.UpdatedDate;


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
        public string UpdateTripType(TripType triptype)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("TripTypeId", SqlDbType.Int).Value = triptype.TripTypeId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = triptype.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = triptype.SubTitle;
            cmd.Parameters.Add("Icon", SqlDbType.NVarChar).Value = triptype.Icon;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = triptype.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = triptype.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = triptype.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = triptype.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return triptype.TripTypeId.ToString();

        }



        public string DeleteTripType(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteTripType", con);
            cmd.Parameters.Add("TripTypeId", SqlDbType.Int).Value = Id;
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