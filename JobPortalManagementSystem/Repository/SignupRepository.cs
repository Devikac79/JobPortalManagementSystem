/*using JobPortalManagementSystem.Models;
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
            command.Parameters.AddWithValue("@phone", signup.phone);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@city", signup.city);

            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
          
            command.Parameters.AddWithValue("@password", signup.password);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
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
            SqlCommand command = new SqlCommand("SPS_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();


            foreach (DataRow row in dataTable.Rows)
                SignupList.Add(new Signup
                {
                    id= Convert.ToInt32(row["Id"]),
                    firstName = Convert.ToString(row["firstName"]),
                    lastName = Convert.ToString(row["lastName"]),
                    dateOfBirth = Convert.ToDateTime(row["dateOfBirth"]),
                    gender = Convert.ToString(row["gender"]),
                    email = Convert.ToString(row["email"]),
                    phone = Convert.ToString(row["phone"]),
                    address = Convert.ToString(row["address"]),
                   
                    state = Convert.ToString(row["state"]),
                    city = Convert.ToString(row["city"]),
                    pincode = Convert.ToInt32(row["pincode"]),
                    country = Convert.ToString(row["country"]),
                    username = Convert.ToString(row["username"]),
                    password = Convert.ToString(row["password"])
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
*/


using JobPortalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JobPortalManagementSystem.Repository
{
    public class SignupRepository
    {   /// <summary>
        /// Database connection
        /// </summary>
        private SqlConnection connection;
        /// <summary>
        /// Defining database connection method
        /// </summary>
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetDataBaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Password enctrypting for database
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        /// <summary>
        /// Adding a new details to the signup record
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        public bool AddSignupDetails(Signup signup)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstName", signup.firstName);
            command.Parameters.AddWithValue("@lastName", signup.lastName);
            command.Parameters.AddWithValue("@dateOfBirth", signup.dateOfBirth);
            command.Parameters.AddWithValue("@gender", signup.gender);
            command.Parameters.AddWithValue("@email", signup.email);
            command.Parameters.AddWithValue("@phone", signup.phone);
            command.Parameters.AddWithValue("@address", signup.address);
            command.Parameters.AddWithValue("@city", signup.city);
            command.Parameters.AddWithValue("@state", signup.state);
            command.Parameters.AddWithValue("@pincode", signup.pincode);
            command.Parameters.AddWithValue("@country", signup.country);
            command.Parameters.AddWithValue("@username", signup.username);
            string hashedPassword = HashPassword(signup.password);
            command.Parameters.AddWithValue("@password", hashedPassword);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Viewing the database signup record
        /// </summary>
        /// <returns></returns>
        public List<Signup> GetSignupDetails()
        {
            Connection();
            List<Signup> SignupList = new List<Signup>();
            SqlCommand command = new SqlCommand("SPS_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            data.Fill(dataTable);
            connection.Close();
            foreach (DataRow datarow in dataTable.Rows)

                SignupList.Add(
                    new Signup
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        firstName = Convert.ToString(datarow["firstName"]),
                        lastName = Convert.ToString(datarow["lastName"]),
                        dateOfBirth = Convert.ToDateTime(datarow["dateOfBirth"]),
                        gender = Convert.ToString(datarow["gender"]),
                        email = Convert.ToString(datarow["email"]),
                        phone = Convert.ToString(datarow["phone"]),
                        address = Convert.ToString(datarow["address"]),
                        city = Convert.ToString(datarow["city"]),
                        state = Convert.ToString(datarow["state"]),
                        pincode = Convert.ToInt32(datarow["pincode"]),
                        country = Convert.ToString(datarow["country"]),
                        username = Convert.ToString(datarow["username"]),
                    }
                    );
            return SignupList;
        }
        /// <summary>
        /// Updating the signup record
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        public bool EditSignupDetails(Signup signup)
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
            command.Parameters.AddWithValue("@phone", signup.phone);
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
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Deleting the signup record of the memeber with specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSignupDetails(int Id)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPD_Signup", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


          // Method to validate user login credentials
    public bool ValidateUser(string username, string password)
    {
        Connection();
        SqlCommand command = new SqlCommand("SPS_ValidateUser", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@username", username);
        string hashedPassword = HashPassword(password);
        command.Parameters.AddWithValue("@password", hashedPassword);

        connection.Open();
        int result = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return result > 0;

    }
    }
}