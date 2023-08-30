using Remind_Location.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remind_Location.Data
{
    public class UserRepository
    {

        public bool CorrectPassword(string username, string password)
        {
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Password FROM [User] WHERE Username = @userName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if(reader.GetString(0) == password)
                            {
                                connection.Close();
                                return true;
                            }
                            else
                            {
                                connection.Close();
                                return false;
                            }
                            
                        }
                        else
                        {
                            connection.Close();
                            return false;
                        }
                    }

                }
            }

        }

        public bool UserExists(string username)
        {
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [User] WHERE Username = @userName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", username);
                    int count = Convert.ToInt32(command.ExecuteScalar());


                    if (count>0)
                        {
                            connection.Close();
                            return true;
                           
                        }
                        else
                        {
                            connection.Close();
                            return false;
                        }
                  

                }
            }

        }

        public bool CreateNewUser(string username, string password)
        {
            var affectedRow = 0;
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO [User] (Username, Password) VALUES (@Value1,@Value2)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value1", username);
                    command.Parameters.AddWithValue("@Value2", password);
                    affectedRow = command.ExecuteNonQuery();
                }
                connection.Close();
                return affectedRow > 0;
               

            }
        }
    }
}
