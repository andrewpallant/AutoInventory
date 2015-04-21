using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoInventory.App_Code
{
    public class PortalUser
    {
        public Int32 ID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public PortalUser()
        {
        }

        public PortalUser(DataRow row)
        {
            ID = (Int32)row["Id"];
            UserName = (String)row["username"];
            Password = (String)row["password"];
            FirstName = (String)row["firstname"];
            LastName = (String)row["lastname"];
        }

        public static PortalUser ValidateUser(String username, String password)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "getUserByUsernamePassword";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PortalUser user = new PortalUser();
                user.ID = (Int32)reader["Id"];
                user.UserName = (String)reader["username"];
                user.Password = (String)reader["password"];
                user.FirstName = (String)reader["firstname"];
                user.LastName = (String)reader["lastname"];

                return user;
            }

            return new PortalUser();
        }

        /// <summary>
        /// Return All Users From The Database
        /// </summary>
        /// <returns></returns>
        public static PortalUsers getAllUsers()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "getAllUsers";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            PortalUsers users = new PortalUsers();

            while (reader.Read())
            {
                PortalUser user = new PortalUser();
                user.ID = (Int32)reader["Id"];
                user.UserName = (String)reader["username"];
                user.Password = (String)reader["password"];
                user.FirstName = (String)reader["firstname"];
                user.LastName = (String)reader["lastname"];

                users.Add(user);
            }

            return users;
        }
    }

    public class PortalUsers : List<PortalUser>
    {
    }
}