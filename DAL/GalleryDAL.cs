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
    public class GalleryDAL
    {
        DbConnection conn = null;
        public GalleryDAL()
        {
            conn = new DbConnection();
        }

        public List<Gallery> GetAllGallery()
        {
            List<Gallery> GalleryList = new List<Gallery>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Gallery gallery = new Gallery();

                gallery.GalleryId = Convert.ToInt32(dr["GalleryId"]);
                gallery.UserId = Convert.ToInt32(dr["UserId"]);
                gallery.TripId = Convert.ToInt32(dr["TripId"]);
                gallery.Title = Convert.ToString(dr["Title"]);
                gallery.SubTitle = Convert.ToString(dr["SubTitle"]);
                gallery.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                gallery.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                gallery.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                gallery.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                GalleryList.Add(gallery);
            }
            con.Close();
            return GalleryList;
        }






        public Gallery GetGalleryById(int Id)
        {
            Gallery gallery = new Gallery();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetGalleryById", con);
            cmd.Parameters.Add("GalleryId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                gallery.GalleryId = Convert.ToInt32(dr["GalleryId"]);
                gallery.UserId = Convert.ToInt32(dr["UserId"]);
                gallery.TripId = Convert.ToInt32(dr["TripId"]);
                gallery.Title = Convert.ToString(dr["Title"]);
                gallery.SubTitle = Convert.ToString(dr["SubTitle"]);
                gallery.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                gallery.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                gallery.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                gallery.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return gallery;
        }


        public string AddGallery(Gallery gallery)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserGallery", con);
            cmd.Parameters.Add("GalleryId", SqlDbType.Int).Value = gallery.GalleryId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = gallery.UserId;
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = gallery.TripId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = gallery.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = gallery.SubTitle;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = gallery.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = gallery.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = gallery.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = gallery.UpdatedDate;


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
        public string UpdateGallery(Gallery gallery)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("GalleryId", SqlDbType.Int).Value = gallery.GalleryId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = gallery.UserId;
            cmd.Parameters.Add("TripId", SqlDbType.Int).Value = gallery.TripId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = gallery.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = gallery.SubTitle;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = gallery.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = gallery.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = gallery.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = gallery.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return gallery.GalleryId.ToString();

        }



        public string DeleteGallery(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteGallery", con);
            cmd.Parameters.Add("GalleryId", SqlDbType.Int).Value = Id;
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