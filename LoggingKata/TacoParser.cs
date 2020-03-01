using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            if (line == null || line == "")
                return null;


            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {

                logger.LogInfo("Array is less than 3");
                
                return null;
            }
            // TODO Implement

            // If your array.Length is more than 3, something went wrong
            if (cells.Length > 3)
            {
                logger.LogInfo("Array is more than 3");
                return null;
            }

            // grab the latitude from your array at index 0
            var latitude = double.Parse(cells[0]);

            // grab the longitude from your array at index 1
            var longitude = double.Parse(cells[1]);

            // grab the name from your array at index 2
            var name = cells[2];


            var store = new TacoBell();
            store.Name = name;
            store.Location = new Point(latitude, longitude);
           

            return store;
        }
    }
}