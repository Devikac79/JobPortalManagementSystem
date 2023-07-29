using JobPortalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;

namespace JobPortalManagementSystem.Repository
{

    public class JobPostRepository
    {
        private SqlConnection connection;
        /// <summary>
        /// Defining database connection method
        /// </summary>
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetDataBaseConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
      
        public bool AddJobPost(JobPost jobPost)
        {
            Connection();
            SqlCommand command = new SqlCommand("SPI_JobPost", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", jobPost.Id);
            command.Parameters.AddWithValue("@title", jobPost.title);
            command.Parameters.AddWithValue("@location", jobPost.location);
            command.Parameters.AddWithValue("@min_salary", jobPost.minSalary);
            command.Parameters.AddWithValue("@max_salary", jobPost.maxSalary);
            command.Parameters.AddWithValue("@job_category", jobPost.JobCategoryId);
            command.Parameters.AddWithValue("@job_nature", jobPost.JobNatureId);
            command.Parameters.AddWithValue("@post_date", jobPost.postDate);
            command.Parameters.AddWithValue("@end_date", jobPost.endDate);
            command.Parameters.AddWithValue("@description", jobPost.description);


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


        public List<JobPost> GetJobPostDetails()
        {
            Connection();
            List<JobPost> JobPostList = new List<JobPost>();
            SqlCommand command = new SqlCommand("SPS_JobPost", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connection.Open();
            data.Fill(dataTable);
            connection.Close();
            foreach (DataRow datarow in dataTable.Rows)

                JobPostList.Add(
                    new JobPost
                    {
                        Id = Convert.ToInt32(datarow["Id"]),
                        title = Convert.ToString(datarow["title"]),
                        location = Convert.ToString(datarow["location"]),
                        minSalary = Convert.ToInt32(datarow["min_salary"]),
                        maxSalary = Convert.ToInt32(datarow["max_salary"]),
                        JobCategoryId = Convert.ToInt32(datarow["JobCategoryId"]),
                        JobNatureId = Convert.ToInt32(datarow["JobNatureId"]),
                        postDate = Convert.ToDateTime(datarow["postDate"]),
                        endDate = Convert.ToDateTime(datarow["endDate"]),

                        description = Convert.ToString(datarow["description"])


                    }
                    );
            return JobPostList;
        }
        /*

        public List<Category> GetDistinctJobCategories()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GetDataBaseConnection"].ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Category> categoryList = new List<Category>();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Id, category FROM Table_JobCategories", connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoryList.Add(new Category
                        {
                            Id = reader["Id"],
                            category= reader["naturename"].ToString()
                        });
                    }
                }
                return categoryList;
            }
        }
        */
       
        }

    }
