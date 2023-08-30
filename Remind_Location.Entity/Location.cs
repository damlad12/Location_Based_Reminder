using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Remind_Location.Entity
{
    
    public class Location
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }

  
   public class Point: Location
   {
        public int Kval { get; set; }

        public Point()
        {
            Kval = 0;
        }
        public Point( decimal _latitude, decimal _longitude, int _kval)
        {
            Latitude = _latitude;
            Longitude = _longitude;
            Kval = _kval;
        }
   }
}