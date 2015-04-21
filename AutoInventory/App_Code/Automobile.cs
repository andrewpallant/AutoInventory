using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoInventory.App_Code
{
    public class Automobile
    {
        public Int32 ID { get; set; }
        public String Manufacturer { get; set; }
        public String Make { get; set; }
        public Int32 Year { get; set; }
        public String Colour { get; set; }
        public Int32 Seating { get; set; }

        public Automobile(){}

        public Automobile(DataRow row)
        {
            ID = Int32.Parse(String.Empty + row["Id"]);
            Manufacturer = String.Empty + row["Manufacturer"];
            Make = String.Empty + row["Make"];
            Year = Int32.Parse(String.Empty + row["Year"]);
            Colour = String.Empty + row["Colour"];
            Seating = Int32.Parse(String.Empty + row["Seating"]);
        }

        /// <summary>
        /// Get All Cars In Inventory
        /// </summary>
        /// <returns></returns>
        public static String GetListing()
        {
            String data = "";

            SqlConnection conn = new SqlConnection("" + ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            conn.Open();

            SqlCommand cmd = new SqlCommand("getAutoListing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);

            data = "[";
            foreach(DataRow row in dt.Rows)
            {
                if (data.Length > 1) data += ",\n";

                data += "{";
                data += String.Format("ID:{0}, Manufacturer:'{1}', Make:'{2}', Year:{3}, Colour:'{4}', Seating:{5}", row["ID"], row["Manufacturer"], row["Make"], row["Year"], row["Colour"], row["Seating"]);
                data += "}";
            }
            data += "]";

            return data;
        }

        /// <summary>
        /// Retrieve Automobile By ID
        /// </summary>
        /// <param name="id">Internal ID</param>
        /// <returns>Autombile Object</returns>
        public static Automobile getCar(Int32 id)
        {
            Automobile car = new Automobile();

            SqlConnection conn = new SqlConnection("" + ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            conn.Open();

            SqlCommand cmd = new SqlCommand("getAutoListing", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);

            foreach (DataRow row in dt.Rows)
            {
                car = new Automobile(row);
            }

            return car;
        }

        /// <summary>
        /// Save Car To Inventory
        /// </summary>
        /// <returns></returns>
        public Automobile Save()
        {
            Automobile car = new Automobile();

            SqlConnection conn = new SqlConnection("" + ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            conn.Open();

            SqlCommand cmd = new SqlCommand("saveAuto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (ID > 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 100);
                cmd.Parameters["@id"].Value = ID;
            }
            cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 100);
            cmd.Parameters["@manufacturer"].Value = Manufacturer;
            cmd.Parameters.Add("@make", SqlDbType.VarChar, 100);
            cmd.Parameters["@make"].Value = Make;
            cmd.Parameters.Add("@year", SqlDbType.Int);
            cmd.Parameters["@year"].Value = Year;
            cmd.Parameters.Add("@colour", SqlDbType.VarChar, 25);
            cmd.Parameters["@colour"].Value = Colour;
            cmd.Parameters.Add("@seating", SqlDbType.Int);
            cmd.Parameters["@seating"].Value = Seating;

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);

            foreach (DataRow row in dt.Rows)
            {
                car = new Automobile(row);
            }

            return car;
        }

        public static Automobile Delete(Int32 id)
        {
            Automobile car = new Automobile();

            SqlConnection conn = new SqlConnection("" + ConfigurationManager.ConnectionStrings["DefaultConnection"]);
            conn.Open();

            SqlCommand cmd = new SqlCommand("deleteAuto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rdr);

            foreach (DataRow row in dt.Rows)
            {
                car = new Automobile(row);
            }

            return car;
        }
    }
}