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
using static Hephaestus.Logs;

namespace PrismAPI.DAL
{
    public class BlogDAL
    {
        DbConnection conn = null;
        public BlogDAL()
        {
            conn = new DbConnection();
        }

        public List<Blog> GetAllBlog()
        {
            List<Blog> BlogList = new List<Blog>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllBlog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Blog blog = new Blog();

                blog.BlogId = Convert.ToInt32(dr["BlogId"]);
                blog.UserId = Convert.ToInt32(dr["UserId"]);
                blog.DestinationId = Convert.ToInt32(dr["DestinationId"]);
                blog.Title = Convert.ToString(dr["Title"]);
                blog.SubTitle = Convert.ToString(dr["SubTitle"]);
                blog.Description = Convert.ToString(dr["Description"]);
                blog.Content = Convert.ToString(dr["Content"]);
                blog.Status = Convert.ToString(dr["Status"]);
                blog.Photo = Convert.ToString(dr["Photo"]);
                blog.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blog.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blog.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                blog.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                BlogList.Add(blog);
            }
            con.Close();
            return BlogList;
        }






        public Blog GetBlogById(int Id)
        {
            Blog blog = new Blog();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetBlogById", con);
            cmd.Parameters.Add("BlogId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                blog.BlogId = Convert.ToInt32(dr["BlogId"]);
                blog.UserId = Convert.ToInt32(dr["UserId"]);
                blog.DestinationId = Convert.ToInt32(dr["DestinationId"]);
                blog.Title = Convert.ToString(dr["Title"]);
                blog.SubTitle = Convert.ToString(dr["SubTitle"]);
                blog.Description = Convert.ToString(dr["Description"]);
                blog.Content = Convert.ToString(dr["Content"]);
                blog.Status = Convert.ToString(dr["Status"]);
                blog.Photo = Convert.ToString(dr["Photo"]);
                blog.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                blog.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                blog.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                blog.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return blog;
        }


        public string AddBlog(Blog Blog)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserBlog", con);
            cmd.Parameters.Add("BlogId", SqlDbType.Int).Value = Blog.BlogId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = Blog.UserId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = Blog.DestinationId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = Blog.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = Blog.SubTitle;
            cmd.Parameters.Add("Decsription", SqlDbType.NVarChar).Value = Blog.Description;
            cmd.Parameters.Add("Content", SqlDbType.NVarChar).Value = Blog.Content;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = Blog.Status;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = Blog.Photo;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = Blog.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = Blog.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = Blog.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = Blog.UpdatedDate;


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
        public string UpdateBlog(Blog blog)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("BlogId", SqlDbType.Int).Value = blog.BlogId;
            cmd.Parameters.Add("UserId", SqlDbType.Int).Value = blog.UserId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = blog.DestinationId;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = blog.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = blog.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = blog.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = blog.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return blog.BlogId.ToString();

        }



        public string DeleteBlog(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteBlog", con);
            cmd.Parameters.Add("BlogId", SqlDbType.Int).Value = Id;
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