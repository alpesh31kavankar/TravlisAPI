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
    public class ServiceDAL
    {
        DbConnection conn = null;
        public ServiceDAL()
        {
            conn = new DbConnection();
        }

        public List<Service> GetAllService()
        {
            List<Service> ServiceList = new List<Service>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Service service = new Service();

                service.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                service.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);

                service.Title = Convert.ToString(dr["Title"]);
                service.SubTitle = Convert.ToString(dr["SubTitle"]);
                service.Photo = Convert.ToString(dr["Photo"]);
                service.Status = Convert.ToString(dr["Status"]);
                service.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                service.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                service.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                service.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                ServiceList.Add(service);
            }
            con.Close();
            return ServiceList;
        }






        public Service GetServiceById(int Id)
        {
            Service service = new Service();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetServiceById", con);
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                service.ServiceId = Convert.ToInt32(dr["ServiceId"]);
                service.VendorServiceId = Convert.ToInt32(dr["VendorServiceId"]);
              

                service.Title = Convert.ToString(dr["Title"]);
                service.SubTitle = Convert.ToString(dr["SubTitle"]);
                service.Photo = Convert.ToString(dr["Photo"]);
                service.Status = Convert.ToString(dr["Status"]);

                service.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                service.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                service.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                service.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return service;
        }   


        public string AddService(Service service)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserService", con);
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = service.ServiceId;
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = service.VendorServiceId;
            

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = service.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = service.SubTitle;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = service.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = service.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = service.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = service.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = service.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = service.UpdatedDate;


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
        public string UpdateService(Service service)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = service.ServiceId;
            cmd.Parameters.Add("VendorServiceId", SqlDbType.Int).Value = service.VendorServiceId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = service.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = service.SubTitle;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = service.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = service.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = service.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = service.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = service.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = service.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return service.ServiceId.ToString();

        }



        public string DeleteService(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteService", con);
            cmd.Parameters.Add("ServiceId", SqlDbType.Int).Value = Id;
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