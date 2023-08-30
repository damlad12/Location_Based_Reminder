
using Remind_Location.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Device.Location;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Remind_Location.Data
{

    public class LocationRepository
    {
        public bool Create(Location location, string username)
        {
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            int rowCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Location";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    rowCount = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }

            try
            {
                var affectedRow = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Location (Latitude, Longitude, Num, Username) VALUES (@Value1,@Value2, @Value3, @Value4)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Value1", location.Latitude);
                        command.Parameters.AddWithValue("@Value2", location.Longitude);
                        command.Parameters.AddWithValue("@Value3", rowCount);
                        command.Parameters.AddWithValue("@Value4", username);
                        affectedRow = command.ExecuteNonQuery();
                    }

                    connection.Close();

                }
                return affectedRow > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void ReturnLocations(List<Location> locations, string username)
        {
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Latitude, Longitude FROM Location WHERE Username = @userName;", connection);
                command.Parameters.AddWithValue("@userName", username);
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet("Location");
                adapter.Fill(dataSet);
                DataTable dataTable = dataSet.Tables[0];
                connection.Close();
                int i = 0;

                foreach (DataRow row in dataTable.Rows)
                {
                    locations.Add(new Location());
                    locations[i].Latitude = Convert.ToDecimal(row["Latitude"]);
                    locations[i].Longitude = Convert.ToDecimal(row["Longitude"]);
                    i++;
                }


            }
        }

        public bool IsNear(GeoCoordinate geoCoord)
        {
            //check with values in Location table
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Latitude,Longitude FROM Location";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double latCoord = Convert.ToDouble(reader.GetDecimal(0));
                            double lngCoord = Convert.ToDouble(reader.GetDecimal(1));


                            if (geoCoord != null)
                            {
                                double distance = Math.Pow(latCoord - geoCoord.Latitude, 2.0) + Math.Pow(lngCoord - geoCoord.Longitude, 2);
                                Math.Sqrt(distance);
                                if (distance < 10)
                                {
                                    return true;
                                }

                            }
                        }

                    }
                }
                connection.Close();
                return false;
            }

        }

       //Grouping algorithm

       /* public void GroupLocations(string username, int distance)
        {

            List<List<Point>> groupedpoints = new List<List<Point>>();
            string connectionString = "Server=.;Database=Locationsdb;Uid=sa;Pwd=q;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Latitude, Longitude FROM Location WHERE Username = @userName;", connection);
                command.Parameters.AddWithValue("@userName", username);
                adapter.SelectCommand = command;
                DataSet dataSet = new DataSet("Location");
                adapter.Fill(dataSet);
                DataTable dataTable = dataSet.Tables[0];
                connection.Close();
                int i = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    groupedpoints.Add(new List<Point>());
                    groupedpoints[i].Add(new Point());
                    groupedpoints[i][0].Latitude = Convert.ToDecimal(row["Latitude"]);
                    groupedpoints[i][0].Longitude = Convert.ToDecimal(row["Longitude"]);
                    i++;
                }
            }

            double dist;
            int n = groupedpoints.Count;
            bool newPoint = true;

            do
            {
                newPoint = false;
                for (int a = 0; a < n; a++)
                {
                    for (int b = 0; b < n; b++)
                    {
                        if (a == b)
                            continue;
                        var pointa = groupedpoints[a][0];
                        var pointb = groupedpoints[b][0];

                        dist = Math.Pow(Convert.ToDouble(pointa.Latitude) - Convert.ToDouble(pointb.Latitude), 2.0) + Math.Pow(Convert.ToDouble(pointa.Longitude) - Convert.ToDouble(pointb.Longitude), 2.0);
                        Math.Sqrt(dist);

                        if (dist < distance)
                        {
                            double newLat = (Convert.ToDouble(pointa.Latitude) * pointa.Kval + Convert.ToDouble(pointb.Latitude) * pointb.Kval) / (pointa.Kval + pointb.Kval);
                            double newLng = (Convert.ToDouble(pointa.Longitude) * pointa.Kval + Convert.ToDouble(pointb.Longitude) * pointb.Kval) / (pointa.Kval + pointb.Kval);
                            int newK = pointa.Kval + pointb.Kval;

                            groupedpoints[a].Remove(pointa);
                            groupedpoints[b].Remove(pointb);
                            groupedpoints.Insert(0, new List<Point>());
                            groupedpoints[0].Add(new Point(Convert.ToDecimal(newLat), Convert.ToDecimal(newLng), newK));

                            for (int c = 0; c < groupedpoints[a].Count; c++)
                            {
                                Point point = groupedpoints[a][c];
                                groupedpoints[0].Add(point);
                                groupedpoints[a].Remove(point);
                            }

                            for (int c = 0; c < groupedpoints[b].Count; c++)
                            {
                                Point point = groupedpoints[b][c];
                                groupedpoints[0].Add(point);
                                groupedpoints[b].Remove(point);
                            }

                            n--;
                            newPoint = true;
                            break;
                        }
                    }
                    if (newPoint)
                        break;
                }


            } while (newPoint);


        

        }*/

    


    }
}
