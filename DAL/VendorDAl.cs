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
    public class VendorDAL 
    {
        DbConnection conn = null;
        public VendorDAL()
        {
            conn = new DbConnection();
        }

        public List<Vendor> GetAllVendor()
        {
            List<Vendor> VendorList = new List<Vendor>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Vendor vendor = new Vendor();

                vendor.VendorId = Convert.ToInt32(dr["VendorId"]);
                

                vendor.Name = Convert.ToString(dr["Name"]);
                vendor.SubTitle = Convert.ToString(dr["SubTite"]);
                vendor.Decsription = Convert.ToString(dr["Description"]);
                vendor.Photo = Convert.ToString(dr["Photo"]);
                vendor.Status = Convert.ToString(dr["Status"]);

                vendor.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendor.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendor.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendor.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                VendorList.Add(vendor);
            }
            con.Close();
            return VendorList;
        }






        public Vendor GetVendorById(int Id)
        {
            Vendor vendor = new Vendor();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetVendorById", con);
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                vendor.VendorId = Convert.ToInt32(dr["VendorId"]);
                

                vendor.Name = Convert.ToString(dr["Name"]);
                vendor.SubTitle = Convert.ToString(dr["SubTitle"]);
                vendor.Decsription = Convert.ToString(dr["Description"]);
                vendor.Photo = Convert.ToString(dr["Photo"]);
                vendor.Status = Convert.ToString(dr["Status"]);

                vendor.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendor.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendor.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendor.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return vendor;
        }


        public string AddVendor(Vendor vendor)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserVendor", con);
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = vendor.VendorId;
            

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = vendor.Name;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = vendor.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = vendor.Decsription;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = vendor.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendor.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendor.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendor.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendor.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendor.UpdatedDate;


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
        public string UpdateVendor(Vendor vendor)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = vendor.VendorId;

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = vendor.Name;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = vendor.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = vendor.Decsription;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = vendor.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendor.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendor.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendor.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendor.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendor.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return vendor.VendorId.ToString();

        }



        public string DeleteVendor(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteVendor", con);
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = Id;
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