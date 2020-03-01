using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;



namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            
            if(lines.Length == 0)
            {
                logger.LogError("Zero lines", new NullReferenceException());
            }

            if(lines.Length == 1)
            {
                logger.LogWarning("You are only entering one location");
            }

            logger.LogInfo($"Lines: {lines[0]}");

        
            var parser = new TacoParser();

            
            var locations = lines.Select(parser.Parse).ToArray();


            var finalA = new TacoBell();
            var finalB = new TacoBell();
            finalA = null;
            finalB = null;
            
            double distance = 0;

            

            logger.LogInfo("Finding all distances between any two stores, and comparing each " +
                "to return the farthest distance.");
            for(int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                for(int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var testDistance = corA.GetDistanceTo(corB);
                    if(testDistance > distance)
                    {
                        distance = testDistance;
                        finalA =(TacoBell) locA;
                        finalB = (TacoBell) locB;
                    }
                }
            }

            Console.WriteLine($"The two farthest Taco Bell Locations are {finalA.Name} and {finalB.Name}" +
                $" with a distance of {Math.Round(distance * 0.000621371, 1)} miles.");
        }
    }
}