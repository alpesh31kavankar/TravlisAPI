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
    public class VendorServiceDAL
    {
        DbConnection conn = null;
        public VendorServiceDAL()
        {
            conn = new DbConnection();
        }

        public List<VendorService> GetAllVendorService()
        {
            List<VendorService> VendorServiceList = new List<VendorService>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                VendorService vendorservice = new VendorService();

                vendorservice.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);
                vendorservice.VendorId = Convert.ToInt32(dr["VendorId"]);
                vendorservice.DestinationId = Convert.ToInt32(dr["DestinationId"]);
                vendorservice.ServiceId = Convert.ToInt32(dr["DestinationId"]);
                vendorservice.ServiceCost = Convert.ToDecimal(dr["ServiceCost"]); 

                vendorservice.Status = Convert.ToString(dr["Status"]);
                vendorservice.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendorservice.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendorservice.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendorservice.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                VendorServiceList.Add(vendorservice);
            }
            con.Close();
            return VendorServiceList;
        }






        public VendorService GetVendorServiceById(int Id)
        {
            VendorService vendorservice = new VendorService();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetVendorServiceById", con);
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                vendorservice.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);
                vendorservice.VendorId = Convert.ToInt32(dr["VendorId"]);
                vendorservice.DestinationId = Convert.ToInt32(dr["DestinationId"]);
                vendorservice.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                vendorservice.ServiceId = (int)Convert.ToDecimal(dr["ServiceId"]);


                vendorservice.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendorservice.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendorservice.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendorservice.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return vendorservice;
        }


        public string AddVendorService(VendorService vendorservice)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserVendorService", con);
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = vendorservice.VendorServiceId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = vendorservice.VendorId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = vendorservice.DestinationId;
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = vendorservice.ServiceId;

            cmd.Parameters.Add("ServiceCost", SqlDbType.NVarChar).Value = vendorservice.ServiceCost;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendorservice.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendorservice.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendorservice.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendorservice.UpdatedDate;


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
        public string UpdateVendorService(VendorService vendorservice)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = vendorservice.VendorServiceId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = vendorservice.VendorId;
            cmd.Parameters.Add("DestinationId", SqlDbType.Int).Value = vendorservice.DestinationId;
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = vendorservice.ServiceId;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendorservice.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendorservice.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendorservice.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendorservice.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return vendorservice.VendorServiceId.ToString();

        }



        public string DeleteVendorService(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteVendorService", con);
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = Id;
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