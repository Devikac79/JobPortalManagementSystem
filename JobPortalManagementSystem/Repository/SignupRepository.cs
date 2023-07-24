using JobPortalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JobPortalManagementSystem.Repository
{
    public class SignupRepository
    {
        private SqlConnection connection;

        /// <summary>
        /// Handle connection
        /// </summary>
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetDatabaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        //Model name
        public bool AddDetails(Signup signup)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@firstName", signup.firstName);
            command.Parameters.AddWithValue("@lastName", signup.lastName);
            command.Parameters.AddWithValue("@dateOfBirth", signup.dateOfBirth);
            command.Parameters.AddWithValue("@gender", signup.gender);
            command.Parameters.AddWithValue("@email", signup.email);
            command.Parameters.AddWithValue("phone", signup.phone);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@city", signup.city);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
            command.Parameters.AddWithValue("@password", signup.password);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Signup> GetDetails()
        {
            Connection();
            List<Signup> SignupList = new List<Signup>();
            SqlCommand command = new SqlCommand("SPI_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();


            foreach (DataRow row in dataTable.Rows)
                SignupList.Add(new Signup
                {
                    Id = Convert.ToInt32(row["ID"]),
                    firstName = Convert.ToString(row["firstName"]),
                    lastName = Convert.ToString(row["lastName"]),
                    dateOfBirth = Convert.ToDateTime(row["dateOfBirth"]),
                    gender = Convert.ToChar(row["gender"]),
                    email = Convert.ToString(row["email"]),
                    phone = Convert.ToString(row["phone"]),
                    address = Convert.ToString(row["address"]),
                    city = Convert.ToString(row["city"]),
                    state = Convert.ToString(row["state"]),
                    pincode = Convert.ToInt32(row["pincode"]),
                    country = Convert.ToString(row["country"]),
                    username = Convert.ToString(row["username"]),
                    password = (byte[])(row["password"])
                }
                );
                return SignupList;
        }

        public bool EditDetails(Signup signup)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPU_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", signup.Id);
            command.Parameters.AddWithValue("@firstName", signup.firstName);
            command.Parameters.AddWithValue("@lastName", signup.lastName);
            command.Parameters.AddWithValue("@dateOfBirth", signup.dateOfBirth);
            command.Parameters.AddWithValue("@gender", signup.gender);
            command.Parameters.AddWithValue("@email", signup.email);
            command.Parameters.AddWithValue("phone", signup.phone);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@city", signup.city);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
            command.Parameters.AddWithValue("@password", signup.password);


            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteDetails(int Id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("Id",Id);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
