using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Device.Location;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Xml;
using IpData;
using Remind_Location.Entity;
using Remind_Location.Data;

namespace Remind_Location
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form2 form2 = new Form2();
            Application.Run(form2);
            LocationRepository tracker = new LocationRepository();

            while (true)
            {
                //get the current location
                GeoCoordinate geoCoord = new GeoCoordinate();
                string APIKEY = "adeb98adf0a76eadafd9384d4688115e64286532feac30fcbaa66075";
                var client = new IpDataClient(APIKEY);

                try
                {
                    var ipInfo = await client.Lookup("8.8.8.8");

                    geoCoord.Latitude = ipInfo.Latitude.HasValue ? ipInfo.Latitude.Value : 0.0;
                    geoCoord.Longitude = ipInfo.Longitude.HasValue ? ipInfo.Longitude.Value : 0.0;

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



               if(tracker.IsNear(geoCoord))
                {
                    MessageBox.Show("passing by a saved location");
                }

        
            }
        }
    }
}