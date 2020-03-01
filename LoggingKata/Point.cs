using System;

namespace LoggingKata
{
    public struct Point
    {
        
        public Point(double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public static implicit operator Point((double, double) v)
        {
            throw new NotImplementedException();
        }
    }
}